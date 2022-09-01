import React from "react"
import { Pressable, Image } from "react-native"

const ImageButton = ({source, width, height, onPress}) => {
    return (
        <Pressable onPress={onPress}>
            <Image 
                source={source}
                style={{width: width, height: height}}
            />
        </Pressable>
    )
}

export default ImageButton