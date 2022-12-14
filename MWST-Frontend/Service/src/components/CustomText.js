import { Text, StyleSheet } from "react-native";

// type: can be Regular, Medium or Bold.
const CustomText = ({ style, type = 'Regular', children }) => {
    return (
        <Text style={[styles.text, `font${type}`,style]}>
            {children}
        </Text>
    )
}

const styles = StyleSheet.create({
    text: {
        fontFamily: 'UbuntuRegular',
        fontWeight: 'normal'
    },
    fontRegular: {
        fontFamily: 'UbuntuRegular'
    },
    fontMedium: {
        fontFamily: 'UbuntuMedium',
    },
    fontBold: {
        fontFamily: 'UbuntuBold',
    }
})

export default CustomText