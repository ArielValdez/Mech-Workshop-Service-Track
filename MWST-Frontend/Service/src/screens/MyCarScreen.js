import React, { useState, useEffect } from "react";
import { View, Text, Image, StyleSheet, useWindowDimensions } from "react-native";
import Car from '../../assets/tesla.png'
import ProgressBar from "../components/ProgressBar";
import CustomText from "../components/CustomText";
import { useUser } from "../context/UserContext";
import theme from "../Theme";
import { BarIndicator, WaveIndicator } from "react-native-indicators";

const ServiceState = ({state}) => {
    if (state == "In Process") {
        return (
            <View>
                <Text>El servicio se encuentra en progreso</Text>
            </View>
        )
    }
    else if (state == 'Finished') {
        return (
            <View>
                <Text>El servicio ha sido finalizado</Text>
            </View>
        )
    }
    else {
        return (
            <View>
                <Text>El servicio no ha comenzado</Text>
            </View>
        )
    }
}

const MyCarScreen = () => {
    const { height, width } = useWindowDimensions()
    const [ index, setIndex ] = useState(0)
    const [ service, setService ] = useState()
    const [ user, setUser ] = useUser()

    // useEffect(() => {
    //     const interval = setInterval(() => {
    //         setIndex((index + 1) % (10 + 1))
    //     }, 1000);

    //     return () => {
    //         clearInterval(interval)
    //     }
    // }, [index])

    useEffect(() => {
        fetch(`http://10.0.0.7:3000/services?user_id=${user.id}`, {
            method: 'GET',
        })
            .then(response => response.json())
            .then(result => {
                setService(result[0])
            })
            .catch(err => console.log(err))
    }, [])

    return (
        <View style={styles.container}>
            <View style={styles.centeredContainer}>
                <CustomText style={{fontSize: 20, marginBottom: 10}} type="Bold">Estado del servicio</CustomText>
                <Image source={Car} style={{height: height * 0.65, width: width * 0.9, resizeMode: 'stretch', backgroundColor: 'white'}}/>
                <BarIndicator style={{marginTop: 20}} color={theme.colors.black} count={8} size={40}/>
                <View style={styles.progressText}>
                    {   /* 
                    <Text style={{flex: 2}}>Tiempo estimado:</Text>
                    <View style={{flex: 0.9}}></View>
                    <Text style={{flex: 1}}>5 Horas</Text>
                        */  }
                    <View>
                        { service === undefined ? (
                            <CustomText>No existe ningún servicio en progreso</CustomText>
                        ) : (
                            <CustomText style={{fontSize: 17}} type="Medium">{service.state}</CustomText>
                        )}
                    </View>
                </View>
            </View>
            <View style={styles.updatesContainer}>
                { service === undefined ? (
                    <View></View>
                ) : (
                    <ServiceState state={service.state} />
                )}
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.white,
        padding: 20,
    },
    centeredContainer: {
        alignItems: 'center',
    },
    progressText: {
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