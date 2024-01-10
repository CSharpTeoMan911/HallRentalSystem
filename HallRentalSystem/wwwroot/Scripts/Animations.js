let expansion_animation_interval = undefined;
let gradient_fluctuation_interval = undefined;
let background_image_sizing = undefined;
let home_page_elements_resizing = undefined;
let home_page_button_focus = undefined;

let current_width = 0;
let current_gradient = 0;
let switch_gradient_offset = false;

let current_alpha = 0.65;

// GRADIENT FLUCTUATION ANIMATION
//
// [ BEGIN ]
async function GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient) {
    let element = document.getElementById(element_id);
    element.style.background = "linear-gradient(to right, rgb(22, 22, 22), " + current_gradient + "%, #7D7D7D 75%)";

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
        element.style.width = "90%";
        await clearInterval(expansion_animation_interval);
    }
    current_width++;
}

export async function ExpansionAnimation(element_id, max_width, interval, size_unit) {
    let element = document.getElementById(element_id);
    element.style.width = "0%";
    expansion_animation_interval = await setInterval(async () => { await ExpansionAnimationImplementation(element_id, max_width, size_unit) }, interval);
}

// [ END ]



// BACKGROUND IMAGE SIZING
//
// [ START ]

function Background_Image_Sizing() {
    let background = document.getElementById("background_image");
    let main_structure_div = document.getElementById("main_body").offsetHeight;
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



// HOME PAGE ELEMENT RESIZING
//
// [ START ]

function Resize_Home_Page_Elements() {
    let content_block_1 = document.getElementById("content_block_1");
    let content_block_2 = document.getElementById("content_block_2");
    let index_page_jumbotron = document.getElementById("index_page_jumbotron");

    if (content_block_1 !== null) {
        if (content_block_2 !== null) {
            if (index_page_jumbotron !== null) {
                if (index_page_jumbotron.offsetWidth <= 1600) {
                    content_block_1.style.width = "100%";
                    content_block_2.style.width = "100%";
                }
                else {
                    content_block_1.style.width = "49.8%";
                    content_block_2.style.width = "49.8%";
                }
            }
        }
    }
}

export async function Clear_Resize_Home_Page_Elements() {
    if (home_page_elements_resizing !== undefined) {
        await clearInterval(home_page_elements_resizing);
    }
}

export async function Set_Resize_Home_Page_Elements() {
    home_page_elements_resizing = await setInterval(async () => { await Resize_Home_Page_Elements(); }, 100);
}

// [ END ]



// HOME PAGE BUTTON HOVER
//
// [ START ]

async function Button_Focus_Effect(element_id) {
    let button_cover = document.getElementById(element_id);
    if (home_page_button_focus !== undefined) {
        if (current_alpha > 0.3) {
            current_alpha = current_alpha - 0.1;
            console.log(current_alpha);
            button_cover.style.background = "linear-gradient(to right, rgba(61, 57, 50, " + current_alpha + "), rgba(91, 90, 90, " + current_alpha + "))";
        }
    }
}
export async function Clear_Set_Button_Focus_Effect(element_id) {
    if (home_page_button_focus !== undefined) {
        await clearInterval(home_page_button_focus);
    }
    let button_cover = document.getElementById(element_id);
    button_cover.style.background = "linear-gradient(to right, rgba(61, 57, 50, 0.65), rgba(91, 90, 90, 0.65))";
    current_alpha = 0.65;
}
export async function Set_Button_Focus_Effect(element_id) {
    home_page_button_focus = await setInterval(async () => { await Button_Focus_Effect(element_id); }, 100);
}

// [ END ]