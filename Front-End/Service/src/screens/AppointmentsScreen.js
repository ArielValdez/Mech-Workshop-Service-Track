import React, { useState, useCallback, useMemo, useEffect } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView, Modal, FlatList } from 'react-native'
import { Calendar, CalendarUtils } from 'react-native-calendars'
import Pressable from "react-native/Libraries/Components/Pressable/Pressable";
import CustomButton from "../components/CustomButton";
import CustomInput from "../components/CustomInput";
import theme from "../Theme";

const AppointmentModal = ({visible, onRequestClose, onReturnPress, onOkPress}) => {
    const [ appointmentTitle, setAppointmentTitle ] = useState('')

    return (
        <Modal
            animationType='fade'
            transparent={true}
            visible={visible}
            onRequestClose={onRequestClose}
        >
            <View style={modalStyles.container}>
                <View style={modalStyles.view}>
                    <Text style={modalStyles.title}>Nueva cita</Text>
                    <CustomInput value={appointmentTitle} setValue={setAppointmentTitle} placeholder='Título cita'/>
                    <CustomInput placeholder='Fecha'/>

                    <View style={modalStyles.buttonRow}>
                        <CustomButton 
                            text='Regresar' 
                            width='45%' 
                            bgColor={theme.colors.gray}
                            onPress={onReturnPress}
                        />
                        <CustomButton 
                            text='Agendar' 
                            width='45%' 
                            bgColor={theme.colors.primary} 
                            onPress={() => onOkPress(appointmentTitle)}
                        />
                    </View>
                </View>
            </View>
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
        height: '30%',
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
            <Text style={styles.header}>
                {title}
            </Text>
            <Text style={styles.date}>
                {date.dateString}
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
        { id: 1, title: 'Chequeo Rutinario', date: { dateString: 'Martes, 06 3:35 PM' } }
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
    const [ modalVisible, setModalVisible ] = useState(false)
    const [ appointments, setAppointments ] = useState(exampleValues)

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
    }, [])

    const onAddAppointmentPress = () => {
        setModalVisible(!modalVisible)
    }

    const onModalOkPress = (title) => {
        var newArray = [...appointments, { id: 2, title: title, date: {...selected}}]
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
            />
            <Pressable style={styles.addAppointmentButton} onPressIn={onAddAppointmentPress}>

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
