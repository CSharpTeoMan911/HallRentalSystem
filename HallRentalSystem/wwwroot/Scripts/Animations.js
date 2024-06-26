﻿let expansion_animation_interval = undefined;
let gradient_fluctuation_interval = undefined;
let background_image_sizing = undefined;
let home_page_elements_resizing = undefined;
let home_page_button_focus = undefined;
let contacts_page_elements_resizing = undefined;
let auth_gradient_fluctuation_interval = undefined;
let booking_elements_container_resize = undefined;
let booking_elements_resize = undefined;

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

async function GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient) {
    // GET THE HTML ELEMENT ON WHICH THE GRADIENT FLUCTUATION WILL BE APPLIED
    let element = document.getElementById(element_id);

    // IF THE ELEMENT EXTRACTED IS NOT NULL
    if (element !== null) {
        // SET THE GRADIENT WITH THE CURRENT GRADIENT VALUE
        element.style.background = "linear-gradient(to right, rgb(22, 22, 22), " + current_gradient + "%, #7D7D7D 75%)";

        switch (switch_gradient_offset) {
            // IF THE GRADIENT OFFSET IS SWITCHED, DECREASE THE GRADIENT VALUE
            case true:
                current_gradient--;
                // IF THE GRADIENT REACHED THE MINMUM VALUE, UN-SWITCH THE GRADIENT
                if (current_gradient <= initial_gradient) {
                    switch_gradient_offset = false;
                }
                break;
            // IF THE GREADIENT OFFSET IS NOT SWITCHED, INCREASE THE GRADIENT VALUE
            case false:
                current_gradient++;
                // IF THE GRADIENT REACHED THE MAXIMUM VALUE, SWITCH THE GRADIENT
                if (current_gradient >= final_gradient) {
                    switch_gradient_offset = true;
                }
                break;
        }
    }
}

// CLEAR THE INTERVAL THAT CALLS "GradientFluctuationAnimationImplementation" FUNCTION AT A CERTAIN INTERVAL
export async function GradientFluctuationAnimationCancellation() {
    if (gradient_fluctuation_interval !== undefined) {
        await clearInterval(gradient_fluctuation_interval);
    }
}

// SET THE "GradientFluctuationAnimationImplementation" FUNCTION TO BE CALLED AT A CERTAIN INTERVAL
export async function GradientFluctuationAnimation(element_id, initial_gradient, final_gradient, interval) {
    current_gradient = initial_gradient;
    gradient_fluctuation_interval = await setInterval(async () => { await window.requestAnimationFrame(async() => { await GradientFluctuationAnimationImplementation(element_id, initial_gradient, final_gradient); }); }, interval);
}

// [ END ]














// ELEMENT EXPANSION ANIMATION
//
// [ BEGIN ]
async function ExpansionAnimationImplementation(element_id, max_width, size_unit) {
    // GET THE HTML ELEMENT ON WHICH THE EXPANSION ANIMATION WILL BE APPLIED
    let element = document.getElementById(element_id);

    // IF THE HTML ELEMENT IS NOT NULL
    if (element !== null) {
        // IF THE CURRENT WIDTH COUNTER IS LESS THAN THE MAXIMUM WITH
        if (current_width < max_width) {
            // ASSIGN THE NEW WITH TO THE HTML ELEMENT
            element.style.width = current_width + size_unit;
        }
        else
        {
            await ClearExpansionAnimation();
        }
        current_width++;
    }
}

// CLEAR THE INTERVAL THAT CALLS "ExpansionAnimation" FUNCTION AT A CERTAIN INTERVAL
export async function ClearExpansionAnimation() {
    if (expansion_animation_interval !== undefined) {
        await clearInterval(expansion_animation_interval);
    }
}

// SET THE "ExpansionAnimation" FUNCTION TO BE CALLED AT A CERTAIN INTERVAL
export async function ExpansionAnimation(element_id, max_width, interval, size_unit) {
    current_width = 0;
    expansion_animation_interval = await setInterval(async () => { await window.requestAnimationFrame(async () => { await ExpansionAnimationImplementation(element_id, max_width, size_unit); }); }, interval);
}

// [ END ]














// BACKGROUND IMAGE SIZING
//
// [ BEGIN ]

