import { useEffect, useState } from "react"
import { Audio } from "expo-av"

const SoundEffect = ({ soundAsset }) => {
    const [ sound, setSound ] = useState()

    useEffect(() => {
        const { mySound } = Audio.Sound.createAsync(soundAsset)
        setSound(mySound)
        mySound.playAsync()

        return cleanup = () => {
            if (sound) {
                sound.unloadAsync()
            }
        }
    }, [sound])

    return (
        <>
        </>
    )
}

export default SoundEffect