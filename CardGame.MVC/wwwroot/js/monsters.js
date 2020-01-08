var ApiUri = "https://localhost:5001/api/monsters/";
var BareApiUri = "https://localhost:5001/api/";

var app = new Vue({
    el: '#app',
    data: {
        message: "Please wait a moment.",
        monsters: null,
        decks: null,
        currentMonster: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchMonsters();
        self.fetchDecks();
    },
    methods: {
        fetchMonsters: function () {
            self = this;
            fetch(`${ApiUri}`)
                .then(res => res.json())
                .then(function (res) {
                    res.forEach(function (monster) {
                        monster.isActive = false;
                    });
                    self.monsters = res;
                    self.message = "Monsters";
                    if (self.monsters.length > 0) {
                        self.fetchMonsterDetails(self.monsters[0]);
                    }
                })
                .catch(err => console.error("There was an error: " + err));
        },
        fetchMonsterDetails: function (monster) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${ApiUri}${monster.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentMonster = res;
                    self.monsters.forEach(function (monster2) {
                        monster2.isActive = false;
                    });
                    monster.isActive = true;
                });
        },
        getMonsterClass: function (monster) {
            if (monster.isActive)
                return "list-group-item active";
            return "list-group-item";
        },
        fetchDecks: function () {
            self = this;
            fetch(`${BareApiUri}Decks`)
                .then(res => res.json())
                .then(function (res) {
                    self.decks = res;
                })
                .catch(err => console.error("There was an error: " + err));
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentMonster = {
                    "name": "", "health": 0, "deckId": 0 };
            }
        },
        save: function () {
            var self = this;

            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: "PUT",
                body: JSON.stringify(self.currentMonster),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${ApiUri}${self.currentMonster.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateMonsterList(res);
                        self.fetchMonsterDetails(self.currentMonster);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            else {
                ajaxConfig.method = "POST";
                let myRequest = new Request(`${ApiUri}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addMonsterToList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addMonsterToList: function (monster) {
            self.currentMonster.id = monster.id;
            self.monsters.push(monster);
            self.fetchMonsterDetails(self.monsters[self.monsters.length - 1]);
        },
        updateMonsterList: function (monster) {
            var updatedMonster = self.monsters.filter(m => m.id === monster.id)[0];
            updatedMonster.name = monster.name;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchMonsterDetails(self.currentMonster);
            } else {
                self.fetchMonsterDetails(self.monsters[0]);
            }
        },
        deleteMonster: function () {
            self = this;
            fetch(`${ApiUri}${self.currentMonster.id}`, { method: "DELETE" })
                .then(res => res.json())
                .then(function (res) {
                    self.monsters.forEach(function (monster, i) {
                        if (monster.id === self.currentMonster.id) {
                            self.monsters.splice(i, 1);
                            return;
                        }
                    });
                    if (self.monsters.length > 0)
                        self.fetchMonsterDetails(self.monsters[0]);
                })
                .catch(err => console.error("There was an error: " + err));
        }
    }
});