import React, { useState, useCallback, useMemo, useEffect, useRef } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView, Modal, FlatList, Pressable} from 'react-native'
import { Calendar, CalendarUtils, LocaleConfig } from 'react-native-calendars'
import DateTimePicker from '@react-native-community/datetimepicker'
import CustomButton from "../components/CustomButton";
import CustomInput from "../components/CustomInput";
import CustomText from "../components/CustomText";
import theme from "../Theme";
import { FontAwesome5, Entypo, AntDesign } from '@expo/vector-icons'
import { useTranslation } from "react-i18next";
import { useIsFocused, useNavigation } from "@react-navigation/native";
import DropDownPicker from "react-native-dropdown-picker";
import { useUser } from "../context/UserContext";
import { getAllAppointments, createAppointment } from "../services/AppointmentsService";
import { getAllVehicles } from "../services/VehicleService";
import PressableOpacity from "../components/PressableOpacity.js"

const appointmentTitleRegex = /[a-zA-Z]{3,}/
const appointmentTitleErrorMessage = 'Título de cita debe tener al menos 3 carácteres'

const AppointmentModal = ({visible, onRequestClose, onReturnPress, onOkPress, timeValue, onTimeChange}) => {
    const [ appointmentTitle, setAppointmentTitle ] = useState('')
    const [ showTimePicker, setShowTimePicker ] = useState(false)
    // Dropdown for vehicles
    const [ vehicles, setVehicles ] = useState([])
    const [ selectedVehicleId, setselectedVehicleId ] = useState(null)
    const [ openDropdown, setOpenDropdown ] = useState(false)
    // Dropdown for service type
    const [ services, setServices ] = useState([
        { label: 'Reparación', value: 'Reparation' },
        { label: 'Chequeo', value: 'Checkup' }
    ])
    const [ selectedService, setSelectedService ] = useState(null)
    const [ openServiceDropdown, setOpenServiceDropdown ] = useState(false)

    const isFocused = useIsFocused()
    const [ user, setUser ] = useUser()

    const { height, width } = useWindowDimensions()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        if (isFocused) {
            getAllVehicles(user.id)
                .then(vehicles => {
                    //var arr = []
                    //vehicles.forEach(vehicle => {
                       // arr.push({ label: vehicle.plate, value: vehicle.id})
                    //})
                    setVehicles(vehicles)
                })
                .catch(err => console.log(err))
        }
    }, [isFocused])
    
    return (
		<Modal
			animationType="fade"
			transparent={true}
			visible={visible}
			onRequestClose={() => {
				setAppointmentTitle("");
				onRequestClose();
			}}
		>
			<View style={modalStyles.container}>
				<View style={[modalStyles.view, { height: height * 0.48 }]}>
					<CustomText style={modalStyles.title}>{t("newAppointment")}</CustomText>
					<CustomInput
						value={appointmentTitle}
						setValue={setAppointmentTitle}
						placeholder="Título cita"
						pattern={appointmentTitleRegex}
						errorMessage={appointmentTitleErrorMessage}
					/>

					<Pressable
						style={modalStyles.clockIcon}
						onPress={() => setShowTimePicker(true)}
					>
						<FontAwesome5 name="clock" size={35} />
					</Pressable>

					<DropDownPicker
                        schema={{
                            label: 'plate',
                            value: 'id' 
                        }}
						placeholder={t("selectVehiclePlaceholder")}
						open={openDropdown}
						value={selectedVehicleId}
						items={vehicles}
						setOpen={setOpenDropdown}
						setValue={setselectedVehicleId}
						setItems={setVehicles}
						style={{
							marginBottom: 10,
						}}
                        zIndex={1000}
					/>

					<DropDownPicker
						placeholder={t("selectServicePlaceholder")}
						open={openServiceDropdown}
						value={selectedService}
						items={services}
						setOpen={setOpenServiceDropdown}
						setValue={setSelectedService}
						setItems={setServices}
                        zIndex={500}
					/>

					<View style={modalStyles.buttonRow}>
						<CustomButton
							text={t("return")}
							width="45%"
							bgColor={theme.colors.lightSecondary}
							fgColor={theme.colors.black}
							onPress={() => {
								setAppointmentTitle("");
								onReturnPress();
							}}
						/>
						<CustomButton
							text={t("schedule")}
							width="45%"
							onPress={() => {
								const regex = new RegExp(appointmentTitleRegex);
								if (regex.test(appointmentTitle)) {
									onOkPress(appointmentTitle, selectedVehicleId, selectedService);
								}
							}}
						/>
					</View>
				</View>
			</View>
			{showTimePicker && (
				<DateTimePicker
					value={timeValue}
					mode="time"
					is24Hour={true}
					onChange={(event, selectedDate) => {
						setShowTimePicker(false);
						onTimeChange(event, selectedDate);
					}}
				/>
			)}
		</Modal>
	); 
}

