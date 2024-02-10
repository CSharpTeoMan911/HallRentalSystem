export function initLocationMap() {
    // LATITUDE AND LOGITUTE OF THE LOCATION
    const location = { lat: 51.502950570242376, lng: - 0.1183665856041398 };

    // MAP OBJECT THAT HAS AS ITS CENTER LOCATION THE ABOVE MENTIONED LATITUDE AND LOGITUTE
    // AND THAT WILL RENDER THE MAP IN A SPECIFIED DIV
    const map = new google.maps.Map(document.getElementById("location_map"), {
        zoom: 15,
        center: location,
    });

    // MARKER OBJECT THAT WILL BE RENDERED WITHIN THE MAP AT THE ABOVE
    // SPECIFIED LATITUDE AND LOGITUDE
    new google.maps.Marker({
        position: location,
        map,
    });
}