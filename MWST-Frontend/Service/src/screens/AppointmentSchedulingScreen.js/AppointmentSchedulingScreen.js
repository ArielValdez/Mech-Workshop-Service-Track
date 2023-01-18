import React, { useState, useEffect } from "react"
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView, Modal, FlatList, Pressable} from 'react-native'
import DropDownPicker from "react-native-dropdown-picker"
import DateTimePicker from '@react-native-community/datetimepicker'
import { FontAwesome5, Entypo, AntDesign } from '@expo/vector-icons'
import { useTranslation } from "react-i18next";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import { useUser } from "../../context/UserContext";
import CustomButton from "../../components/CustomButton";
import CustomText from "../../components/CustomText";
import CustomInput from "../../components/Inputs/CustomInput";
import { getAllVehicles } from "../../services/VehicleService";
import { getAllWorkshops } from "../../services/WorkshopService";
import { createAppointment } from "../../services/AppointmentsService";
import theme from "../../Theme"
import { format, subHours } from "date-fns";

const appointmentTitleRegex = /[a-zA-Z]{3,}/
const appointmentTitleErrorMessage = 'Título de cita debe tener al menos 3 carácteres'

const AppointmentSchedulingScreen = ({ route }) => {
    const [ appointmentTitle, setAppointmentTitle ] = useState('')
    const [ showTimePicker, setShowTimePicker ] = useState(false)
    const [ selectedDateTime, setSelectedDateTime ] = useState(route.params.selectedDateTime)
    // Dropdown for vehicles
    const [ vehicles, setVehicles ] = useState([])
    const [ selectedVehicleId, setselectedVehicleId ] = useState(null)
    const [ openDropdown, setOpenDropdown ] = useState(false)
    // Dropdown for service type
    const [ services, setServices ] = useState([
        { label: 'Reparación', value: 'Reparation' },
        { label: 'Chequeo', value: 'Checkup' }
    ])
    const [ selectedServiceType, setSelectedServiceType ] = useState(null)
    const [ openServiceDropdown, setOpenServiceDropdown ] = useState(false)
    // Dropdown for workshops
    const [ workshops, setWorkshops ] = useState([])
    const [ selectedWorkshopId, setSelectedWorkshopId ] = useState(null)
    const [ openWorkshopDropdown, setOpenWorkshopDropdown ] = useState(false)

    const isFocused = useIsFocused()
    const [ user, setUser ] = useUser()
    const navigation = useNavigation()
    const { height, width } = useWindowDimensions()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        getAllVehicles(user.id)
            .then(vehicles => {
                setVehicles(vehicles)
            })
            .catch(err => console.log(err))
    
        getAllWorkshops()
            .then(workshops => setWorkshops(workshops))
            .catch(err => console.log(err))
    }, [])

    useEffect(() => {
        if (isFocused && route.params?.selectedWorkshop) {
            setSelectedWorkshopId(route.params.selectedWorkshop.id)
        }
    }, [isFocused])

    const onTimeChange = (event, selectedDate) => {
        // Must use subHouts to adjust the date returned by DateTimePicker because of
        // javascript default timezone
        const realDate = subHours(selectedDate, 4)
        console.log(selectedDate)
        setSelectedDateTime(selectedDate)
    }

    const onSchedulingPress = () => {
        if (appointmentTitle.length >= 3 && selectedDateTime && selectedVehicleId
            && selectedServiceType && selectedWorkshopId) {
            const formattedDate = format(selectedDateTime, "yyyy-MM-dd'T'HH:mm:ss")
            createAppointment(selectedServiceType, appointmentTitle, selectedVehicleId, formattedDate, user.id, selectedWorkshopId)
                .then(result => navigation.navigate('Appointments', { shouldRefresh: true }))
                .catch(err => console.log(err))
        }
        else {
            // Show alert or error modal
        } 
    }

    return (
		<View style={{flex: 1}}>
			<View style={styles.container}>
				<CustomText style={styles.title} type="Bold">{t("newAppointment")}</CustomText>
				<CustomInput
					value={appointmentTitle}
					setValue={setAppointmentTitle}
					placeholder="Título cita"
					pattern={appointmentTitleRegex}
					errorMessage={appointmentTitleErrorMessage}
				/>
                <View style={styles.clockRow}>
                    <CustomText style={styles.timeText} type="Medium">{format(selectedDateTime, 'h:mm aaa')}</CustomText>
                    <Pressable
                        style={styles.clockIcon}
                        onPress={() => setShowTimePicker(true)}
                    >
                        <FontAwesome5
                            name="clock"
                            size={35}
                            color={theme.colors.black}
                        />
                    </Pressable>
                </View>

				<DropDownPicker
					schema={{
						label: "plate",
						value: "id",
					}}
					placeholder={t("selectVehiclePlaceholder")}
					open={openDropdown}
					value={selectedVehicleId}
					items={vehicles}
					setOpen={setOpenDropdown}
					setValue={setselectedVehicleId}
					setItems={setVehicles}
					style={styles.dropdown}
					zIndex={1000}
				/>

				<DropDownPicker
					placeholder={t("selectServicePlaceholder")}
					open={openServiceDropdown}
					value={selectedServiceType}
					items={services}
					setOpen={setOpenServiceDropdown}
					setValue={setSelectedServiceType}
					setItems={setServices}
                    style={styles.dropdown}
					zIndex={500}
				/>

                <DropDownPicker 
                    schema={{
                        label: "name",
                        value: "id"
                    }}
                    placeholder={t('selectWorkshopPlaceholder')}
                    open={openWorkshopDropdown}
                    value={selectedWorkshopId}
                    items={workshops}
                    setOpen={setOpenWorkshopDropdown}
                    setValue={setSelectedWorkshopId}
                    setItems={setWorkshops}
                    style={styles.dropdown}
                    zIndex={400}
                    onOpen={() => {
                        navigation.navigate('WorkshopsMarker')
                    }}
                />

                <CustomButton
					text={t("schedule")}
                    marginVertical={20}
					onPress={() => {
						const regex = new RegExp(appointmentTitleRegex);
						if (regex.test(appointmentTitle)) {
							onSchedulingPress()
						}
					}}
				/>
			</View>
            {showTimePicker && (
				<DateTimePicker
					value={selectedDateTime}
					mode="time"
					onChange={(event, selectedDate) => {
						setShowTimePicker(false)
						onTimeChange(event, selectedDate)
					}}
				/>
			)}
		</View>
	)
}

const styles = StyleSheet.create({
    scrollContainer: {
    },
    container: {
        backgroundColor: theme.colors.bgColor,
        flex: 1,
        alignItems: 'center',
        padding: 20
    },
    view: {
        backgroundColor: theme.colors.white,
        width: '80%',
        borderRadius: 15,
        alignItems: 'center',
        padding: 20
    },
    title: {
        fontSize: 20,
        marginBottom: 20,
    },
    clockRow: {
        flexDirection: 'row',
        marginTop: 5,
        marginBottom: 10,
    },
    timeText: {
        flex: 1,
        textAlign: 'center',
        textAlignVertical: 'center',
        fontSize: 16
    },
    clockIcon: {
        flex: 1,
        alignItems: 'center'
    },
    buttonRow: {
        marginTop: 20,
        flexDirection: 'row',
        justifyContent: 'space-evenly',
        width: '100%',
    },
    dropdown: {
        marginVertical: 5,
    },
})

export default AppointmentSchedulingScreen