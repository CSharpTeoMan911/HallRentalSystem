const stripe = Stripe('pk_test_51P6efVRsFLK70EkgACA8JTU38M7Bjia94PV5xqaVtSguC68jTYuaKK9A4jweqzm1DBlymcwu6PEyrgPpEDWTi0gS005r9zIYbR');
let card = undefined;

export function InitiatePaymentObject(_amount) {
    try {
        const elements = stripe.elements({
            mode: "payment",
            currency: "gbp",
            amount: _amount
        });

        card = elements.create('card');
        card.mount("#payment_div");

        return "[ Successful ]";
    }
    catch (error) {
        return "[ Error ]";
    }
}

export async function CreatePaymentMethod(_name, _city, _country, _address, _email) {
    try {
        let result = await stripe.createPaymentMethod({
            type: 'card',
            card: card,
            billing_details: {
                name: _name,
                address: {
                    city: _city,
                    country: _country,
                    line1: _address,
                    email: _email
                }
            },
        });
        if (result.error !== undefined) {
            return "Error: " + result.error.message
        }
        else
        {
            return await JSON.stringify(result);
        }
    }
    catch (error) {
        return "Error: " + error.message;
    }
}

