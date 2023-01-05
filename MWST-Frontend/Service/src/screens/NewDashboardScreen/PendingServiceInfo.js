import { View, StyleSheet } from "react-native"
import CustomText from "../../components/CustomText"
import theme from "../../Theme"
import { formatAsLongDate } from "../../utils/DateFormatting"

const PendingServiceInfo = () => {
    return (
        <View style={styles.container}>
            <CustomText>21 Dec 2020</CustomText>
            <CustomText style={{marginTop: 5, marginBottom: 15}} type="Medium">Dental Control</CustomText>
            <View style={styles.row}>
                <View style={styles.blueLine}></View>
                <View>
                    <CustomText type="Medium">Dr. Med. Roacher</CustomText>
                    <CustomText style={styles.grayText}>9 AM - 10 AM</CustomText>
                </View>
            </View>
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
        alignSelf: 'flex-start'
    },
    row: {
        flexDirection: 'row'
    },
    blueLine: {
        height: 40,
        width: 5,
        backgroundColor: theme.colors.lightPrimary,
        borderRadius: 2,
        marginRight: 5
    },
    grayText: {
        marginTop: 5,
        color:  theme.colors.gray
    }
})

export default PendingServiceInfo