const modalStyles = StyleSheet.create({
    container: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
    view: {
        backgroundColor: theme.colors.white,
        width: '80%',
        borderRadius: 15,
        alignItems: 'center',
        padding: 20
    },
    title: {
    },
    clockIcon: {
        marginTop: 5,
        marginBottom: 10,
    },
    buttonRow: {
        marginTop: 20,
        flexDirection: 'row',
        justifyContent: 'space-evenly',
        width: '100%',
    },
})

const Appointment = ({ service }) => {
    const navigation = useNavigation()

    const onPress = () => {
        navigation.navigate('AppointmentDetail', { service: service })
    }

    return (
        <PressableOpacity 
            animatedViewStyle={appointmentStyles.container}
            onPress={onPress}
        >
            <CustomText style={appointmentStyles.header}>
                {service.description}
            </CustomText>
            <CustomText style={appointmentStyles.date}>
                {service.expectedAt}
            </CustomText>
        </PressableOpacity>
    )
}

const appointmentStyles = StyleSheet.create({
    container: {
        backgroundColor: theme.colors.white,
        padding: 10,
        marginHorizontal: 15,
        marginTop: 10,
        borderRadius: 5,
        borderWidth: 1.5,
        borderColor: theme.colors.black,
    },
    header: {
        marginBottom: 10,
    },
    date: {
        color: theme.colors.gray,
    }
})

const appointmentRenderItem = ({ item }) => {
    return (
        <Appointment service={item} />
    )
}

const AppointmentsScreen = () => {
    const d = new Date()
    const defaultCalendarValue = {
        day: d.getDate(),      // day of month (1-31)
        month: d.getMonth(),    // month of year (1-12)
        year: d.getYear(),  // year
        timestamp: '00:00',   // UTC timestamp representing 00:00 AM of this date
        dateString: d.getFullYear()  + "-" + (d.getMonth()) + "-" + d.getDate() // date formatted as 'YYYY-MM-DD' string
    }

    const [ selected, setSelected ] = useState(defaultCalendarValue)
    const [ selectedTime, setSelectedTime ] = useState(new Date())
    const [ modalVisible, setModalVisible ] = useState(false)
    const [ appointments, setAppointments ] = useState([])
    const [ user, setUser] = useUser()
    const { height, width } = useWindowDimensions()
    const { t, i18n } = useTranslation() 

    useEffect(() => {
        fetchServices()
    }, [])

    const marked = useMemo(() => {
        return {
          [selected]: {
            selected: true,
            disableTouchEvent: true,
            selectedColor: theme.colors.primary
          }
        }
      }, [selected])

    const onDayPress = useCallback((date) => {
        setSelected(date.dateString)
        // Update date object for the time selection
        selectedTime.setDate(date.day)
        selectedTime.setMonth(date.month)
        selectedTime.setFullYear(date.year)
    }, [])

    const onAddAppointmentPress = () => {
        setModalVisible(!modalVisible)
    }

    const onModalOkPress = (title, vehicleId, serviceType) => {
        fetchServices()
        setModalVisible(false)
        createAppointment(serviceType, title, vehicleId, selectedTime, user.id)
            .then(result => console.log('The service has been successfully posted'))
            .catch(err => console.log(err))
    }

    const fetchServices = () => {
        getAllAppointments(user.id)
            .then(appointments => setAppointments(appointments))
            .catch(err => console.log(err))
    }

    
    return (
        <View style={[styles.container, {height: height * 0.88, width: width}]}>
            <Calendar 
                onDayPress={onDayPress}
                markedDates={marked}
                key={i18n.language}
            />
            <FlatList 
                data={appointments}
                renderItem={appointmentRenderItem}
                keyExtractor={item => item.id}
            />
            <AppointmentModal 
                visible={modalVisible} 
                onRequestClose={() => setModalVisible(false)}
                onReturnPress={() => setModalVisible(false)}
                onOkPress={onModalOkPress}
                timeValue={selectedTime}
                onTimeChange={(event, selectedDate) => {
                    console.log(selectedDate)
                    setSelectedTime(selectedDate)
                }}    
            />

            <Pressable style={({ pressed }) => [
                styles.addAppointmentButton,
                { opacity: pressed ? 0.2 : 1}
            ]} 
            onPress={onAddAppointmentPress}>
                <Entypo name="plus" size={50} />
            </Pressable>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: theme.colors.bgColor,
    },
    addAppointmentButton: {
        position: 'absolute',
        bottom: 20,
        right: 20,
        backgroundColor: theme.colors.primary,
        height: 50,
        width: 50,
        borderRadius: 25,
    },
})

export default AppointmentsScreen
