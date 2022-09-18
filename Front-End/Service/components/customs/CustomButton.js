import React from "react";
import { View, Text, StyleSheet, Pressable } from "react-native";

const CustomButton = ({ onPress, text, type = 'Primary', bgColor, fgColor, marginVertical, padding}) => {
    return (
        <Pressable 
            onPress={onPress} 
            style={[
                styles.container,
                styles[`container${type}`],
                bgColor ? {backgroundColor: bgColor} : {},
                marginVertical ? {marginVertical: marginVertical} : {},
                padding ? {padding: padding} : {}
            ]}
        >
            <Text 
                style={[
                    styles.text,
                    styles[`text${type}`],
                    fgColor ? {color: fgColor} : {}
                ]}
            >
                {text}
            </Text>
        </Pressable>
    )
}

const styles = StyleSheet.create({
    container: {       
        width: '100%',
        padding: 15,
        marginVertical: 5,

        alignItems: 'center',
        borderRadius: 5
    },

    containerPrimary: {
        backgroundColor: '#3B71F3'
    },
    containerSecondary: {
        backgroundColor: 'white',
        
        borderColor: '#3B71F3',
        borderWidth: 2,
    },
    containerTertiary: {

    },

    text: {
        fontWeight: 'bold',
        color: 'white'
    },
    textSecondary: {
        color: '#3B71F3',
    },
    textTertiary: {
        color: 'gray'
    }
})

export default CustomButton