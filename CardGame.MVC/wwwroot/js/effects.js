var ApiUri = "https://localhost:5001/api/effects/";
var BareApiUri = "https://localhost:5001/api/";

var router = new VueRouter({
    mode: 'history',
    routes: [{ path: '/effects/index/:id' }]
});
var app = new Vue({
    router,
    el: '#app',
    data: {
        message: "Please wait a moment.",
        cardId: null,
        effects: null,
        currentEffect: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.cardId = parseInt(self.$route.params.id);
        self.fetchEffects();
    },
    methods: {
        fetchEffects: function () {
            self = this;
            fetch(`${ApiUri}byCardId/${self.cardId}`)
                .then(res => res.json())
                .then(function (res) {
                    res.forEach(function (effect) {
                        effect.isActive = false;
                    });
                    self.effects = res;
                    self.message = "Effects";
                    if (self.effects.length > 0) {
                        self.fetchEffectDetails(self.effects[0]);
                    }
                })
                .catch(err => console.error("There was an error: " + err));
        },
        fetchEffectDetails: function (effect) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${ApiUri}${effect.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentEffect = res;
                    self.effects.forEach(function (effect2) {
                        effect2.isActive = false;
                    });
                    effect.isActive = true;
                });
        },
        getEffectClass: function (effect) {
            if (effect.isActive)
                return "list-group-item active";
            return "list-group-item";
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentEffect = {
                    "code": "", "power": 0, "chance": 1 ,"cardId": self.cardId
                };
            }
        },
        save: function () {
            var self = this;

            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: "PUT",
                body: JSON.stringify(self.currentEffect),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${ApiUri}${self.currentEffect.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateEffectList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            else {
                ajaxConfig.method = "POST";
                let myRequest = new Request(`${ApiUri}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addEffectToList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addEffectToList: function (effect) {
            self.currentEffect.id = effect.id;
            self.effects.push(effect);
            self.fetchEffectDetails(self.effects[self.effects.length - 1]);
        },
        updateEffectList: function (effect) {
            var updatedEffect = self.effects.filter(e => e.id === effect.id)[0];
            updatedEffect.name = effect.name;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchEffectDetails(self.currentEffect);
            } else {
                self.fetchEffectDetails(self.effects[0]);
            }
        },
        deleteEffect: function () {
            self = this;
            fetch(`${ApiUri}${self.currentEffect.id}`, { method: "DELETE" })
                .then(res => res.json())
                .then(function (res) {
                    self.effects.forEach(function (effect, i) {
                        if (effect.id === self.currentEffect.id) {
                            self.effects.splice(i, 1);
                            return;
                        }
                    });
                    if (self.effects.length > 0)
                        self.fetchEffectDetails(self.effects[0]);
                })
                .catch(err => console.error("There was an error: " + err));
        }
    }
});