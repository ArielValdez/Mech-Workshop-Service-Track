import { useEffect, useState } from "react"
import { ScrollView, StyleSheet, View, Text, Image, useWindowDimensions } from "react-native"
import CustomInput from "../components/CustomInput"
import CustomButton from "../components/CustomButton"
import theme from "../Theme"
import { useTranslation } from "react-i18next"
import { useNavigation } from "@react-navigation/native"
import { useUser } from "../context/UserContext"
import Logo from "../../assets/LogoOficial.png"


const AddVehicleScreen = ({ route }) => {

    const [ user, setUser ] = useUser()
    const [ plate, setPlate ] = useState('')
    const [ model, setModel ] = useState('')
    const [ vin, setVin ] = useState('')

    const navigation = useNavigation()
    const { height, width } = useWindowDimensions()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        if (route.params.vehicle !== undefined) {
            setPlate(route.params.vehicle.plate)
            setModel(route.params.vehicle.model)
            setVin(route.params.vehicle.vin)
        }
    }, [])

    const onSavePress = () => {
        if (plate == '' || model == '' || vin == '') {
            alert(t('emptyInputsAlert'))
        } 

        if (!route.params.isEditing) {
            fetch('http://10.0.0.7:3000/vehicles', {
                method: 'POST',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    user_id: user.id,
                    plate: plate,
                    model: model,
                    vin: vin
                })
            })
                .then(response => {
                    if (response.ok) {
                        route.params.refreshCallback()
                        navigation.goBack()
                    }
                })
                .catch(err => console.log(err))
        }
        else {
            fetch(`http://10.0.0.7:3000/vehicles/${route.params.vehicle.id}`, {
                method: 'PUT',
                headers: {
                    'Content-type': 'application/json'
                },
                body: JSON.stringify({
                    plate: plate,
                    model: model,
                    vin: vin
                })
            })
                .then(response => {
                    if (response.ok) {
                        route.params.refreshCallback()
                        navigation.goBack()
                    }
                })
                .catch(err => console.log(err))
        }
        

    }

    return (
        <View style={styles.container}>
            <Image 
                source={Logo}
                style={[styles.logo, { height: height * 0.3, width: width * 0.75 }]}
                resizeMode='contain'
            />

            <CustomInput placeholder={t('plate')} value={plate} setValue={setPlate} />
            <CustomInput placeholder={t('model')} value={model} setValue={setModel} />
            <CustomInput placeholder={t('vin')} value={vin} setValue={setVin} />

            <View style={styles.saveButton}>
                <CustomButton onPress={onSavePress} text={t('save')} />
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        padding: 20,
    },
    logo: {
        alignSelf: 'center',
    },
    saveButton: {
        marginTop: 20
    },
})

export default AddVehicleScreen