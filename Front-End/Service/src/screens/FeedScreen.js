import React from 'react'
import { SafeAreaView, View, Text, Image, StyleSheet } from 'react-native'
import Car from '../../assets/CarPlaceholder.png'

const FeedScreen = () => {
    return (
        <View style={styles.container}>
            <Text>Bienvenido/a</Text>
            <Text style={styles.username}>Carlos Roque</Text>
            <Image source={Car} style={styles.image} />
            <View style={styles.historyContainer}>
                <Text style={{alignSelf: 'center'}}>No tienes nada en el Historial</Text>
            </View>
            <View style={styles.appointmentContainer}>
                <Text>Proxima cita</Text>
                <Text style={{alignSelf: 'center', marginVertical: 25}}>No tienes ninguna cita actualmente</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        alignItems: 'center',
        marginTop: 20,
    },
    username: {
        fontSize: 18,
        fontWeight: 'bold',
    },
    image: {
        width: 300, 
        height: 200, 
        marginBottom: 20, 
        borderRadius: 5,
    },
    historyContainer: {
        backgroundColor: 'white', 
        width: 250, height: 150, 
        justifyContent: 'center',
    },
    appointmentContainer: {
        marginTop: 35, 
        backgroundColor: 'white', 
        width: 250, 
        height: 120, 
        padding: 5,
    },
})

export default FeedScreen