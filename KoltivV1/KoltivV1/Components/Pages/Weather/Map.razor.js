var dotNetHelper;
var map;

export var mapFunctions = {

    setDotNetHelper: async function(value) {
        dotNetHelper = value;
    },

    initMap: async (latitude, longitude, zoom) => {
        
        const { Map } = await google.maps.importLibrary("maps");
        const myLatlng = { lat: latitude, lng: longitude };
        map = new google.maps.Map(document.getElementById("map"), {
            zoom: zoom,
            center: myLatlng,
        });
        
        let infoWindow = new google.maps.InfoWindow();

        infoWindow.open(map);
        
        map.addListener("click", async (mapsMouseEvent) => {

            if(mapFunctions.InfoWindow != null) mapFunctions.InfoWindow.close();            

            var jsCoords = mapsMouseEvent.latLng.toJSON();          

            await dotNetHelper.invokeMethodAsync('ReceiveNewGeolocation', jsCoords.lat, jsCoords.lng);            

        });      

    },

    InfoWindow : null,
    
    ShowNonUSAddressMsg: async (latitude, longitude) => {
        
        const myLatlng = { lat: latitude, lng: longitude };

        mapFunctions.InfoWindow = new google.maps.InfoWindow({
            position: myLatlng,
        });

        mapFunctions.InfoWindow.setHeaderContent('ERROR!');
        mapFunctions.InfoWindow.setContent(
            'Weather information is available ONLY on US Territories!'
        );
        mapFunctions.InfoWindow.open(map);

    },

    IsUnitedStatesAddress: (latitude, longitude) => {
    
        const myLatlng = { lat: latitude, lng: longitude };

        return new Promise((resolve, reject) => {

            var geocoder = new google.maps.Geocoder();

            geocoder.geocode({ location: myLatlng }, (results, status) => {
                if (status === "OK") {

                    var searchResult = results.some(result => result.formatted_address == 'United States');

                    resolve(searchResult);

                } 
            });

        });        

    }

}; 