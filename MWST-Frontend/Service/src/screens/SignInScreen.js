import React, { useEffect, useState } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import { PrivateValueStore, useNavigation } from "@react-navigation/native";
import CustomInput from "../components/CustomInput";
import CustomButton from "../components/CustomButton";
import Logo from '../../assets/LogoOficial.png'
import CheckBox from 'expo-checkbox';
import { EmailRegex, InvalidEmailMessage, PasswordRegex, InvalidPasswordMessage } from '../Constants'
import theme from '../Theme'
import '../../assets/translations/i18n'
import { useTranslation } from "react-i18next";
import { useUser } from "../context/UserContext";
import { getUser } from "../services/UserService";
import AsyncStorage from "@react-native-async-storage/async-storage"

const SignInScreen = () => {
    const [ user, setUser ] = useUser()
    const [ email, setEmail ] = useState('')
    const [ password, setPassword ] = useState('')
    const [ rememberMe, setRememberMe ] = useState(false)

    const { height, width } = useWindowDimensions()
    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        // Check if rememberMe is true, and if it is login automatically
        AsyncStorage.getItem("@rememberMe").then((value) => {
			value = JSON.parse(value)
			if (value !== null && value === true) {
				setRememberMe(true)
				AsyncStorage.getItem("@email").then(value => setEmail(value))
				AsyncStorage.getItem("@password").then(value => setPassword(value))
			}
		})
    }, [])

    const onSignInPressed = () => {            
        getUser(email, password)
            .then(user => {
                AsyncStorage.setItem('@rememberMe', JSON.stringify(rememberMe))
                if (rememberMe) {
                    AsyncStorage.setItem('@email', email)
                    AsyncStorage.setItem('@password', password)
                }
                setUser(user)
                navigation.navigate('Home') 
            })
            // TODO: Instead of logging show a modal with information useful for the user
            .catch(error => console.log(error))
    }

    const onForgotPasswordPressed = () => {
        navigation.navigate('ForgotPassword')
    }

    const onSignUpPressed = () => {
        navigation.navigate('SignUp')
    }

    return (
        <ScrollView showsVerticalScrollIndicator={false} style={styles.scrollContainer}>
            <View style={styles.container}>
                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />
                
                <CustomInput placeholder={t('emailInputPlaceholder')} value={email} setValue={setEmail} keyboardType='email-address'
                    errorMessage={InvalidEmailMessage} pattern={EmailRegex} marginVertical={10}
                />
                <CustomInput placeholder={t('passwordInputPlaceholder')} value={password} setValue={setPassword} secureTextEntry
                    errorMessage={InvalidPasswordMessage} pattern={PasswordRegex} marginVertical={10}
                />
                
                <View style={{flexDirection: 'row', marginBottom: 10}}>
                    <View style={{flex: 1, flexDirection: 'row'}}>
                        <CheckBox value={rememberMe} onValueChange={setRememberMe}/>
                        <Text style={{marginLeft: 5}}>{t('rememberMe')}</Text>
                    </View>
                    <View style={{flex: 0.5}}></View>
                    <View style={{flex: 1.3, marginBottom: 10}}>
                        <CustomButton onPress={onForgotPasswordPressed} text={t('forgotPasswordButtonText')} type='Tertiary'
                            padding={0.1} marginVertical={0.1} fgColor={theme.colors.black} />
                    </View>
                </View>

                <CustomButton testID='SignInButton' onPress={onSignInPressed} text={t('signInButtonText')} 
                    bgColor={theme.colors.darkPrimary} />

                {/*<CustomButton onPress={onSignInFacebook} text='Entrar con Facebook' bgColor='#E7EAF4' fgColor='#4765A9'/>
                <CustomButton onPress={onSignInGoogle} text='Entrar con Google' bgColor='#FAE9EA' fgColor='#DD4D44'/>
                <CustomButton onPress={onSignInApple} text='Entrar con Apple' bgColor='#e3e3e3' fgColor='#363636'/>
                */}
                <CustomButton testID='SignUpButton' onPress={onSignUpPressed} text={t('signUpButtonText')} type='Secondary'/>
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
        padding: 20,
    },
    logo: {
        flex: 1,
        marginBottom: 10,
    }
})

export default SignInScreen