var ApiUri = "https://localhost:5001/api/cards/";

var app = new Vue({
    el: '#app',
    data: {
        message: "Please wait a moment.",
        cards: null,
        currentCard: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchCards();
    },
    methods: {
        fetchCards: function () {
            self = this;
            fetch(`${ApiUri}`)
                .then(res => res.json())
                .then(function (res) {
                    res.forEach(function (card) {
                        card.isActive = false;
                    });
                    self.cards = res;
                    self.message = "Cards";
                    if (self.cards.length > 0) {
                        self.fetchCardDetails(self.cards[0]);
                    }
                })
                .catch(err => console.error("There was an error: " + err));
        },
        fetchCardDetails: function (card) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${ApiUri}${card.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentCard = res;
                    self.cards.forEach(function (card2) {
                        card2.isActive = false;
                    });
                    card.isActive = true;
                });
        },
        getCardClass: function (card) {
            if (card.isActive)
                return "list-group-item active";
            return "list-group-item";
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentCard = { "name": "", "description": "", "deckCards": null, "effects": null };
            }
        },
        save: function () {
            var self = this;

            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: "PUT",
                body: JSON.stringify(self.currentCard),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${ApiUri}${self.currentCard.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateCardList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            else {
                ajaxConfig.method = "POST";
                let myRequest = new Request(`${ApiUri}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addCardToList(res);
                    })
                    .catch(err => console.error("There was an error: " + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addCardToList: function (card) {

            self.currentCard.id = card.id;
            self.cards.push(card);
            self.fetchCardDetails(self.cards[self.cards.length - 1]);
        },
        updateCardList: function (card) {
            var updatedCard = self.cards.filter(c => c.id === card.id)[0];
            updatedCard.name = card.name;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchCardDetails(self.currentCard);
            } else {
                self.fetchCardDetails(self.cards[0]);
            }
        },
        deleteCard: function () {
            self = this;
            fetch(`${ApiUri}${self.currentCard.id}`, { method: "DELETE" })
                .then(res => res.json())
                .then(function (res) {
                    self.cards.forEach(function (card, i) {
                        if (card.id === self.currentCard.id) {
                            self.cards.splice(i, 1);
                            return;
                        }
                    });
                    if (self.cards.length > 0)
                        self.fetchCardDetails(self.cards[0]);
                })
                .catch(err => console.error("There was an error: " + err));
        }
    }
});