import React, { useState } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import { useNavigation } from "@react-navigation/native";
import CustomInput from "../customs/CustomInput";
import CustomButton from "../customs/CustomButton";
import Logo from '../../assets/LogoOficial.png'
import CheckBox from 'expo-checkbox';

const SignInScreen = () => {
    const [ email, setEmail ] = useState('')
    const [ password, setPassword ] = useState('')
    const [ rememberMe, setRememberMe ] = useState(false) 
    const { height, width } = useWindowDimensions()

    const navigation = useNavigation()

    const onSignInPressed = () => {
        navigation.navigate('Home')
    }

    const onForgotPasswordPressed = () => {
        navigation.navigate('ForgotPassword')
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
        navigation.navigate('SignUp')
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
                
                <View style={{flexDirection: 'row'}}>
                    <View style={{flex: 1, flexDirection: 'row'}}>
                        <CheckBox value={rememberMe} onValueChange={setRememberMe}/>
                        <Text style={{marginLeft: 5}}>Remember me</Text>
                    </View>
                    <View style={{flex: 0.2}}></View>
                    <View style={{flex: 1.5, marginBottom: 10}}>
                        <CustomButton onPress={onForgotPasswordPressed} text='Olvide mi contraseña' type='Tertiary'
                            padding={0.1} marginVertical={0.1}
                        />
                    </View>
                </View>

                <CustomButton testID='SignInButton' onPress={onSignInPressed} text='Iniciar sesión'/>

                <CustomButton onPress={onSignInFacebook} text='Entrar con Facebook' bgColor='#E7EAF4' fgColor='#4765A9'/>
                <CustomButton onPress={onSignInGoogle} text='Entrar con Google' bgColor='#FAE9EA' fgColor='#DD4D44'/>
                <CustomButton onPress={onSignInApple} text='Entrar con Apple' bgColor='#e3e3e3' fgColor='#363636'/>

                <CustomButton testID='SignUpButton' onPress={onSignUpPressed} text='No tienes una cuenta? Crea una' type='Tertiary'/>
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