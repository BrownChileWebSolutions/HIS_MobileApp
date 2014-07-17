var map;
var geocoder;
var Zoom;
var markerSet = [];
function InitializeMap() {
    Zoom = parseInt($('#zoomLevel').val());
    var latlng = new google.maps.LatLng(39.5500507, -105.78206740000002);
    var mapOptions =
    {
        zoom: Zoom,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true
    };
    map = new google.maps.Map(document.getElementById("divMap"), mapOptions);
}
function ShowLocation(lat, long) {
    var url = "/Map/Hotel";
    $.get(url, { Latitude: lat, Longitude: long }, function (data) {       
        var mapOptions = {
            center: new google.maps.LatLng(lat, long),
            zoom: 15,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        CleanMarker();
        var myLatlng = new google.maps.LatLng(lat, long);
        var iconBase = 'images/';
        var marker = new google.maps.Marker({
            position: myLatlng,
            title: "Current Location",
            icon: iconBase + 'map_marker.png'
        });
        marker.setMap(map);
        map.setCenter(myLatlng);
        markerSet.push(marker);
        var infowindow = new google.maps.InfoWindow();
        infowindow.open(map, marker);
        if (data.length != 0) {
            for (var i = 0; i < data.length; i++) {


                var myLatlng = new google.maps.LatLng(data[i].Latitude, data[i].Longitude);
                var contentString = '<div id="content">' + '<div id="siteNotice">' + '</div>' + data[i].Name + '<div id="bodyContent">' + '<p>' + data[i].Description + '</p>' +
                                                                        '<p>' + data[i].Address + '</p>' +
                                                                       '</div>';

                var infowindow = new google.maps.InfoWindow({
                    content: contentString
                });
                var iconBase = 'images/';
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data[i].Name,
                    icon: iconBase + 'red_map_marker.png'
                });
                markerSet.push(marker);
                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        var contentString = '<div id="content1">' + '<div id="divname" style="font-weight:bold;">' + data[i].Name + '</div><div id="bodyContent1">' + '<p>' + data[i].Description + '</p>' +
                                                                         '<div id="divaddress" style="font-weight:bold;"><p>' + data[i].Address + '</p></div>' +
                                                                        '</div>';
                        infowindow.setContent(contentString);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
            }
        }
        else {

        }
    });
}
function showPosition(position) {

    var lat = position.coords.latitude;
    var long = position.coords.longitude;
    ShowLocation(lat, long);
}
function showError(error) {
    if (error.code == 1) {
        alert("User denied the request for Geolocation.");
    }
    else if (error.code == 2) {
        alert("Location information is unavailable.");
    }
    else if (error.code == 3) {
        alert("The request to get user location timed out.");
    }
    else {
        alert("An unknown error occurred.");
    }
}
function CleanMarker() {
    for (var i = 0; i < markerSet.length ; i++) {
        markerSet[i].setMap(null);
    }
    markerSet = [];
}
$(document).ready(function () {

    InitializeMap();

    var input = (document.getElementById('pac-input'));
    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
    var autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.bindTo('bounds', map);

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, showError);
    }
    else {
        alert('It seems like Geolocation, which is required for this page, is not enabled in your browser.');
    }
    google.maps.event.addListener(autocomplete, 'place_changed', function () {
        var place = autocomplete.getPlace();
        var lat = place.geometry.location.lat();
        var long = place.geometry.location.lng();
        ShowLocation(lat, long);
    });
    $("#imgcurrentlocation").click(function () {
        document.getElementById('pac-input').value = "";
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition, showError);
        }
        else {
            alert('It seems like Geolocation, which is required for this page, is not enabled in your browser.');
        }
    });
})