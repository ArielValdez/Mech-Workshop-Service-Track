import React, { useState } from "react";
import { View, Text, StyleSheet, Image, useWindowDimensions, ScrollView } from 'react-native'
import { useNavigation } from "@react-navigation/native";
import CustomButton from '../customs/CustomButton'
import CustomInput from '../customs/CustomInput'
import Logo from '../../assets/LogoOficial.png'

const SignUpScreen = () => {
    const { username, setUsername} = useState('')
    const { email, setEmail } = useState('')
    const { password, setPassword } = useState('')
    const { confirmPassword, setConfirmPassword} = useState('') 
    const { height, width } = useWindowDimensions()
    const navigation = useNavigation()

    const onRegisterPressed = () => {
        console.warn('Confirm pressed')
    }

    const onReturnPressed =() => {
        navigation.navigate('SignIn')
    }

    const onTermsOfUsePressed = () => {
        console.warn('Terms of use pressed')
    }

    const onPrivacyPoliticsPressed = () => {
        console.warn('Privary pol pressed')
    }

    return (
        <ScrollView showsVerticalScrollIndicator={false}>
            <View style={styles.container}>
                <Text style={styles.title}>Creación de cuenta</Text>
                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />

                <CustomInput placeholder='Nombre de usuario' value={username} setValue={setUsername} />
                <CustomInput placeholder='Correo Electrónico' value={email} setValue={setEmail} keyboardType='email-address'/>
                <CustomInput placeholder='Contraseña' value={password} setValue={setPassword} secureTextEntry/>
                <CustomInput placeholder='Confirmar contraseña' value={confirmPassword} setValue={setConfirmPassword} secureTextEntry/>
                
                <Text style={styles.politicsText}>
                    Al registrarse, usted confirma que esta de acuerdo con nuestros{' '}
                     <Text style={styles.link} onPress={onTermsOfUsePressed}>términos de uso</Text> y{' '}
                     <Text style={styles.link} onPress={onPrivacyPoliticsPressed}>política de privacidad</Text>.
                </Text>

                <CustomButton onPress={onRegisterPressed} text='Crear cuenta'/>
                <CustomButton onPress={onReturnPressed} text='Regresar' type="Tertiary"/>
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
    },
    title: {
        fontSize: 24,
        fontWeight: 'bold',
        color: '#051C60',
        margin: 10,
    },
    politicsText: {
        color: 'gray',
        marginVertical: 10,
    },
    link: {
        color: '#FDB075',
    }
})

export default SignUpScreen