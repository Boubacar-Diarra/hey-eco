let latlng = null;
let map;
window.createMap = () => {
    let container = L.DomUtil.get('map');
    if (container != null) {
        container._leaflet_id = null;
    }

    map = L.map("map").setView([12.6481, -8.0008], 13);
    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoiYm91YmFjYXItZGlhcnJhIiwiYSI6ImNraml3M2pmZDNyenoycHJ1aDZxMHUxdXgifQ.nPfFbXfF4zTyMuqfCtLZBw', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: 'your.mapbox.access.token'
    }).addTo(map);

    setTimeout(function () {
        map.invalidateSize();
    }, 1000);

    let circle = null;

    map.on("click", (ev) => {
        latlng = [ev.latlng.lat, ev.latlng.lng];
        if (circle != null) {
            map.removeLayer(circle)
        }
        /* circle = L.circle(ev.latlng, {
             color: '#0F5AAB',
             fillColor: '#153093',
             fillOpacity: 1,
             radius: 500,
         }).addTo(map);*/
        circle = L.marker(ev.latlng).addTo(map);

    })
    //document.getElementById("map").style.height = "300px"
}
window.CreateMapForPost = (mapId, lat, lng) => {
    //alert(mapId)
    let container = L.DomUtil.get(mapId);
    if (container != null) {
        container._leaflet_id = null;
    }
    let map = L.map(mapId).setView([lat, lng], 13);
    L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoiYm91YmFjYXItZGlhcnJhIiwiYSI6ImNraml3M2pmZDNyenoycHJ1aDZxMHUxdXgifQ.nPfFbXfF4zTyMuqfCtLZBw', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox/streets-v11',
        tileSize: 512,
        zoomOffset: -1,
        accessToken: 'your.mapbox.access.token'
    }).addTo(map);
    setTimeout(function () {
        map.invalidateSize();
    }, 1000);
    let circle = L.circle([lat, lng], {
        color: '#0F5AAB',
        fillColor: '#153093',
        fillOpacity: 0.5,
        radius: 500
    }).addTo(map);
}
window.getLatLng = () => {
    return latlng;
}