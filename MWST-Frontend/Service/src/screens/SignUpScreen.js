import React, { useState } from "react"
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import { useNavigation } from "@react-navigation/native"
import CustomButton from '../components/CustomButton'
import CustomInput from '../components/CustomInput'
import AlertModal from "../components/AlertModal"
import Logo from '../../assets/LogoOficial.png'
import { UsernameRegex, InvalidUsernameMessage, EmailRegex,
     InvalidEmailMessage, PasswordRegex, InvalidPasswordMessage } from '../Constants'
import theme from "../Theme"
import { useTranslation } from "react-i18next"
import { createUser } from "../services/UserService"

const SignUpScreen = () => {
    const [ firstname, setFirstname ] = useState('')
    const [ lastname, setLastname ] = useState('')
    const [ email, setEmail ] = useState('')
    const [ phone, setPhone ] = useState('')
    const [ username, setUsername ] = useState('')
    const [ idCard, setIdCard ] = useState('')
    const [ password, setPassword ] = useState('')
    const [ confirmPassword, setConfirmPassword ] = useState('')
    const [ modalVisible, setModalVisible ] = useState(false)

    const { height, width } = useWindowDimensions()
    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    const onRegisterPressed = () => {
        createUser(firstname, lastname, email, phone, username, idCard, password)
            .then(result => setModalVisible(true))
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
                <AlertModal 
                    title='Información' 
                    text='Su registro ha sido completado de manera satisfactoria.'
                    onClosePress={() => setModalVisible(false)}
                    visible={modalVisible}
                />

                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />

                <CustomInput placeholder={t('nameInputPlaceholder')} value={firstname} setValue={setFirstname} />
                <CustomInput placeholder={t('lastNameInputPlaceholder')} value={lastname} setValue={setLastname} />
                <CustomInput placeholder={t('emailInputPlaceholder')} value={email} setValue={setEmail} 
                    keyboardType='email-address' errorMessage={InvalidEmailMessage} pattern={EmailRegex} />
                <CustomInput placeholder={t('phoneNumberInputPlaceholder')} value={phone} setValue={setPhone} 
                    keyboardType='number-pad' />
                <CustomInput placeholder={t('usernameInputPlaceholder')} value={username} setValue={setUsername} 
                    errorMessage={InvalidUsernameMessage} pattern={UsernameRegex} />
                <CustomInput placeholder='001-0000000-1' value={idCard} setValue={setIdCard} 
                    keyboardType='number-pad' />
                <CustomInput placeholder={t('passwordInputPlaceholder')} value={password} setValue={setPassword} secureTextEntry
                    errorMessage={InvalidPasswordMessage} pattern={PasswordRegex} />
                <CustomInput placeholder={t('confirmPasswordInputPlaceholder')} value={confirmPassword} setValue={setConfirmPassword} 
                    secureTextEntry errorMessage={InvalidPasswordMessage} pattern={PasswordRegex} />
                
                <Text style={styles.politicsText}>
                    {t('politicsText1')}{' '}
                    <Text style={styles.link} onPress={onTermsOfUsePressed}>{t('politicsText2')}</Text> y{' '}
                    <Text style={styles.link} onPress={onPrivacyPoliticsPressed}>{t('politicsText3')}</Text>.
                </Text>

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
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        color: theme.colors.darkSecondary,
        margin: 10,
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