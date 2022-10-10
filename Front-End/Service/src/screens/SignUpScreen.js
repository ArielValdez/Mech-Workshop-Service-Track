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

const SignUpScreen = () => {
    const [ firstname, setFirstname ] = useState('')
    const [ lastname, setLastname ] = useState('')
    const [ email, setEmail ] = useState('')
    const [ phone, setPhone ] = useState('')
    const [ carModel, setCarModel ] = useState('')
    const [ username, setUsername ] = useState('')
    const [ password, setPassword ] = useState('')
    const [ confirmPassword, setConfirmPassword ] = useState('')
    const [ modalVisible, setModalVisible ] = useState(false) 
    const { height, width } = useWindowDimensions()
    const navigation = useNavigation()

    const onRegisterPressed = () => {
        setModalVisible(true)
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
                    text='Su registro ha sido completado de manera satisfactoria'
                    onClosePress={() => setModalVisible(false)}
                    visible={modalVisible}
                />

                <Text style={styles.title}>Creación de cuenta</Text>
                <Image 
                    source={Logo} 
                    style={[styles.logo, {height: height * 0.3, width: width * 0.75}]} 
                    resizeMode='contain'
                />

                <CustomInput placeholder='Nombre' value={firstname} setValue={setFirstname} />
                <CustomInput placeholder='Apellido' value={lastname} setValue={setLastname} />
                <CustomInput placeholder='Correo Electrónico' value={email} setValue={setEmail} keyboardType='email-address'
                    errorMessage={InvalidEmailMessage} pattern={EmailRegex}
                />
                <CustomInput placeholder='Teléfono celular' value={phone} setValue={setPhone} 
                    keyboardType='number-pad'/>
                <CustomInput placeholder='Modelo - marca' value={carModel} setValue={setCarModel} />
                <CustomInput placeholder='Nombre de usuario' value={username} setValue={setUsername} 
                    errorMessage={InvalidUsernameMessage} pattern={UsernameRegex}
                />
                <CustomInput placeholder='Contraseña' value={password} setValue={setPassword} secureTextEntry
                    errorMessage={InvalidPasswordMessage} pattern={PasswordRegex}
                />
                <CustomInput placeholder='Confirmar contraseña' value={confirmPassword} setValue={setConfirmPassword} secureTextEntry
                    errorMessage={InvalidPasswordMessage} pattern={PasswordRegex}
                />

                
                <Text style={styles.politicsText}>
                    Al registrarse, usted confirma que esta de acuerdo con nuestros{' '}
                     <Text style={styles.link} onPress={onTermsOfUsePressed}>términos de uso</Text> y{' '}
                     <Text style={styles.link} onPress={onPrivacyPoliticsPressed}>política de privacidad</Text>.
                </Text>

                <CustomButton onPress={onRegisterPressed} text='Crear cuenta'/>
                <CustomButton testID='ReturnButton' onPress={onReturnPressed} text='Regresar' type="Tertiary"/>
            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    scrollContainer: {
        backgroundColor: theme.colors.primary,
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
        color: '#051C60',
        margin: 10,
    },
    politicsText: {
        marginVertical: 10,
    },
    link: {
        color: '#FDB075',
    }
})

export default SignUpScreen