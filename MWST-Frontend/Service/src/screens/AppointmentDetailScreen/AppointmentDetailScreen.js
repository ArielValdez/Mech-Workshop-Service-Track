import { useEffect, useState } from "react"
import { View, StyleSheet, ScrollView, Text, Image, Dimensions } from "react-native"
import theme from "../../Theme"
import CustomText from "../../components/CustomText"
import { getEmptyAppointment } from "../../services/AppointmentsService"
import { getWorkshop, getEmptyWorkshop } from "../../services/WorkshopService"
import WorkshopImg from "../../../assets/WorkshopImg.jpg"
import MapView, { Marker, Callout } from "react-native-maps"
import { useTranslation } from "react-i18next"
import { format } from "date-fns"

const AppointmentDetailScreen = ({ route }) => {
    const [ service, setService ] = useState(getEmptyAppointment())
    const [ workshop, setWorkshop ] = useState(getEmptyWorkshop())
    const [ isLoaded, setIsLoaded ] = useState(false)

    const { t, i18n } = useTranslation()

    useEffect(() => {
        setService(route.params.service)
        getWorkshop(route.params.service.workshopId)
            .then(workshop => {
                setWorkshop(workshop)
                setIsLoaded(true)
            })
            .catch(err => console.log(err))
    }, [])

    return (
       <ScrollView style={styles.container}>
        <Image 
            style={styles.workshopImg}
            source={WorkshopImg}
            resizeMode='stretch'
        />
        <View style={styles.infoContainer}>
            <CustomText style={styles.workshopName} type="Bold">Taller {workshop.name}</CustomText>
            <CustomText style={styles.title} type="Medium">{t('workshopAddress')}</CustomText>
            <View style={styles.shadowContainer}>
                <View style={styles.floatingContainer} >
                    <CustomText>{workshop.address}</CustomText>
                    <CustomText>{t('country')}</CustomText>
                </View>
            </View>
            { workshop.latitude &&
            <MapView 
                style={styles.map}
                initialRegion={{
                    latitude: workshop.latitude,
                    longitude: workshop.longitude,
                    latitudeDelta: 0.0200,
                    longitudeDelta: 0.0200,
                }}
            >
                <Marker
                    coordinate={{
                        latitude: workshop.latitude,
                        longitude: workshop.longitude  
                    }}
                >
                    <Callout>
                        <CustomText>{workshop.name}</CustomText>
                    </Callout>
                </Marker>
            </MapView>
            }           
            <CustomText style={styles.title} type="Medium">{t('serviceSchedule')}</CustomText>
            <View style={styles.shadowContainer}>
                <View style={styles.floatingContainer}>
                    <View style={styles.scheduleRow}>
                        <CustomText>
                            { isLoaded && 
                                format(new Date(workshop.openAt), 'h:mm aaa') + ' - ' + format(new Date(workshop.closedAt), 'h:mm aaa')
                            }
                        </CustomText>
                    </View>
                    <CustomText>{t('mondayThroughFriday')}</CustomText>
                </View>
            </View>
            <CustomText style={styles.title} type="Medium">{t('serviceDetails')}</CustomText>
            <View style={styles.shadowContainer}>
                <View style={styles.floatingContainer}>
                    <CustomText>{t('state') + service.state}</CustomText>
                    <CustomText>{service.stateDescription}</CustomText>
                    <CustomText>{t('type') + service.serviceType}</CustomText>
                    <CustomText>{service.description}</CustomText>
                </View>
            </View>
        </View>
       </ScrollView> 
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.bgColor
    },
    infoContainer: {
        padding: 10
    },
    workshopName: {
        alignSelf: 'center',
        marginVertical: 10,
        fontSize: 18
    },
    workshopImg: {
        height: 200,
        width: '100%'
    },
    shadowContainer: {
        borderRadius: 5,
        backgroundColor: 'transparent',
        shadowColor: "#000",
        shadowOffset: {
            width: 0,
            height: 3,
        },
        shadowOpacity: 0.27,
        shadowRadius: 4.65,
        
        elevation: 6,
    },
    floatingContainer: {
        padding: 10,
        borderRadius: 5,
        backgroundColor: theme.colors.white
    },
    title: {
        marginLeft: 10,
        marginVertical: 10,
    },
    scheduleRow: {
        flexDirection: 'row'
    },
    map: {
        height: Dimensions.get('window').height * 0.3,
        width: Dimensions.get('window').width * 0.9,
        marginTop: 10, marginLeft: 10,
    },
})

export default AppointmentDetailScreen