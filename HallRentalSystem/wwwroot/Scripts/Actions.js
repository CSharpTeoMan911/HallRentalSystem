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

    console.log(return_values);
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