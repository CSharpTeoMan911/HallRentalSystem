let expansion_animation_interval = undefined;
let gradient_fluctuation_interval = undefined;
let background_image_sizing = undefined;
let current_width = 0;
let current_gradient = 0;
let switch_gradient_offset = false;

// GRADIENT FLUCTUATION ANIMATION
//
// [ BEGIN ]
async function GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient) {
    let element = document.getElementById(element_id);
    element.style.background = "linear-gradient(to right, rgb(22, 22, 22), " + current_gradient + "%, #999999 75%)";

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



// BACKGROUND IMAGE SIZING
//
// [ START ]

function Background_Image_Sizing() {
    let background = document.getElementById("background_image");
    let main_structure_div = document.getElementById("main_page_structure_div").offsetHeight;
    background.style.height = main_structure_div + "px";
}

export async function Clear_Background_Image_Sizing() {
    if (background_image_sizing !== undefined) {
        await clearInterval(background_image_sizing);
    }
}

export async function Set_Background_Image_Sizing() {
    background_image_sizing = await setInterval(async () => { await Background_Image_Sizing(); }, 1);
}

// [ END ]