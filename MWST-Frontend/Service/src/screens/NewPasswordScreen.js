import { useNavigation } from '@react-navigation/native'
import React, { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { View, Text, StyleSheet } from 'react-native'
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/CustomInput'

const NewPasswordScreen = () => {
    const [ newPassword, setNewPassword ] = useState('')
    const [ confirmNewPassword, setConfirmNewPassword ] = useState('')

    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    const onSendPressed = () => {
        console.warn('Send pressed')
    }

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <Text style={styles.title}>{t('restartPassword')}</Text>

            <CustomInput value={newPassword} setValue={setNewPassword} placeholder={t('newPassword')}/>
            <CustomInput value={confirmNewPassword} setValue={setConfirmNewPassword} placeholder={t('confirmNewPassword')}/>

            <CustomButton onPress={onSendPressed} text={t('send')}/>
            <CustomButton onPress={onReturnPressed} text={t('returnToSignInButtonText')} type='Tertiary'/>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 20,
        alignItems: 'flex-start',
        paddingLeft: 20,
    },
    title: {
       fontSize: 20,
       fontWeight: 'bold',
       color: '#062da1',
       marginVertical: 20,
    },
})

export default NewPasswordScreen