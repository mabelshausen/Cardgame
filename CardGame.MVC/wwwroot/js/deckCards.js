var ApiUri = "https://localhost:5001/api/decks/";
var CardsUri = "https://localhost:5001/api/cards/";

var router = new VueRouter({
    mode: 'history',
    routes: [{ path: '/decks/builder/:id' }]
});
var app = new Vue({
    router,
    el: '#app',
    data: {
        message: "Please wait a moment.",
        message2: "...",
        deckId: null,
        currentDeck: null,
        cards: null,
        selectedDeckCard: null,
        selectedCard: null,
        deckCardSelected: false,
        cardSelected: false
    },
    created: function () {
        var self = this;
        self.deckId = parseInt(self.$route.params.id);
        self.fetchDeckCards();
        self.fetchCards();
    },
    methods: {
        fetchDeckCards: function () {
            self = this;
            fetch(`${ApiUri}WithCards/${self.deckId}`)
                .then(res => res.json())
                .then(function (res) {
                    res.deckCards.forEach(function (deckcard) {
                        deckcard.isActive = false;
                    });
                    self.currentDeck = res;
                    self.message = "Deck Cards";
                })
                .catch(err => console.error("There was an error: " + err));
        },
        fetchCards: function () {
            self = this;
            fetch(`${CardsUri}`)
                .then(res => res.json())
                .then(function (res) {
                    res.forEach(function (card) {
                        card.isActive = false;
                    });
                    self.cards = res;
                    self.message2 = "All Cards";
                })
                .catch(err => console.error("There was an error: " + err));
        },
        selectDeckCard: function (deckcard) {
            self = this;
            self.selectedDeckCard = deckcard;
            self.selectedCard = null;
            self.deckCardSelected = true;
            self.cardSelected = false;
            self.setActiveCard(deckcard);
        },
        selectCard: function (card) {
            self = this;
            self.selectedDeckCard = null;
            self.selectedCard = card;
            self.deckCardSelected = false;
            self.cardSelected = true;
            self.setActiveCard(card);
        },
        setActiveCard: function (card) {
            self = this;
            self.currentDeck.deckCards.forEach(function (card2) {
                card2.isActive = false;
            });
            self.cards.forEach(function (card2) {
                card2.isActive = false;
            });
            card.isActive = true;
        },
        getCardClass: function (card) {
            if (card.isActive)
                return "list-group-item active";
            return "list-group-item";
        }
    }
});