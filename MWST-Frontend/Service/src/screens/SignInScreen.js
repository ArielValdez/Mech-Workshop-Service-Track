import React, { useEffect, useState } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import { PrivateValueStore, useNavigation } from "@react-navigation/native";
import CustomInput from "../components/Inputs/CustomInput";
import CustomButton from "../components/CustomButton";
import EmailInput from '../components/Inputs/EmailInput'
import PasswordInput from '../components/Inputs/PasswordInput'
import Logo from '../../assets/LogoOficial.png'
import CheckBox from 'expo-checkbox';
import theme from '../Theme'
import '../../assets/translations/i18n'
import { useTranslation } from "react-i18next";
import { useUser } from "../context/UserContext";
import { getUser } from "../services/UserService";
import AsyncStorage from "@react-native-async-storage/async-storage"
import ErrorModal from "../components/Modals/ErrorModal"
import CustomText from "../components/CustomText";

const SignInScreen = () => {
    const [ user, setUser ] = useUser()
    const [ email, setEmail ] = useState('')
    const [ password, setPassword ] = useState('')
    const [ rememberMe, setRememberMe ] = useState(false)
    const [ errorModalVisible, setErrorModalVisible ] = useState(false)

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
        if (email == 'admin@gmail.com' && password == 'admin123') {
            const defaultUser = {
                username: 'Admin',
                password: 'admin123',
                email: 'admin@gmail.com',
                name: 'Pedro',
                lastname: 'Admin',
                //Should be limited to thirteen digits in the following manner: 0-1234567-891
                id_card: '01234567891',
                role: 'Client',
                //Should be limited to thirteen digits in the following order: (809)000-0000
                phone_number: '8095263214',
                active: true //change this later to false
            }
            setUser(defaultUser)
            navigation.navigate('Home')
            return 
        }
        
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
            .catch(error => setErrorModalVisible(true))
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
                <ErrorModal 
                    visible={errorModalVisible}
                    errorText={t('loginFailedErrorMessage')}
                    onRequestClose={() => setErrorModalVisible(!errorModalVisible)}
                    buttonText={t('tryAgain')}
                />

                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />
                
                <EmailInput value={email} setValue={setEmail} />
                <PasswordInput value={password} setValue={setPassword} placeholder={t('passwordInputPlaceholder')}/>
                
                <View style={{flexDirection: 'row', marginBottom: 10}}>
                    <View style={{flex: 1, flexDirection: 'row'}}>
                        <CheckBox value={rememberMe} onValueChange={setRememberMe}/>
                        <CustomText style={{marginLeft: 5}}>{t('rememberMe')}</CustomText>
                    </View>
                    <View style={{flex: 0.5}}></View>
                    <View style={{flex: 1.3, marginBottom: 10}}>
                        <CustomButton onPress={onForgotPasswordPressed} text={t('forgotPasswordButtonText')} type='Tertiary'
                            padding={0.1} marginVertical={0.1} fgColor={theme.colors.black} />
                    </View>
                </View>

                <CustomButton testID='SignInButton' onPress={onSignInPressed} text={t('signInButtonText')} />
                <CustomButton testID='SignUpButton' onPress={onSignUpPressed} text={t('signUpButtonText')} 
                    type='Secondary' />
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