import React, { useRef } from "react";
import { View, Text, StyleSheet, Pressable, Animated } from "react-native"
import theme from '../Theme'

//  TODO: reduce the amount of code here by use the PressableOpacity component 
const CustomButton = ({ onPress, text, type = 'Primary', bgColor, fgColor, marginVertical, padding, width}) => {
    const animatedOpacity = useRef(new Animated.Value(1)).current

    const fadeIn = () => {
        Animated.timing(animatedOpacity, {
            toValue: 0.4,
            duration: 150,
            useNativeDriver: true
        }).start()
    }

    const fadeOut = () => {
        Animated.timing(animatedOpacity, {
            toValue: 1,
            duration: 250,
            useNativeDriver: true
        }).start()
    }

    return (
        <Pressable
            onPressIn={fadeIn}
            onPressOut={fadeOut} 
            onPress={onPress}
            style={[
                { width: '100%'}, 
                width ? { width: width } : {}
            ]} 
        >
            <Animated.View style={[
                styles.container,
                styles[`container${type}`],
                bgColor ? { backgroundColor: bgColor } : {},
                marginVertical ? { marginVertical: marginVertical } : {},
                padding ? { padding: padding } : {},
                { opacity: animatedOpacity },
            ]}>
                <Text 
                    style={[
                        styles.text,
                        styles[`text${type}`],
                        fgColor ? {color: fgColor} : {}
                    ]}
                >
                    {text}
                </Text>
            </Animated.View>
        </Pressable>
    )
}

const styles = StyleSheet.create({
    container: {
        padding: 15,
        marginVertical: 5,
        alignItems: 'center',
        borderRadius: 5
    },

    containerPrimary: {
        backgroundColor: theme.colors.darkPrimary,
    },
    containerSecondary: {
        backgroundColor: 'white',
        borderColor: theme.colors.darkPrimary,
        borderWidth: 2,
    },
    containerTertiary: {
    },

    text: {
        fontFamily: 'UbuntuBold',
        color: 'white',
    },
    textSecondary: {
        color: '#3B71F3',
    },
    textTertiary: {
        color: '#f2f0f0',
    }
})

export default CustomButton