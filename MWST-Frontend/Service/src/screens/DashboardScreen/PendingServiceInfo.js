import { useTranslation } from "react-i18next"
import { View, StyleSheet } from "react-native"
import CustomText from "../../components/CustomText"
import theme from "../../Theme"
import { formatAsLongDate } from "../../utils/DateFormatting"
import { format } from "date-fns"

const PendingServiceInfo = ({ service }) => {
    const { t, i18n } = useTranslation()

    const printFormattedHours = () => {
        const date = new Date(service.startedAt)
        const date2 = new Date(service.expectedAt)
        const formattedTimeString = format(date, 'HH:mm') + ' - ' + format(date2, 'HH:mm')
        return formattedTimeString
    }

    if (service) {
        return (
            <View style={styles.container}>
                <CustomText style={{color: theme.colors.warningRed}}>{format(new Date(service.startedAt), 'yyyy-MM-dd')}</CustomText>
                <CustomText style={{marginTop: 5, marginBottom: 15}} type="Medium">{service.serviceType}</CustomText>
                <View style={styles.row}>
                    <View style={styles.blueLine}></View>
                    <View>
                        <CustomText style={styles.workshopName} type="Medium">{service.workshop.name}</CustomText>
                        <CustomText style={styles.grayText}>{printFormattedHours()}</CustomText>
                    </View>
                </View>
            </View>
        )
    }

    return (
		<View style={[styles.container, {paddingVertical: 50, paddingHorizontal: 30}]}>
			<CustomText>{t('noPendingServices')}</CustomText>
		</View>
	)
}

const styles = StyleSheet.create({
    container: {
        padding: 25,
        borderRadius: 15,
        borderColor: 'rgba(0, 0, 0, 0.45)',
        borderWidth: 1,
        marginHorizontal: 10,
        alignSelf: 'center',
        maxWidth: 225,
    },
    row: {
        flexDirection: 'row'
    },
    blueLine: {
        height: 60,
        width: 5,
        backgroundColor: theme.colors.lightPrimary,
        borderRadius: 2,
        marginRight: 5
    },
    workshopName: {
        
    },
    grayText: {
        marginTop: 5,
        color:  theme.colors.gray
    },
})

export default PendingServiceInfo