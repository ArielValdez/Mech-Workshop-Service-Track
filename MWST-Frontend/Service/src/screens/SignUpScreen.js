import React, { useState } from "react"
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import { useNavigation } from "@react-navigation/native"
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/CustomInput'
import CustomText from "../components/CustomText"
import SuccessModal from "../components/Modals/SuccessModal"
import ErrorModal from "../components/Modals/ErrorModal"
import Logo from '../../assets/LogoOficial.png'
import { UsernameRegex, InvalidUsernameMessage, EmailRegex,
     InvalidEmailMessage, PasswordRegex, InvalidPasswordMessage } from '../Constants'
import theme from "../Theme"
import { useTranslation } from "react-i18next"
import { createUser } from "../services/UserService"

//  TODO: Regex pattern for name input, last name input, phone number input and idCard input
//  TODO: Make error messages available in english and spanish
//  TODO: Handle the registration of user failing

const nameRegex = /^[a-zA-Z]{3,25}$/
const emailRegex = EmailRegex
const usernameRegex = new RegExp(UsernameRegex)
const phoneRegex = /^[\d]{10}$/
const idCardRegex = /^[\d]{11}$/
const passwordRegex = new RegExp(PasswordRegex)

const SignUpScreen = () => {
    const [ firstname, setFirstname ] = useState('')
    const [ lastname, setLastname ] = useState('')
    const [ email, setEmail ] = useState('')
    const [ phone, setPhone ] = useState('')
    const [ username, setUsername ] = useState('')
    const [ idCard, setIdCard ] = useState('')
    const [ password, setPassword ] = useState('')
    const [ confirmPassword, setConfirmPassword ] = useState('')
    const [ successModalVisible, setSuccessModalVisible ] = useState(false)
    const [ errorModalVisible, setErrorModalVisible ] = useState(false)

    const { height, width } = useWindowDimensions()
    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    const onRegisterPressed = () => {
        if (nameRegex.test(firstname) && nameRegex.test(lastname) && usernameRegex.test(username) &&
                emailRegex.test(email) && phoneRegex.test(phone) && idCardRegex.test(idCard) && 
                passwordRegex.test(password) && password == confirmPassword) {
            
            createUser(firstname, lastname, email, phone, username, idCard, password)
                .then(result => setSuccessModalVisible(true))
        }
        else {
            setErrorModalVisible(true)
        }
	}

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    const onTermsOfUsePressed = () => {
        console.warn('Terms of use pressed')
    }

    const onPrivacyPoliticsPressed = () => {
        console.warn('Privacy pol pressed')
    }

    return (
        <ScrollView showsVerticalScrollIndicator={false} style={styles.scrollContainer}>
            <View style={styles.container}>
                <SuccessModal
                    visible={successModalVisible} 
                    successText={t('successfullRegisterMessage')}
                    onRequestClose={() => setSuccessModalVisible(false)}
                    buttonText={t('understood')}
                />
                <ErrorModal
                    visible={errorModalVisible}
                    errorText={t('invalidRegisterMessage')}
                    onRequestClose={() => setErrorModalVisible(false)}
                    buttonText='Ok'
                />

                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />

                <CustomInput placeholder={t('nameInputPlaceholder')} value={firstname} setValue={setFirstname} 
                    pattern={nameRegex} errorMessage={t('invalidNameMessage')}
                />
                <CustomInput placeholder={t('lastNameInputPlaceholder')} value={lastname} setValue={setLastname}
                    pattern={nameRegex} errorMessage={t('invalidNameMessage')}
                />
                <CustomInput placeholder={t('emailInputPlaceholder')} value={email} setValue={setEmail} 
                    keyboardType='email-address' errorMessage={t('invalidEmailMessage')} pattern={EmailRegex}
                />
                <CustomInput placeholder={t('phoneNumberInputPlaceholder')} value={phone} setValue={setPhone} 
                    keyboardType='number-pad' pattern={phoneRegex} errorMessage={t('invalidPhoneMessage')}
                />
                <CustomInput placeholder={t('usernameInputPlaceholder')} value={username} setValue={setUsername} 
                    pattern={UsernameRegex} errorMessage={t('invalidUsernameMessage')} 
                />
                <CustomInput placeholder='001-0000000-1' value={idCard} setValue={setIdCard} 
                    keyboardType='number-pad' pattern={idCardRegex} errorMessage={t('invalidIdCardMessage')} 
                />
                <CustomInput placeholder={t('passwordInputPlaceholder')} value={password} setValue={setPassword} secureTextEntry
                    pattern={PasswordRegex} errorMessage={t('invalidPasswordMessage')}
                />
                <CustomInput placeholder={t('confirmPasswordInputPlaceholder')} value={confirmPassword} setValue={setConfirmPassword} 
                    secureTextEntry errorMessage={t('invalidPasswordMessage')} pattern={PasswordRegex}
                />
                
                <CustomText style={styles.politicsText}>
                    {t('politicsText1')}{' '}
                    <CustomText style={styles.link} onPress={onTermsOfUsePressed}>{t('politicsText2')}</CustomText> y{' '}
                    <CustomText style={styles.link} onPress={onPrivacyPoliticsPressed}>{t('politicsText3')}</CustomText>.
                </CustomText>

                <CustomButton onPress={onRegisterPressed} text={t('registerButtonText')} bgColor={theme.colors.darkPrimary}/>
                <CustomButton testID='ReturnButton' onPress={onReturnPressed} text={t('returnButtonText')} type="Secondary"/>
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    scrollContainer: {
        backgroundColor: theme.colors.bgColor,
    },
    container: {
        flex: 1, 
        alignItems: 'center',
        padding: 20
    },
    logo: {
        flex: 1,
    },
    politicsText: {
        marginVertical: 10,
    },
    link: {
        color: theme.colors.darkSecondary,
        textDecorationLine: 'underline',
    }
})

export default SignUpScreen