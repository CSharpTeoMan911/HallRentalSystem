export function initLocationMap() {
    const location = { lat: 51.502950570242376, lng: - 0.1183665856041398 };

    var latlng = new google.maps.LatLng(location);

    var options = {
        zoom: 14,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    new google.maps.Marker({
        position: location,
        map,
    });

    var map = new google.maps.Map(document.getElementById("location_map"), options);
}