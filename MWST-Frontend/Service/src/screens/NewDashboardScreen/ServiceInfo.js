import { View, StyleSheet } from "react-native"
import CustomText from "../../components/CustomText"
import { Entypo } from "@expo/vector-icons"
import theme from "../../Theme"
import { formatAsLongDate, diffHours } from "../../utils/DateFormatting"
import { useTranslation } from "react-i18next"

const ServiceInfo = ({ service }) => {
    const { t, i18n } = useTranslation()

    const printTime = () => {
        const diff = diffHours(new Date(service.finishedAt), new Date(service.startedAt))
        if (diff < 24) {
            return diff + ' hours ago'
        } 
        else {
            return formatAsLongDate(service.finishedAt)
        }
    }

    if (service) {
        return (
            <View style={styles.container}>
                <Entypo style={styles.icon} name="info-with-circle" size={40} />
                <View style={styles.infoContainer}>
                    <CustomText type="Medium">{service.serviceType}</CustomText>
                    <CustomText style={styles.grayText}>{printTime()}</CustomText>
                </View>
                <CustomText style={styles.price}>$100.00</CustomText>
            </View>
        )
    }
    else {
        return (
            <CustomText style={styles.noService}>No existe ningún servicio en el historial</CustomText>
        )
    }
}

const styles = StyleSheet.create({
    container: {
        flexDirection: 'row',
        padding: 10,
    },
    icon: {
        flex: 1,
    },
    infoContainer: {
        flex: 3,
        justifyContent: 'center'
    },
    grayText: {
        color: theme.colors.gray
    },
    price: {
        flex: 1,
        textAlignVertical: 'center',
    },
    noService: {
        padding: 30,
        textAlign: 'center'
    },
})

export default ServiceInfo