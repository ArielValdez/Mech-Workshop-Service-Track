import { useEffect, useState, useRef } from "react"
import { ScrollView, StyleSheet, View, Text, Image, useWindowDimensions } from "react-native"
import CustomInput from "../../components/Inputs/CustomInput"
import CustomButton from "../../components/CustomButton"
import { useTranslation } from "react-i18next"
import { useNavigation } from "@react-navigation/native"
import { useUser } from "../../context/UserContext"
import Logo from "../../../assets/LogoOficial.png"
import { createVehicle, editVehicle } from "../../services/VehicleService"
import * as ImagePicker from 'expo-image-picker'
import theme from "../../Theme"

const plateRegex = /^[A-Z0-9]{5,10}$/
const modelRegex = /^[\w]{3,50}$/
const vinRegex = /^[A-Z0-9]{17}$/

const AddVehicleScreen = ({ route }) => {

    const [ user, setUser ] = useUser()
    const [ plate, setPlate ] = useState('')
    const [ model, setModel ] = useState('')
    const [ vin, setVin ] = useState('')
    const [ carImageUri, setCarImageUri ] = useState(null)
    const [ showAllErrorMessages, setShowAllErrorMessages ] = useState(false)

    const navigation = useNavigation()
    const { height, width } = useWindowDimensions()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        if (route.params.isEditing) {
            setPlate(route.params.vehicle.plate)
            setModel(route.params.vehicle.model)
            setVin(route.params.vehicle.vin)
        }
    }, [])

    const pickImage = async () => {
        const result = await ImagePicker.launchImageLibraryAsync({
            mediaTypes: ImagePicker.MediaTypeOptions.All,
            allowsEditing: true,
            aspect: [4, 3],
            quality: 1
        })

        console.log(result)

        if (!result.cancelled) {
            setCarImageUri(result.uri)
        }
        else {
            console.log('Failed to collect image')
        }
    }

    const onSavePress = () => {
        // TODO: Handle empty or incorrect inputs
        if (plate == '' || model == '' || vin == '') {
            setShowAllErrorMessages(true)
            alert(t('emptyInputsAlert'))
            return 
        } 

        if (!route.params.isEditing) {
            createVehicle(user.id, plate, model, vin)
                .then(result => {
                    navigation.navigate('ItemList', { shouldRefresh: true })
                })
                .catch(err => console.log(err))
        }
        else {
            editVehicle(route.params.vehicle.id, user.id, plate, model, vin)
                .then(result => {
                    navigation.navigate('ItemList', { shouldRefresh: true })
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

            <CustomInput placeholder={t('plate')} value={plate} setValue={setPlate} showErrorMessage={showAllErrorMessages}
                autoCapitalize='characters' pattern={plateRegex} errorMessage={t('invalidPlateMessage')} maxLength={10}/>
            <CustomInput placeholder={t('model')} value={model} setValue={setModel} showErrorMessage={showAllErrorMessages}
                maxLength={50} pattern={modelRegex} errorMessage={t('invalidModelMessage')}/>
            <CustomInput placeholder={t('vin')} value={vin} setValue={setVin} showErrorMessage={showAllErrorMessages}
                autoCapitalize='characters' maxLength={17} pattern={vinRegex} errorMessage={t('invalidVinMessage')}/>

            <View>
                <CustomButton text={t('pickImageText')} onPress={pickImage} 
                    bgColor={theme.colors.lightSecondary} fgColor={theme.colors.black} />
                { carImageUri && 
                <Image 
                    source={{ uri: carImageUri }}
                    style={{ height: height * 0.3, width: width * 0.8 }}
                    resizeMode='contain'
                />
                }
            </View>

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