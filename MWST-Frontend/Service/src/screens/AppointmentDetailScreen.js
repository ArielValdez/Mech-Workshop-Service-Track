import { useEffect, useState } from "react"
import { View, StyleSheet, ScrollView, Text, Image } from "react-native"
import { MaterialIcons } from "@expo/vector-icons"
import theme from "../Theme"
import CustomText from "../components/CustomText"
import CustomButton from "../components/CustomButton"
import { getEmptyAppointment } from "../services/AppointmentsService"
import { getWorkshop, getEmptyWorkshop } from "../services/WorkshopService"
import LineBreak from "../components/LineBreak"
import WorkshopImg from "../../assets/WorkshopImg.jpg"

const AppointmentDetailScreen = ({ route }) => {
    const [ service, setService ] = useState(getEmptyAppointment())
    const [ workshop, setWorkshop ] = useState(getEmptyWorkshop())

    useEffect(() => {
        setService(route.params.service)
        getWorkshop(route.params.service.workshop_id)
            .then(workshop => setWorkshop(workshop))
            .catch(err => console.log(err))
    }, [])

    return (
       <ScrollView style={styles.container}>
        {/* 
            <View style={styles.dataRow}>
                <MaterialIcons name='car-repair' size={75} />
                <View style={{ flexShrink: 1, marginLeft: 5 }}>
                    <View style={styles.serviceData}>
                        <CustomText type="Medium">Service type: </CustomText>
                        <CustomText>{service.serviceType}</CustomText>
                    </View>
                    <View style={styles.serviceData}>
                        <CustomText type="Medium">Description: </CustomText>
                        <CustomText>{service.description}</CustomText>
                    </View>
                    <View style={styles.serviceData}>
                        <CustomText type="Medium">State: </CustomText>
                        <CustomText>{service.state}</CustomText>
                    </View>
                    <View style={styles.serviceData}>
                        <CustomText>
                            <CustomText type="Medium">Mensaje del asesor: </CustomText>
                            <CustomText>{service.state_description}</CustomText>
                        </CustomText>
                    </View>
                </View>
            </View>
            <View style={styles.secondBlock}>
                <CustomText type='Bold'>{service.expectedAt}</CustomText>
            </View>
        */}
        <Image 
            style={styles.workshopImg}
            source={WorkshopImg}
            resizeMode='stretch'
        />
        <View style={styles.infoContainer}>
            <CustomText style={styles.workshopName} type="Bold">Taller {workshop.name}</CustomText>
            <CustomText style={styles.title} type="Medium">Dirección del taller</CustomText>
            <View style={styles.shadowContainer}>
                <View style={styles.floatingContainer} >
                    <CustomText>{workshop.address}</CustomText>
                    <CustomText>Santo Domingo, República Dominicana</CustomText>
                </View>
            </View>
            <CustomText style={styles.title} type="Medium">Horario</CustomText>
            <View style={styles.shadowContainer}>
                <View style={styles.floatingContainer}>
                    <View style={styles.scheduleRow}>
                        <CustomText>{workshop.openAt}-{workshop.closedAt}</CustomText>
                    </View>
                    <CustomText>Lunes a Viernes</CustomText>
                </View>
            </View>
            <CustomText style={styles.title} type="Medium">Detalles del servicio</CustomText>
            <View style={styles.shadowContainer}>
                <View style={styles.floatingContainer}>
                    <CustomText>{service.state}</CustomText>
                    <CustomText>{service.state_description}</CustomText>
                    <CustomText>{service.serviceType}</CustomText>
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
    // dataRow: {
    //     flex: 1,
    //     flexDirection: 'row',
    //     padding: 25, paddingVertical: 35,
    //     backgroundColor: theme.colors.primary,
    // },
    // serviceData: {
    //     flexDirection: 'row',
    //     marginBottom: 5 
    // },
    // secondBlock: {
    //     padding: 10,
    //     alignItems: 'center',
    // }
    title: {
        marginLeft: 10,
        marginVertical: 10,
    },
    scheduleRow: {
        flexDirection: 'row'
    },
})

export default AppointmentDetailScreen