import React, { useState } from "react"
import { useTranslation } from "react-i18next"
import { View, Text, StyleSheet, useWindowDimensions, ScrollView } from 'react-native'
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/Inputs/CustomInput'
import CustomText from "../components/CustomText"

const ConfirmEmailScreen = () => {
    const [ code, setCode ] = useState('')

    const { t, i18n } = useTranslation

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
                <CustomText style={styles.title}>{t('emailConfirmation')}</CustomText>

                <CustomInput placeholder={t('confirmationCode')} value={code} setValue={setCode} keyboardType='numeric'/>

                <CustomButton onPress={onConfirmPressed} text={t('confirm')}/>
                <CustomButton onPress={onResendPressed} text={t('resend')} type="Secondary"/>
                <CustomButton onPress={onReturnPressed} text={t('return')} type="Tertiary"/>
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