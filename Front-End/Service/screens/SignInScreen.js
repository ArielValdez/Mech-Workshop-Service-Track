import React, { useState } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import CustomInput from "../components/CustomInput";
import CustomButton from "../components/CustomButton";
import Logo from '../assets/LogoOficial.png'

const SignInScreen = () => {
    const { email, setEmail } = useState('')
    const { password, setPassword } = useState('') 
    const { height, width } = useWindowDimensions()

    const onSignInPressed = () => {
        console.warn('Sign in pressed')
    }

    const onForgotPasswordPressed = () => {
        console.warn('Forgot password pressed')
    }

    const onSignInFacebook = () => {
        console.warn('Sign in with facebook')
    }

    const onSignInGoogle = () => {
        console.warn('Sign in with google')
    }

    const onSignInApple = () => {
        console.warn('Sign in with apple')
    }

    const onSignUpPressed = () => {
        console.warn('Sign up')
    }

    return (
        <ScrollView showsVerticalScrollIndicator={false}>
            <View style={styles.container}>
                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />

                <CustomInput placeholder='Correo Electrónico' value={email} setValue={setEmail} keyboardType='email-address'/>
                <CustomInput placeholder='Contraseña' value={password} setValue={setPassword} secureTextEntry/>

                <CustomButton onPress={onSignInPressed} text='Iniciar sesión'/>
                <CustomButton onPress={onForgotPasswordPressed} text='Olvide mi contraseña' type='Tertiary'/>

                <CustomButton onPress={onSignInFacebook} text='Entrar con Facebook' bgColor='#E7EAF4' fgColor='#4765A9'/>
                <CustomButton onPress={onSignInGoogle} text='Entrar con Google' bgColor='#FAE9EA' fgColor='#DD4D44'/>
                <CustomButton onPress={onSignInApple} text='Entrar con Apple' bgColor='#e3e3e3' fgColor='#363636'/>

                <CustomButton onPress={onSignUpPressed} text='No tienes una cuenta? Crea una' type='Tertiary'/>
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
    logo: {
        flex: 1,
    }
})

export default SignInScreen