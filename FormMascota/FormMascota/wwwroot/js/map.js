
var map;

function initialize(lat, lng, datos) {
    var latlng = new google.maps.LatLng(lat, lng);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var marker = new google.maps.Marker({
        position: latlng,
        title: "Mascota - " + datos
    });

    map = new google.maps.Map(document.getElementById("map"), options);
    marker.setMap(map);
}

