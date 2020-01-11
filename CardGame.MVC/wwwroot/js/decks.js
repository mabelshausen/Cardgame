var ApiUri = "https://localhost:5001/api/decks/";

var app = new Vue({
    el: '#app',
    data: {
        message: "Please wait a moment.",
        decks: null,
        currentDeck: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchDecks();
    },
    methods: {
        fetchDecks: function () {
            self = this;
            fetch(`${ApiUri}`)
                .then(res => res.json())
                .then(function (res) {
                    res.forEach(function (deck) {
                        deck.isActive = false;
                    });
                    self.decks = res;
                    self.message = "Decks";
                    if (self.decks.length > 0) {
                        self.fetchDeckDetails(self.decks[0]);
                    }
                })
                .catch(err => console.error("There was an error: " + err));
        },
        fetchDeckDetails: function (deck) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${ApiUri}${deck.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentDeck = res;
                    self.decks.forEach(function (deck2) {
                        deck2.isActive = false;
                    });
                    deck.isActive = true;
                });
        },
        getDeckClass: function (deck) {
            if (deck.isActive)
                return "list-group-item active";
            return "list-group-item";
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentDeck = { "name": "", "deckCards": null };
            }
        },
        save: function () {
            var self = this;

            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: "PUT",
                body: JSON.stringify(self.currentDeck),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${ApiUri}${self.currentDeck.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateDeckList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            else {
                ajaxConfig.method = "POST";
                let myRequest = new Request(`${ApiUri}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addDeckToList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addDeckToList: function (deck) {

            self.currentDeck.id = deck.id;
            self.decks.push(deck);
            self.fetchDeckDetails(self.decks[self.decks.length - 1]);
        },
        updateDeckList: function (deck) {
            var updatedDeck = self.decks.filter(d => d.id === deck.id)[0];
            updatedDeck.name = deck.name;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchDeckDetails(self.currentDeck);
            } else {
                self.fetchDeckDetails(self.decks[0]);
            }
        },
        deleteDeck: function () {
            self = this;
            fetch(`${ApiUri}${self.currentDeck.id}`, { method: "DELETE" })
                .then(res => res.json())
                .then(function (res) {
                    self.decks.forEach(function (deck, i) {
                        if (deck.id === self.currentDeck.id) {
                            self.decks.splice(i, 1);
                            return;
                        }
                    });
                    if (self.decks.length > 0)
                        self.fetchDeckDetails(self.decks[0]);
                })
                .catch(err => console.error("There was an error: " + err));
        }
    }
});