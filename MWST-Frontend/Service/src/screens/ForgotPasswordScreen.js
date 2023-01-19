import { useNavigation } from '@react-navigation/native'
import React, { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { View, Text, StyleSheet } from 'react-native'
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/Inputs/CustomInput'
import UsernameInput from '../components/Inputs/UsernameInput'
import CustomText from '../components/CustomText'
import { getUserByUsername } from '../services/UserService'
import ErrorModal from '../components/Modals/ErrorModal'
import SuccessModal from '../components/Modals/SuccessModal'

const ForgotPasswordScreen = () => {
    const [ username, setUsername ] = useState('')
    const [ errorModalVisible, setErrorModalVisible ] = useState(false)

    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    const onNextPressed = () => {
        getUserByUsername(username)
            .then(user => {
                if (user) {
                    navigation.navigate('NewPassword', { user: user })
                    console.log(user)
                }
                else {
                    setErrorModalVisible(true)
                }
            })
    }

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <ErrorModal
                visible={errorModalVisible}
                errorText={t('usernameNotFoundError')}
                onRequestClose={() => setErrorModalVisible(false)}
                buttonText='Ok'
            />
            <CustomText style={styles.title}>{t('restartPassword')}</CustomText>
            
            <UsernameInput value={username} setValue={setUsername}/>
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