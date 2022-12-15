import { useRef } from "react"
import { Pressable, View, Animated } from "react-native"

const PressableOpacity = ({ onPress, children, pressableStyle, animatedViewStyle }) => {
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
            style={pressableStyle}
        >
            <Animated.View 
                style={[
                    animatedViewStyle,
                    { opacity: animatedOpacity }
                ]}
            >
                {children}
            </Animated.View>
		</Pressable>
	);
}

export default PressableOpacity