import React, { useRef, useState } from "react";
import { View, TextInput, StyleSheet, Text } from 'react-native'
import theme from '../Theme'
import CustomText from "./CustomText";

const CustomInput = ({value, setValue, placeholder, secureTextEntry, keyboardType, errorMessage, pattern, padding, bgColor}) => {
    const [ showErrorText, setShowErrorText ] = useState(false)

    const handleChange = (value) => {
        if (typeof pattern !== 'undefined') {
            const regex = new RegExp(pattern)
            if (regex.test(value)) {
                setShowErrorText(false)
            }
            else {
                setShowErrorText(true)
            }
        }

        setValue(value)
    }

    return (
        <View style={styles.container}>
            <View style={[styles.inputContainer, bgColor ? {backgroundColor: bgColor} : {}]}>
                <TextInput style={[styles.textInput, padding ? {padding: padding} : {}]}
                    value={value}
                    onChangeText={handleChange}
                    placeholder={placeholder}
                    placeholderTextColor={'rgba(0, 0, 0, 0.6)'}
                    secureTextEntry={secureTextEntry}
                    keyboardType={keyboardType}
                />
            </View>
            { showErrorText &&
                <CustomText style={styles.errorMessage} >
                    {errorMessage}
                </CustomText>
            }
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        width: '100%',
    },
    inputContainer: {
        backgroundColor: 'rgba(240, 231, 84, 0.5)',
        width: '100%',

        borderColor: theme.colors.darkSecondary,
        borderWidth: 1,
        borderRadius: 5,

        paddingHorizontal: 10,
        paddingVertical: 5,
        marginVertical: 5
    },
    textInput: {
        fontFamily: 'UbuntuRegular',
        fontWeight: 'normal',
    },
    errorMessage: {
        color: 'red',
    },
})

export default CustomInput