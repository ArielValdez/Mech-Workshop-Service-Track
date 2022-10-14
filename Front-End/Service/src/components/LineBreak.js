import React from "react"
import { View, Text, StyleSheet } from "react-native"

const LineBreak = ({marginHorizontal}) => {
    return (
        <View style={[
            styles.linebreak, 
            marginHorizontal ? {marginHorizontal: marginHorizontal} : {} 
        ]}>
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