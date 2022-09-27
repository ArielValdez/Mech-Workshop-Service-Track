import React, { useRef, useState } from "react";
import { View, TextInput, StyleSheet, Text } from 'react-native'

const CustomInput = ({value, setValue, placeholder, secureTextEntry, keyboardType, errorMessage, pattern}) => {
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

            setValue(value)
        }
    }

    return (
        <View style={styles.container}>
            <View style={styles.inputContainer}>
                <TextInput
                    value={value}
                    onChangeText={handleChange}
                    placeholder={placeholder}
                    secureTextEntry={secureTextEntry}
                    keyboardType={keyboardType}
                />
            </View>
            { showErrorText &&
                <Text
                    style={styles.errorMessage}
                >
                    {errorMessage}
                </Text>
            }
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        width: '100%'
    },
    inputContainer: {
        backgroundColor: 'white',
        width: '100%',

        borderColor: '#e8e8e8',
        borderWidth: 1,
        borderRadius: 5,

        paddingHorizontal: 10,
        paddingVertical: 5,
        marginVertical: 5
    },
    errorMessage: {
        color: 'red',
    },
})

export default CustomInput