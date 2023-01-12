import React, { useState, useEffect } from "react";
import { View, Text, Image, StyleSheet, useWindowDimensions } from "react-native";
import Car from '../../assets/tesla.png'
import ProgressBar from "../components/ProgressBar";
import CustomText from "../components/CustomText";
import { useUser } from "../context/UserContext";
import theme from "../Theme";
import { BarIndicator, WaveIndicator } from "react-native-indicators";
import { Ionicons } from "@expo/vector-icons"
import { useTranslation } from "react-i18next";

const ServiceStateFeedback = ({ service }) => {
    const { t, i18n } = useTranslation() 

    if (service) {
        if (service.state == 'In Process') {
            return (
                <View style={{alignItems: 'center'}}>
                    <BarIndicator style={{marginVertical: 25}} color={theme.colors.black} count={8} size={40}/>
                    <CustomText style={{fontSize: 17}} type="Medium">{service.state}</CustomText>
                </View>
            )
        }
        else if (service.state == 'Finished') {
            return (
                <View>
                    <Ionicons name="checkmark-done" size={40} color={theme.colors.black}/>
                    <CustomText style={{fontSize: 17}} type="Medium">{service.state}</CustomText>
                </View>
            )
        }
    }
    else {
        return (
            <View>
                <CustomText style={{fontSize: 17}} type="Medium">{t('noServiceInProgress')}</CustomText>
            </View>
        )
    }
}

const MyCarScreen = () => {
    const { height, width } = useWindowDimensions()
    const [ index, setIndex ] = useState(0)
    const [ service, setService ] = useState()

    const { t, i18n } = useTranslation()
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
        fetch(`http://10.0.0.7:3000/services?userId=${user.id}`, {
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
                <CustomText style={{fontSize: 20, marginBottom: 10, alignSelf: 'center'}} type="Bold">{t('serviceState')}</CustomText>
                <Image source={Car} style={{height: height * 0.65, width: width * 0.9, resizeMode: 'stretch', backgroundColor: 'white'}}/>
                <ServiceStateFeedback service={service}/>
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
        textAlign: 'center'
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