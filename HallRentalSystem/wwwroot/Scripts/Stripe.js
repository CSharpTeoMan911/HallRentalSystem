const stripe = Stripe('pk_test_51P6efVRsFLK70EkgACA8JTU38M7Bjia94PV5xqaVtSguC68jTYuaKK9A4jweqzm1DBlymcwu6PEyrgPpEDWTi0gS005r9zIYbR');
let card = undefined;

export function InitiatePaymentObject(_amount) {
    try {
        const elements = stripe.elements({
            mode: "payment",
            currency: "gbp",
            amount: (_amount * 100)
        });

        card = elements.create('card');
        card.mount("#payment_div");

        return "[ Successful ]";
    }
    catch (error) {
        console.log(error);
        return "[ Error ]";
    }
}

export async function CreatePaymentMethod(_name, _city, _address, _email) {
    try {
        let result = await stripe.createPaymentMethod({
            type: 'card',
            card: card,
            billing_details: {
                name: _name,
                address: {
                    city: _city,
                    line1: _address,
                },
                email: _email
            },
        });
        console.log(result);
        if (result.error !== undefined) {
            return "Error: " + result.error.message
        }
        else
        {
            return result.paymentMethod.id;
        }
    }
    catch (error) {
        console.log(error);
        return "Error: " + error.message;
    }
}

