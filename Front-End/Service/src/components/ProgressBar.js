import React, { useRef, useState, useEffect } from 'react'
import { View, Text, StyleSheet, Animated, useWindowDimensions } from 'react-native'

const ProgressBar = ({step, steps, height}) => {
    const [width, setWidth] = useState(0)
    const animatedValue = useRef(new Animated.Value(-1000)).current
    const reactive = useRef(new Animated.Value(-1000)).current

    useEffect(() => {
        Animated.timing(animatedValue, {
            toValue: reactive,
            duration:  300,
            useNativeDriver: true,
        }).start()
    }, [])


    useEffect(() => {
        reactive.setValue(-width + (width * step) / steps)
    }, [step, width])

    return (
        <>
            <Text style={{
                fontSize: 12,
                fontWeight: '900',
                marginBottom: 4,
                alignSelf: 'center',
            }}>
                ${step}/${steps}
            </Text>
            <View onLayout={(e) => {
                const newWidth = e.nativeEvent.layout.width
                setWidth(newWidth)
            }} 
            style={{
                height, 
                backgroundColor: 'rgba(0,0,0,0.1)',
                borderRadius: height,
                overflow: 'hidden',
                width: '85%',
                alignSelf: 'center'
            }}>
                <Animated.View style={{
                    height,
                    width: '100%',
                    borderRadius: height,
                    backgroundColor: 'rgba(0,0,0,0.5)',
                    position: 'absolute',
                    left: 0,
                    top: 0,
                    transform: [{
                        translateX: animatedValue
                    }]
                }}>

                </Animated.View>
            </View>
        </>
    )
}

const styles = StyleSheet.create({
    container: {

    },
})

export default ProgressBar