import React, { useState, useCallback, useMemo, useEffect, useRef } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView, Modal, FlatList } from 'react-native'
import { Calendar, CalendarUtils } from 'react-native-calendars'
import DateTimePicker from '@react-native-community/datetimepicker'
import Pressable from "react-native/Libraries/Components/Pressable/Pressable";
import CustomButton from "../components/CustomButton";
import CustomInput from "../components/CustomInput";
import theme from "../Theme";
import { Entypo, AntDesign } from '@expo/vector-icons'

const appointmentTitleRegex = /[a-zA-Z]{3,}/
const appointmentTitleErrorMessage = 'Título de cita debe tener al menos 3 carácteres'

const AppointmentModal = ({visible, onRequestClose, onReturnPress, onOkPress, timeValue, onTimeChange}) => {
    const [ appointmentTitle, setAppointmentTitle ] = useState('')
    const [ showTimePicker, setShowTimePicker ] = useState(false)
    const { height, width } = useWindowDimensions()

    return (
        <Modal
            animationType='fade'
            transparent={true}
            visible={visible}
            onRequestClose={() => {
                setAppointmentTitle('')
                onRequestClose()
            }}
        >
            <View style={modalStyles.container}>
                <View style={[ modalStyles.view, { height: height * 0.30 } ]}>
                    <Text style={modalStyles.title}>Nueva cita</Text>
                    <CustomInput value={appointmentTitle} setValue={setAppointmentTitle} placeholder='Título cita'
                        pattern={appointmentTitleRegex} errorMessage={appointmentTitleErrorMessage} />
                    <CustomButton text='Seleccionar tiempo' width='75%' type="Tertiary" 
                        fgColor={theme.colors.primary} onPress={() => setShowTimePicker(true)} />

                    <View style={modalStyles.buttonRow}>
                        <CustomButton 
                            text='Regresar' 
                            width='45%' 
                            bgColor={theme.colors.gray}
                            onPress={() => {
                                setAppointmentTitle('')
                                onReturnPress()
                            }}
                        />
                        <CustomButton 
                            text='Agendar' 
                            width='45%' 
                            bgColor={theme.colors.primary} 
                            onPress={() => {
                                const regex = new RegExp(appointmentTitleRegex)
                                if (regex.test(appointmentTitle)) { 
                                    onOkPress(appointmentTitle)
                                }
                            }}
                        />
                       
                    </View>
                </View>
            </View>
            {showTimePicker && (
                <DateTimePicker
                    value={timeValue} 
                    mode='time'
                    is24Hour={true}
                    onChange={(event, selectedDate) => {
                        setShowTimePicker(false)
                        onTimeChange(event, selectedDate)
                    }}
                />
            )}
        </Modal>
    ) 
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
        fontWeight: 'bold',

    },
    buttonRow: {
        marginTop: 15,
        flexDirection: 'row',
        justifyContent: 'space-evenly',
        width: '100%',
    }
})

const Appointment = ({title, date}) => {
    return (
        <View style={appointmentStyles.container}>
            <Text style={appointmentStyles.header}>
                {title}
            </Text>
            <Text style={appointmentStyles.date}>
                {date.toLocaleString()}
            </Text>
        </View>
    )
}

const appointmentStyles = StyleSheet.create({
    container: {
        backgroundColor: theme.colors.white,
        padding: 10,
        marginHorizontal: 15,
        marginTop: 10,
        borderRadius: 5,
    },
    header: {
        fontWeight: 'bold',
        marginBottom: 10,
    },
    date: {
        color: theme.colors.gray,
    }
})

const appointmentRenderItem = ({item}) => {
    return (
        <Appointment title={item.title} date={item.date} />
    )
}

const AppointmentsScreen = () => {
    const exampleValues = [
        { id: 1, title: 'Chequeo Rutinario', date: new Date()}
    ]

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
    const [ appointments, setAppointments ] = useState(exampleValues)
    const idCounter = useRef(2)

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

    const onModalOkPress = (title) => {
        var newArray = [...appointments, { id: idCounter.current, title: title, date: selectedTime}]
        idCounter.current = idCounter.current + 1
        setAppointments(newArray)
        setModalVisible(false)
    }

    
    return (
        <View style={styles.container}>
            <Calendar 
                onDayPress={onDayPress}
                markedDates={marked}
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
            <Pressable style={styles.addAppointmentButton} onPressIn={onAddAppointmentPress}>
                <Entypo name="plus" size={50}/>
            </Pressable>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
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
