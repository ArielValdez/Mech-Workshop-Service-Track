import React from "react"
import { View, Text, StyleSheet } from "react-native"

// Note: Line breaks work with padding everywhere but will
// break when padding is applied dissimilarly to a parent view
const LineBreak = ({marginHorizontal, height}) => {
    return (
        <View style={[
            styles.linebreak, 
            marginHorizontal ? {marginHorizontal: marginHorizontal} : {},
            height ? {height: height} : {} 
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