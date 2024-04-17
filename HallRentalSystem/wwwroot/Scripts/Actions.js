export function GetLoginEmailAndPassword(email_id, password_id) {
    let _email_id = document.getElementById(email_id);
    let _password_id = document.getElementById(password_id);
    let return_values = [];

    if (_email_id !== null) {
        if (_password_id !== null) {
            return_values.push(_email_id.value);
            return_values.push(_password_id.value);
        }
    }

    return return_values;
}

export function GetRegisterEmailAndPassword(email_id, password_id, re_password_id) {
    let _email_id = document.getElementById(email_id);
    let _password_id = document.getElementById(password_id);
    let _re_password_id = document.getElementById(re_password_id);
    let return_values = [];

    if (_email_id !== null) {
        if (_password_id !== null) {
            if (_re_password_id !== null) {
                if (_password_id.value === _re_password_id.value) {
                    return_values.push(_email_id.value);
                    return_values.push(_re_password_id.value);
                }
            }
        }
    }

    return return_values;
}

export function SetElementImage(element_id, image) {
    let element = document.getElementById(element_id);
    if (element != null) {
        element.style.backgroundImage = "url(\"" + image +"\")";
    }
}

export function AuthCache(key, option){
    switch(option)
    {
        case "Insert":
            window.localStorage.setItem("HallRental_Auth_Cache", key);
            break;
        case "Delete":
            window.localStorage.removeItem("HallRental_Auth_Cache");
            break;
        case "Get":
            return window.localStorage.getItem("HallRental_Auth_Cache");
    }
}


export function ChangeNavState() {
    let elements = document.getElementsByClassName("nav-link");

    for (let i = 0; i < elements.length; i++) {
        if (window.location.pathname !== "/sign-up" && window.location.pathname !== "/log-in") {
            if (elements[i].id === window.location.pathname) {
                elements[i].className = "nav-link active";
            }
            else {
                elements[i].className = "nav-link";
            }
        }
        else {
            if (elements[i].id === "/auth") {
                elements[i].className = "nav-link active";
            }
            else {
                elements[i].className = "nav-link";
            }
        }
    }
}

export function SetCurrentHallName(hall_name) {
    if (hall_name != null) {
        window.localStorage.setItem("Selected_Hall", hall_name);
    }
}


export function DebugWriteLine(value) {
    console.log(value);
}
