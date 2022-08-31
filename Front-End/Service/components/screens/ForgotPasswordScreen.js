import { useNavigation } from '@react-navigation/native'
import React, { useState } from 'react'
import { View, Text, StyleSheet } from 'react-native'
import CustomButton from '../customs/CustomButton'
import CustomInput from '../customs/CustomInput'

const ForgotPasswordScreen = () => {
    const { username, setUsername } = useState('')

    const navigation = useNavigation()

    const onNextPressed = () => {
        navigation.navigate('NewPassword')
    }

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Reiniciar contraseña</Text>

            <Text>Usuario *</Text>
            <CustomInput value={username} setValue={setUsername} placeholder='Nombre de usuario'/>
            <CustomButton onPress={onNextPressed} text='Continuar'/>
            <CustomButton onPress={onReturnPressed} text='Regresar a inicio de sesión' type='Tertiary'/>
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