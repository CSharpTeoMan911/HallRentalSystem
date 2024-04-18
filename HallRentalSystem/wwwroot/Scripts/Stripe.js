const stripe = Stripe('pk_test_51P6efVRsFLK70EkgACA8JTU38M7Bjia94PV5xqaVtSguC68jTYuaKK9A4jweqzm1DBlymcwu6PEyrgPpEDWTi0gS005r9zIYbR');
let card = undefined;
export function InitiatePaymentObject(_amount) {
    const elements = stripe.elements({
        mode: "payment",
        currency: "gbp",
        amount: _amount
    });

    card = elements.create('card');
    card.mount("#payment_div");
}

export function CreatePaymentMethod() {
    stripe.createPaymentMethod({
        type: 'card',
        card: card,
        billing_details: {
            name: 'Jenny Rosen',
        },
    })
    .then((result) => {
         
    });
}

