import { useEffect, useState } from "react"
import { useTranslation } from "react-i18next"
import { StyleSheet } from "react-native"
import MapView, { Callout, Marker } from "react-native-maps"
import CustomText from "../../components/CustomText"
import theme from "../../Theme"
import * as Location from "expo-location"
import { getAllWorkshops } from "../../services/WorkshopService"

const WorkshopsMarkerScreen = () => {
    const [ userLocation, setUserLocation ] = useState()
    const [ mapRegion, setMapRegion ] = useState({
        latitude: 18.467191,
        longitude: -69.945969,
        latitudeDelta: 0.0300,
        longitudeDelta: 0.0200,
    })
    const [ workshops, setWorkshops ] = useState([])
    const { t, i18n } = useTranslation()

    useEffect(() => {
        getAllWorkshops()
            .then(workshops => setWorkshops(workshops))

        Location.getForegroundPermissionsAsync()
            .then(response => {
                if (response.granted) {
                    updateUserLocation()
                }
                else {
                    Location.requestForegroundPermissionsAsync()
                        .then(response => {
                            if (response.granted) {
                                updateUserLocation()
                            } 
                        })
                }
            })
    }, [])
    
    const updateUserLocation = async () => {
        Location.getCurrentPositionAsync({}).then((location) => {
			setMapRegion({
				latitude: location.coords.latitude,
				longitude: location.coords.longitude,
				latitudeDelta: 0.03,
				longitudeDelta: 0.02,
			});
			setUserLocation(location.coords)
		})
    }

    return (
        <MapView 
            style={styles.map}
            region={mapRegion}
        >
            {userLocation && 
            <Marker
                coordinate={{
                    latitude: userLocation.latitude,
                    longitude: userLocation.longitude
                }}
                pinColor={theme.colors.lightPrimary}
            >
                <Callout>
                    <CustomText>{t('you')}</CustomText>
                </Callout>
            </Marker>
            }
            {workshops.map((workshop, index) => (
                <Marker
                key={index} 
                coordinate={{
                    latitude: workshop.latitude,
                    longitude: workshop.longitude
                }}
                >
                    <Callout>
                        <CustomText>{workshop.name}</CustomText>
                    </Callout>
                </Marker>
            ))}
        </MapView>
    )
}

const styles = StyleSheet.create({
    map: {
        height: '100%',
        width: '100%',
    }
})

export default WorkshopsMarkerScreen