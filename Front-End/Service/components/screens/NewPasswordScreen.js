import { useNavigation } from '@react-navigation/native'
import React, { useState } from 'react'
import { View, Text, StyleSheet } from 'react-native'
import CustomButton from '../customs/CustomButton'
import CustomInput from '../customs/CustomInput'

const NewPasswordScreen = () => {
    const [ newPassword, setNewPassword ] = useState('')
    const [ confirmNewPassword, setConfirmNewPassword ] = useState('')

    const navigation = useNavigation()

    const onSendPressed = () => {
        console.warn('Send pressed')
    }

    const onReturnPressed = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Reiniciar contraseña</Text>

            <CustomInput value={newPassword} setValue={setNewPassword} placeholder='Nueva contraseña'/>
            <CustomInput value={confirmNewPassword} setValue={setConfirmNewPassword} placeholder='Confirmar nueva contraseña'/>

            <CustomButton onPress={onSendPressed} text='Enviar'/>
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

export default NewPasswordScreen