import { useNavigation } from '@react-navigation/native'
import React, { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { View, Text, StyleSheet } from 'react-native'
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/Inputs/CustomInput'
import PasswordInput from '../components/Inputs/PasswordInput'
import CustomText from '../components/CustomText'
import { editUserPassword } from '../services/UserService'
import { useUser } from '../context/UserContext'
import SuccessModal from '../components/Modals/SuccessModal'
import ErrorModal from '../components/Modals/ErrorModal'

const passwordRegex = /[a-zA-Z0-9@]{8,}/

const NewPasswordScreen = ({ route }) => {
    const [ newPassword, setNewPassword ] = useState('')
    const [ confirmNewPassword, setConfirmNewPassword ] = useState('')
    const [ successModalVisible, setSuccessModalVisible ] = useState(false)
    const [ errorModalVisible, setErrorModalVisible ] = useState(false)

    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    const onSendPressed = () => {
        if (passwordRegex.test(newPassword) && newPassword == confirmNewPassword) {
            console.log(route.params.user)
            editUserPassword(route.params.user, newPassword)
                .then(result => setSuccessModalVisible(true))
                .catch(err => {
                    setErrorModalVisible(true)
                    console.log(err)
                })
        }
        else {
            setErrorModalVisible(true)
        }
    }

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <SuccessModal
                visible={successModalVisible} 
                successText={t('passwordChangedMessage')}
                onRequestClose={() => setSuccessModalVisible(false)}
                buttonText={t('understood')}
            />
            <ErrorModal
                visible={errorModalVisible}
                errorText={t('genericErrorMessage')}
                onRequestClose={() => setErrorModalVisible(false)}
                buttonText='Ok'
            />
            <CustomText style={styles.title}>{t('restartPassword')}</CustomText>

            <PasswordInput value={newPassword} setValue={setNewPassword} placeholder={t('newPassword')}/>
            <PasswordInput value={confirmNewPassword} setValue={setConfirmNewPassword} placeholder={t('confirmNewPassword')}/>

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