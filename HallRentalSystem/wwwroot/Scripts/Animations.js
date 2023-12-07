var expansion_animation_interval = undefined;
var gradient_fluctuation_interval = undefined;
let current_width = 0;
let current_gradient = 0;
let switch_gradient_offset = false;


// GRADIENT FLUCTUATION ANIMATION
//
// [ BEGIN ]
async function GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient) {
    let element = document.getElementById(element_id);
    element.style.background = "linear-gradient(to right, #242424, " + current_gradient + "%, #6d6c6c 75%)";

    switch (switch_gradient_offset) {
        case true:
            current_gradient--;
            if (current_gradient <= initial_gradient) {
                switch_gradient_offset = false;
            }
            break;
        case false:
            current_gradient++;

            if (current_gradient >= final_gradient) {
                switch_gradient_offset = true;
            }
            break;
    }
}

export async function GradientFluctuationAnimationCancellation() {
    await clearInterval(gradient_fluctuation_interval);
}

export async function GradientFluctuationAnimation(element_id, initial_gradient, final_gradient, interval) {
    current_gradient = initial_gradient;
    gradient_fluctuation_interval = await setInterval(async () => { await GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient); }, interval);
}

// [ END ]



// ELEMENT EXPANSION ANIMATION
//
// [ BEGIN ]
async function ExpansionAnimationImplementation(element_id, max_width, size_unit) {
    let element = document.getElementById(element_id);

    if (current_width < max_width) {
        element.style.width = current_width + size_unit;
    }
    else {
        await clearInterval(expansion_animation_interval);
    }
    current_width++;
}

export async function ExpansionAnimation(element_id, max_width, interval, size_unit) {
    expansion_animation_interval = await setInterval(async () => { await ExpansionAnimationImplementation(element_id, max_width, size_unit) }, interval);
}

// [ END ]