async function Background_Image_Sizing() {
    // GET THE HTML ELEMENT ON WHICH THE SIZING ANIMATION WILL BE APPLIED
    let background = document.getElementById("background_image");

    // GET THE HEIGHT HTML ELEMENT WHICH THE ELEMENT ABOVE WILL BE BOUND
    let main_structure_div = document.getElementById("main_body").offsetHeight;

    // IF THE BACKGROUND HTML ELEMENT IS NOT NULL
    if (background !== null) {
        // IF THE HEIGHT VALUE OF THE ELEMENT TO BE BOUND IS NOT NULL
        if (main_structure_div !== null) {
            // SET THE HEIGHT OF THE BACKGROUND ELEMENT AS THE HEIGHT OF THE BOUND ELEMENT
            background.style.height = main_structure_div + "px";
        }
    }
}

// CLEAR THE INTERVAL THAT CALLS "Set_Background_Image_Sizing" FUNCTION AT A CERTAIN INTERVAL
export async function Clear_Background_Image_Sizing() {
    if (background_image_sizing !== undefined) {
        await clearInterval(background_image_sizing);
    }
}

// SET THE "Set_Background_Image_Sizing" FUNCTION TO BE CALLED AT A CERTAIN INTERVAL
export async function Set_Background_Image_Sizing() {
    background_image_sizing = await setInterval(async () => { await window.requestAnimationFrame(async () => { await Background_Image_Sizing(); }); }, 1);
}

// [ END ]














// HOME PAGE ELEMENT RESIZING
//
// [ START ]

async function Resize_Home_Page_Elements() {
    // GET THE HTML ELEMENTS OF THE HOME PAGE CONTAINER
    let main_page_button_1 = document.getElementById("main_page_button_1");
    let main_page_button_2 = document.getElementById("main_page_button_2");
    let content_block_1 = document.getElementById("content_block_1");
    let content_block_2 = document.getElementById("content_block_2");
    let index_page_jumbotron = document.getElementById("index_page_jumbotron");

    // IF NONE OF THE HTML ELEMENTS OF THE HOME PAGE CONTAINER ARE NULL
    if (content_block_1 !== null) {
        if (content_block_2 !== null) {
            if (index_page_jumbotron !== null) {
                if (main_page_button_1 !== null) {
                    if (main_page_button_2 !== null) {

                        // IF THE HOME PAGE CONTAINER HAS A WIDTH LESS OR EQUAL THAN 1150px
                        if (index_page_jumbotron.offsetWidth <= 1150) {

                            // MAKE THE WIDTH OF THE CONTAINERS THAT HOLD THE 2 SECTIONS OF THE HOME PAGE CONTAINER
                            // HAVE THE WIDTH EQUAL WITH THE HOME PAGE CONTAINER
                            content_block_1.style.width = "100%";
                            content_block_2.style.width = "100%";

                            // MAKE THE BUTTONS WITHIN THE HOME PAGE CONTAINER HAVE A 12vh HEIGHT
                            main_page_button_1.style.height = "12vh";
                            main_page_button_2.style.height = "12vh";

                            // MAKE THE TOP MARGIN OF THE HOME PAGE CONTAINER 20px
                            index_page_jumbotron.style.marginTop = "20px";

                        }
                        // IF THE HOME PAGE CONTAINER HAS A WIDTH GREATER THAN 1150px
                        else {

                            // MAKE THE WIDTH OF THE CONTAINERS THAT HOLD THE 2 SECTIONS OF THE HOME PAGE CONTAINER
                            // HAVE THE WIDTH EQUAL WITH 49.8% OF THE HOME PAGE CONTAINER'S WIDTH
                            content_block_1.style.width = "49.8%";
                            content_block_2.style.width = "49.8%";

                             // MAKE THE BUTTONS WITHIN THE HOME PAGE CONTAINER HAVE A 35vh HEIGHT
                            main_page_button_1.style.height = "35vh";
                            main_page_button_2.style.height = "35vh";

                            // MAKE THE TOP MARGIN OF THE HOME PAGE CONTAINER 110px
                            index_page_jumbotron.style.marginTop = "110px";
                        }
                    }
                }
            }
        }
    }
}

// CLEAR THE INTERVAL THAT CALLS "Set_Resize_Home_Page_Elements" FUNCTION AT A CERTAIN INTERVAL
export async function Clear_Resize_Home_Page_Elements() {
    if (home_page_elements_resizing !== undefined) {
        await clearInterval(home_page_elements_resizing);
    }
}

