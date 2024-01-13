export function initLocationMap() {
    const location = { lat: 51.502950570242376, lng: - 0.1183665856041398 };

    const map = new google.maps.Map(document.getElementById("location_map"), {
        zoom: 15,
        center: location,
    });

    new google.maps.Marker({
        position: location,
        map,
    });
}