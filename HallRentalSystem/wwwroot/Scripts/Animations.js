﻿let expansion_animation_interval = undefined;
let gradient_fluctuation_interval = undefined;
let background_image_sizing = undefined;
let home_page_elements_resizing = undefined;
let home_page_button_focus = undefined;
let contacts_page_elements_resizing = undefined;
let auth_gradient_fluctuation_interval = undefined;

let current_width = 0;
let current_gradient = 0;
let switch_gradient_offset = false;

let current_auth_gradient = 0;
let switch_auth_gradient_offset = false;

let current_alpha = 0.65;


// BACKGROUND SELECTION
//
// [ BEGIN ]

export function SetBackgroundImage() {
    let page = window.location.pathname;

    let background_image = document.getElementById("background_image");
    if (background_image !== null) {
        if (page === "/log-in" || page == "/sign-up") {
            background_image.style.backgroundImage = "url(\"https://ik.imagekit.io/freeflo/production/a18246a8-8491-491b-963d-fad1f060471b.png?tr=w-3840,q-75&alt=media&pr-true\")";
        }
        else {
            background_image.style.backgroundImage = "url(\"https://images.pixexid.com/a-futuristic-city-designed-using-gothic-architecture-k4zwosr1.jpeg\")";
        }
    }
}

// [ END ]


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
                        if (index_page_jumbotron.offsetWidth <= 1150) {
                            content_block_1.style.width = "100%";
                            content_block_2.style.width = "100%";
                            main_page_button_1.style.height = "12vh";
                            main_page_button_2.style.height = "12vh";
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



// RESIZE CONTACTS PAGE ELEMENTS
//
// [ START ]

function Resize_Contacts_Page_Elemets() {
    let contacts_page_jumbotron = document.getElementById("contacts_page_jumbotron");
    let main_container_segment_1 = document.getElementById("main_container_segment_1");
    let main_container_segment_2 = document.getElementById("main_container_segment_2");
    let location_map = document.getElementById("location_map");

    if (contacts_page_jumbotron !== null) {
        if (main_container_segment_1 !== null) {
            if (main_container_segment_2 !== null) {
                if (location_map !== null) {
                    location_map.style.height = (main_container_segment_2.offsetHeight * 96 / 100) + "px";

                    if (contacts_page_jumbotron.offsetWidth <= 1100) {
                        main_container_segment_1.style.width = "100%";
                        main_container_segment_2.style.width = "100%";
                        main_container_segment_2.style.marginTop = "40px";
                    }
                    else {
                        main_container_segment_1.style.width = "49.8%";
                        main_container_segment_2.style.width = "49.8%";
                        main_container_segment_2.style.marginTop = "0px";
                    }
                }
            }
        }
    }
}

export function Clear_Resize_Contacts_Page_Elemets() {
    if (contacts_page_elements_resizing !== null) {
        clearInterval(contacts_page_elements_resizing);
    }
}

export function Set_Resize_Contacts_Page_Elemets() {
    contacts_page_elements_resizing = setInterval(() => { Resize_Contacts_Page_Elemets(); }, 100)
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



// AUTH GRADIENT FLUCTUATION ANIMATION
//
//

function AuthGradientFluctuation() {
    let auth_jumbotron = document.getElementById("auth_jumbotron");

    if (auth_jumbotron !== null) {
        auth_jumbotron.style.background = "linear-gradient(to left, #969696 20%, white " + current_auth_gradient + "%)";

        switch (switch_auth_gradient_offset) {
            case true:
                switch (current_auth_gradient > 50) {
                    case true:
                        current_auth_gradient--;
                        break;
                    case false:
                        switch_auth_gradient_offset = false;
                        break;
                }
                break;
            case false:
                switch (current_auth_gradient < 100) {
                    case true:
                        current_auth_gradient++;
                        break;
                    case false:
                        switch_auth_gradient_offset = true;
                        break;
                }
                break;
        }
    }
}

export function ClearAuthGradientFluctuation() {
    if (auth_gradient_fluctuation_interval != null) {
        clearInterval(auth_gradient_fluctuation_interval);
    }
}

export function SetAuthGradientFluctuation() {
    current_auth_gradient = 60;
    auth_gradient_fluctuation_interval = setInterval(() => { AuthGradientFluctuation(); }, 20)
}

// [ END ]