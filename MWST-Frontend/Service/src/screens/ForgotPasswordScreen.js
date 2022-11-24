import { useNavigation } from '@react-navigation/native'
import React, { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { View, Text, StyleSheet } from 'react-native'
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/CustomInput'

const ForgotPasswordScreen = () => {
    const [ username, setUsername ] = useState('')

    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    const onNextPressed = () => {
        navigation.navigate('NewPassword')
    }

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <Text style={styles.title}>{t('restartPassword')}</Text>

            <Text>Usuario *</Text>
            <CustomInput value={username} setValue={setUsername} placeholder={t('usernameInputPlaceholder')}/>
            <CustomButton onPress={onNextPressed} text={t('nextButtonText')}/>
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

export default ForgotPasswordScreen