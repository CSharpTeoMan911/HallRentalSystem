var expansion_animation_interval = undefined;
var gradient_fluctuation_interval = undefined;
var background_image_sizing = undefined;
var home_page_elements_resizing = undefined;
var home_page_button_focus = undefined;

let current_width = 0;
let current_gradient = 0;
let switch_gradient_offset = false;

let current_alpha = 0.65;

// GRADIENT FLUCTUATION ANIMATION
//
// [ BEGIN ]
function GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient) {
    let element = document.getElementById(element_id);
    if (element !== null) {
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
}

export function GradientFluctuationAnimationCancellation() {
    if (gradient_fluctuation_interval !== undefined) {
        clearInterval(gradient_fluctuation_interval);
    }
}

export function GradientFluctuationAnimation(element_id, initial_gradient, final_gradient, interval) {
    current_gradient = initial_gradient;
    gradient_fluctuation_interval = setInterval(() => { GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient); }, interval);
}

// [ END ]



// ELEMENT EXPANSION ANIMATION
//
// [ BEGIN ]
function ExpansionAnimationImplementation(element_id, max_width, size_unit) {
    let element = document.getElementById(element_id);
    if (element !== null) {
        if (current_width < max_width) {
            element.style.width = current_width + size_unit;
        }
        current_width++;
    }
}

export function ClearExpansionAnimation() {
    if (expansion_animation_interval !== undefined) {
        clearInterval(expansion_animation_interval);
    }
}

export function ExpansionAnimation(element_id, max_width, interval, size_unit) {
    current_width = 0;
    expansion_animation_interval = setInterval(() => { ExpansionAnimationImplementation(element_id, max_width, size_unit) }, interval);
}

// [ END ]



// BACKGROUND IMAGE SIZING
//
// [ START ]

function Background_Image_Sizing() {
    let background = document.getElementById("background_image");
    let main_structure_div = document.getElementById("main_body").offsetHeight;
    if (background !== null) {
        if (main_structure_div !== null) {
            background.style.height = main_structure_div + "px";
        }
    }
}

export function Clear_Background_Image_Sizing() {
    if (background_image_sizing !== undefined) {
        clearInterval(background_image_sizing);
    }
}

export function Set_Background_Image_Sizing() {
    background_image_sizing = setInterval(() => { Background_Image_Sizing(); }, 1);
}

// [ END ]



// HOME PAGE ELEMENT RESIZING
//
// [ START ]

function Resize_Home_Page_Elements() {
    let main_page_button_1 = document.getElementById("main_page_button_1");
    let main_page_button_2 = document.getElementById("main_page_button_2");
    let content_block_1 = document.getElementById("content_block_1");
    let content_block_2 = document.getElementById("content_block_2");
    let index_page_jumbotron = document.getElementById("index_page_jumbotron");

    if (content_block_1 !== null) {
        if (content_block_2 !== null) {
            if (index_page_jumbotron !== null) {
                if (main_page_button_1 !== null) {
                    if (main_page_button_2 !== null) {
                        if (index_page_jumbotron.offsetWidth <= 1200) {
                            content_block_1.style.width = "100%";
                            content_block_2.style.width = "100%";
                            main_page_button_1.style.height = "20vh";
                            main_page_button_2.style.height = "20vh";
                            index_page_jumbotron.style.marginTop = "20px";
                        }
                        else {
                            content_block_1.style.width = "49.8%";
                            content_block_2.style.width = "49.8%";
                            main_page_button_1.style.height = "35vh";
                            main_page_button_2.style.height = "35vh";
                            index_page_jumbotron.style.marginTop = "110px";
                        }
                    }
                }
            }
        }
    }
}

export function Clear_Resize_Home_Page_Elements() {
    if (home_page_elements_resizing !== undefined) {
        clearInterval(home_page_elements_resizing);
    }
}

export function Set_Resize_Home_Page_Elements() {
    home_page_elements_resizing = setInterval(() => { Resize_Home_Page_Elements(); }, 100);
}

// [ END ]



// HOME PAGE BUTTON HOVER
//
// [ START ]

function Button_Focus_Effect(element_id) {
    let button_cover = document.getElementById(element_id);
    if (home_page_button_focus !== undefined) {
        if (current_alpha > 0.3) {
            current_alpha = current_alpha - 0.01;
            try {
                button_cover.style.background = "linear-gradient(to right, rgba(61, 57, 50, " + current_alpha + "), rgba(91, 90, 90, " + current_alpha + "))";
            }
            catch {
                clearInterval(home_page_button_focus);
            }
        }
    }
}
export function Clear_Set_Button_Focus_Effect(element_id) {
    if (home_page_button_focus !== undefined) {
        clearInterval(home_page_button_focus);
    }
    let button_cover = document.getElementById(element_id);
    if (button_cover != null) {
        button_cover.style.background = "linear-gradient(to right, rgba(61, 57, 50, 0.55), rgba(91, 90, 90, 0.55))";
    }
}
export function Set_Button_Focus_Effect(element_id) {
    current_alpha = 0.55;
    home_page_button_focus = setInterval(() => { Button_Focus_Effect(element_id); }, 10);
}

// [ END ]