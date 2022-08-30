import React, { useState } from "react";
import { View, Text, StyleSheet, useWindowDimensions, ScrollView } from 'react-native'
import CustomButton from '../customs/CustomButton'
import CustomInput from '../customs/CustomInput'

const ConfirmEmailScreen = () => {
    const {code, setCode} = useState('')

    const onConfirmPressed = () => {
        console.warn('Confirm pressed')
    }

    const onResendPressed = () => {
        console.warn('Resend pressed')
    }

    const onReturnPressed = () => {
        console.warn('Return pressed')
    } 

    return (
        <ScrollView showsVerticalScrollIndicator={false}>
            <View style={styles.container}>
                <Text style={styles.title}>Confirmar correo</Text>

                <CustomInput placeholder='Código de confirmación' value={code} setValue={setCode} keyboardType='numeric'/>

                <CustomButton onPress={onConfirmPressed} text='Confirmar'/>
                <CustomButton onPress={onResendPressed} text='Reenviar' type="Secondary"/>
                <CustomButton onPress={onReturnPressed} text='Regresar' type="Tertiary"/>
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1, 
        alignItems: 'center',
        padding: 20
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        color: '#051C60',
        margin: 10,
    },
})

export default ConfirmEmailScreen