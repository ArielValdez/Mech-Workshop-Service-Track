import React from "react"
import { View, Text, StyleSheet } from "react-native"

const LineBreak = () => {
    return (
        <View style={styles.linebreak}>
            <Text></Text>
        </View>
    )
}

const styles = StyleSheet.create({
    linebreak: {
        backgroundColor: 'black',
        alignSelf: 'stretch', 
        height: StyleSheet.hairlineWidth,
    }
})

export default LineBreak