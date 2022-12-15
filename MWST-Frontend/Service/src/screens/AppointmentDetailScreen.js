import { useEffect, useState } from "react"
import { View, StyleSheet, ScrollView, Text } from "react-native"
import { MaterialIcons } from "@expo/vector-icons"
import theme from "../Theme"
import CustomText from "../components/CustomText"
import CustomButton from "../components/CustomButton"
import { getEmptyAppointment } from "../services/AppointmentsService"
import { getWorkshop } from "../services/WorkshopService"
import LineBreak from "../components/LineBreak"

const AppointmentDetailScreen = ({ route }) => {
    const [ service, setService ] = useState(getEmptyAppointment())
    const [ workshop, setWorkshop ] = useState()

    useEffect(() => {
        setService(route.params.service)
        getWorkshop(route.params.service.workshop_id)
            .then(workshop => setWorkshop(workshop))
            .catch(err => console.log(err))
    }, [])

    return (
       <ScrollView style={styles.container}>
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
       </ScrollView> 
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
    },
    dataRow: {
        flex: 1,
        flexDirection: 'row',
        padding: 25, paddingVertical: 35,
        backgroundColor: theme.colors.primary,
    },
    serviceData: {
        flexDirection: 'row',
        marginBottom: 5 
    },
    secondBlock: {
        padding: 10,
        alignItems: 'center',
    }
})

export default AppointmentDetailScreen