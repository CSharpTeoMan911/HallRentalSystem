var expansion_animation_interval = undefined;
let current_width = 0;

async function ExpansionAnimationImplementation(element_id, max_width, size_unit) {
    let element = document.getElementById(element_id);

    if (current_width < max_width) {
        element.style.width = current_width + size_unit;
    }
    else {
        console.log("Cleared");
        await clearInterval(expansion_animation_interval);
    }

    console.log(current_width);
    current_width++;
}

export async function ExpansionAnimation(element_id, max_width, interval, size_unit) {
    expansion_animation_interval = await setInterval(async () => { await ExpansionAnimationImplementation(element_id, max_width, size_unit) }, interval);
}