// SET THE "Set_Resize_Home_Page_Elements" FUNCTION TO BE CALLED AT A CERTAIN INTERVAL
export async function Set_Resize_Home_Page_Elements() {
    home_page_elements_resizing = await setInterval(async () => { await window.requestAnimationFrame(async () => { Resize_Home_Page_Elements(); }); }, 100);
}

// [ END ]














// RESIZE CONTACTS PAGE ELEMENTS
//
// [ START ]

async function Resize_Contacts_Page_Elemets() {
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

export async function Clear_Resize_Contacts_Page_Elemets() {
    if (contacts_page_elements_resizing !== null) {
        await clearInterval(contacts_page_elements_resizing);
    }
}

export async function Set_Resize_Contacts_Page_Elemets() {
    contacts_page_elements_resizing = await setInterval(async () => { await window.requestAnimationFrame(async () => { Resize_Contacts_Page_Elemets() }); }, 100)
}

// [ END ]














// HOME PAGE BUTTON HOVER
//
// [ START ]

async function Button_Focus_Effect(element_id) {
    // GET THE SELECTED HTML BUTTON ELEMENT OF THE HOME PAGE CONTAINER
    let button_cover = document.getElementById(element_id);

    // IF THE SELECTED HTML BUTTON ELEMENT IS NOT NULL
    if (home_page_button_focus !== undefined) {

        // IF THE SELECTED HTML BUTTON ELEMENT'S BACKGROUND TRANSPARENCY IS ABOVE 30%
        if (current_alpha > 0.3) {

            // DECREASE THE TRANSPARENCY BY 1%;
            current_alpha = current_alpha - 0.01;
            try {
                // SET THE TRANSPARENCY
                button_cover.style.background = "linear-gradient(to right, rgba(61, 57, 50, " + current_alpha + "), rgba(91, 90, 90, " + current_alpha + "))";
            }
            catch {
                await clearInterval(home_page_button_focus);
            }
        }
    }
}

// CLEAR THE "Set_Button_Focus_Effect" FUNCTION TO BE CALLED AT A CERTAIN INTERVAL
export async function Clear_Set_Button_Focus_Effect(element_id) {
    if (home_page_button_focus !== undefined) {
        await clearInterval(home_page_button_focus);
    }
    let button_cover = document.getElementById(element_id);
    if (button_cover != null) {
        button_cover.style.background = "linear-gradient(to right, rgba(61, 57, 50, 0.55), rgba(91, 90, 90, 0.55))";
    }
}

// SET THE "Set_Button_Focus_Effect" FUNCTION TO BE CALLED AT A CERTAIN INTERVAL
export async function Set_Button_Focus_Effect(element_id) {
    current_alpha = 0.55;
    home_page_button_focus = await setInterval(async () => { await window.requestAnimationFrame(async () => { Button_Focus_Effect(element_id); }); }, 10);
}

// [ END ]














// AUTH GRADIENT FLUCTUATION ANIMATION
//
//

async function AuthGradientFluctuation() {
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

export async function ClearAuthGradientFluctuation() {
    if (auth_gradient_fluctuation_interval != null) {
        await clearInterval(auth_gradient_fluctuation_interval);
    }
}

export async function SetAuthGradientFluctuation() {
    current_auth_gradient = 60;
    auth_gradient_fluctuation_interval = await setInterval(async () => { await window.requestAnimationFrame(async () => { AuthGradientFluctuation(); }); }, 20)
}

// [ END ]














// BOOKING PAGE ELEMENTS CONTAINER RESIZE
//
// [ START ]

async function BookingElementsContainerResize() {
    // GET THE HALLS CONATINER ELEMENTS BAR HTML ELEMENT
    let halls_container = document.getElementById("halls_container");

    // GET THE HALLS NAVIGATION BAR HTML ELEMENT
    let halls_nav = document.getElementById("halls_nav");

    // GET THE MAIN NAVIGATION BAR HTML ELEMENT
    let main_nav = document.getElementById("main_nav");

    // IF NONE OF THE HTML ELEMENTS ARE NULL
    if (halls_container != null) {
        if (halls_nav != null) {
            if (main_nav != null) {
                // SET THE HEIGHT OF THE HALLS CONTAINER AS THE ( WINDOW HEIGHT - THE SUM OF THE HEIGHT OF THE MAIN NAVBAR AND THE LOCATION SELECTION NAVBAR )
                halls_container.style.height = (window.innerHeight - (main_nav.offsetHeight + halls_nav.offsetHeight)) + "px";
            }
        }
    }
}

// CLEAR THE BookingElementsContainerResize INTERVAL
export async function ClearBookingElementsContainerResize() {
    if (booking_elements_container_resize != null) {
        await clearInterval(booking_elements_container_resize);
    }
}

// SET THE METHOD BookingElementsContainerResize TO BE CALLED AT A CERTAIN INTERVAL
export async function SetBookingElementsContainerResize() {
    booking_elements_container_resize = await setInterval(async () => { await window.requestAnimationFrame(async () => { BookingElementsContainerResize(); }); }, 20)
}

// [ END ]














// BOOKING PAGE ELEMENT RESIZE
//
// [ START ]

async function BookingElementResize() {
    // GET THE HALLS CONTAINER HTML ELEMENT
    let halls_container = document.getElementById("halls_container");

    // IF THE HALLS CONTAINER HTML ELEMENT IS NOT NULL
    if (halls_container != null) {

        // GET ALL HTML ELEMENTS WITH THE CSS CLASS "image_element_section" AND "details_element_section"
        let hall_element_inner = document.getElementsByClassName("hall_element_inner");
        let details_elements = document.getElementsByClassName("details_element_section");
        let hall_elements = document.getElementsByClassName("hall_element");

        for (let i = 0; i < hall_elements.length; i++) {
            let hall_element = hall_elements[i];

            // IF THE WIDTH OF THE HALLS CONTAINER IS LESS THAN 1400px
            if (window.screen.width < 350) {

                if (hall_element.style.width != "99.9%") {
                    hall_element.style.width = "99.9%";
                }
            }
            else {
                if (hall_element.style.width = "90%") {
                    hall_element.style.width = "90%";
                }
            }
        }


        for (let i = 0; i < hall_element_inner.length; i++) {
            let img_section = hall_element_inner[i].children[0];
            let det_elements = hall_element_inner[i].children[1];


            // IF THE WIDTH OF THE HALLS CONTAINER IS LESS THAN 1400px
            if (halls_container.offsetWidth < 1300) {
                if (img_section.style.height != "calc(200px + 10vw)") {
                    img_section.style.height = "calc(200px + 10vw)";
                }

                if (img_section.style.width != "100%") {
                    // SET EACH ELEMENT'S WIDTH EQUAL TO THE WIDTH OF THE HALLS CONTAINER
                    img_section.style.width = "100%";
                }
            }
            else {
                if (det_elements != null) {
                    img_section.style.height = det_elements.offsetHeight + "px";
                }

                // SET EACH ELEMENT'S WIDTH EQUAL TO 49.8% OF THE WIDTH OF THE HALLS CONTAINER
                if (img_section.style.width != "60%") {
                    img_section.style.width = "60%";
                }
            }
        }



        // LOOP EACH HTML ELEMENT IN THE "details_elements" LIST
        for (let i = 0; i < details_elements.length; i++) {

            // IF THE WIDTH OF THE HALLS CONTAINER IS LESS THAN 1400px
            if (halls_container.offsetWidth < 1300) {

                if (details_elements[i].style.width != "100%") {
                    // SET EACH ELEMENT'S WIDTH EQUAL TO THE WIDTH OF THE HALLS CONTAINER
                    details_elements[i].style.width = "100%";
                }

                if (details_elements[i].style.height != "fit-content") {
                    // SET THE HEIGHT OF EACH ELEMENT TO FIT ITS CONTENT
                    details_elements[i].style.height = "fit-content";
                }
            }
            // IF THE WIDTH OF THE HALLS CONTAINER IS MORE THAN OR EQUAL TO 1400px
            else {

                if (details_elements[i].style.width != "38%") {
                    // SET EACH ELEMENT'S WIDTH EQUAL TO 49.8% OF THE WIDTH OF THE HALLS CONTAINER
                    details_elements[i].style.width = "38%";
                }

                if (details_elements[i].style.height != "fit-content") {
                    // SET THE HEIGHT OF EACH ELEMENT TO THE SUM OF 200px AND 10vw
                    details_elements[i].style.height = "fit-content";
                }
            }
        }

    }
}
export async function ClearSetBookingElementResize() {
    if (booking_elements_container_resize != null) {
        await clearInterval(booking_elements_resize);
    }
}

export async function SetBookingElementResize() {
    booking_elements_resize = await setInterval(async () => { await window.requestAnimationFrame(async () => { await BookingElementResize(); }); }, 1)
}

// [ END ]