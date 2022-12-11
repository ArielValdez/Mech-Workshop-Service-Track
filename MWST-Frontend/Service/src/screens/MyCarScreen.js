import React, { useState, useEffect } from "react";
import { View, Text, Image, StyleSheet, useWindowDimensions } from "react-native";
import Car from '../../assets/CarPlaceholder.png'
import ProgressBar from "../components/ProgressBar";
import theme from "../Theme";

const MyCarScreen = () => {
    const { height, width } = useWindowDimensions()
    const [ index, setIndex ] = useState(0)

    // useEffect(() => {
    //     const interval = setInterval(() => {
    //         setIndex((index + 1) % (10 + 1))
    //     }, 1000);

    //     return () => {
    //         clearInterval(interval)
    //     }
    // }, [index])

    return (
        <View style={styles.container}>
            <View style={styles.centeredContainer}>
                <Image source={Car} style={{height: height * 0.3, width: width * 0.85}}/>
                <View style={styles.progressText}>
                    <Text style={{flex: 2}}>Tiempo estimado:</Text>
                    <View style={{flex: 0.9}}></View>
                    <Text style={{flex: 1}}>5 Horas</Text>
                </View>
            </View>
            <ProgressBar step={0} steps={10} height={20} />
            <View style={styles.updatesContainer}>
                <Text>Actualización en vivo:</Text>
                <Text> - Chequeo rutinario</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.bgColor,
        padding: 20,
    },
    centeredContainer: {
        alignItems: 'center',
    },
    progressText: {
        flexDirection: 'row',
        padding: 5,
        width: 250,
        marginTop: 25
    },
    updatesContainer: {
        alignSelf: 'center',
        backgroundColor: 'white',
        width: 250,
        height: 250,
        padding: 5,
        marginTop: 15
    },
    progressBar: {

    },
})

export default MyCarScreen