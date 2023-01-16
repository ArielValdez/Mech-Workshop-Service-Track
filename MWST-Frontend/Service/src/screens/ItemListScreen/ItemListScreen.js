import { useIsFocused, useNavigation} from "@react-navigation/native"
import { useCallback, useEffect, useState, useRef } from "react"
import { useTranslation } from "react-i18next"
import { ScrollView, View, FlatList, Text, StyleSheet, Pressable } from "react-native"
import CustomButton from "../../components/CustomButton"
import theme from "../../Theme"
import { useUser } from "../../context/UserContext"
import { getAllVehicles, deleteVehicle } from "../../services/VehicleService"
import { getAllCards, deleteCard } from "../../services/CreditCardsService"
import VehicleRenderItem from "./VehicleRenderItem.js"
import CreditCarRenderItem from "./CreditCarRenderItem.js"

const ItemListScreen = ({ route }) => {
    const [ items, setItems ] = useState()

    const [ user, setUser ] = useUser()
    const navigation = useNavigation()
    const { t, i18n } = useTranslation()
    const isFocused = useIsFocused()
    const isVehicleList = useRef(false)
    

    useEffect(() => {
        if (route.params.isVehicleList) {
            loadVehicleList()
            isVehicleList.current = true
        }
        else {
            loadCreditCardList()
            isVehicleList.current = false
        }
    }, [])

    useEffect(() => {
        if (isFocused && route.params?.shouldRefresh) {
            if (isVehicleList.current) {
                loadVehicleList()
            }
            else {
                loadCreditCardList()
            }
        }
    }, [isFocused])

    const loadVehicleList = useCallback(() => {
        getAllVehicles(user.id)
            .then(vehicles => setItems(vehicles))
            .catch(err => console.log(err))
    }, [user])

    const loadCreditCardList = useCallback(() => {
        getAllCards(user.id)
            .then(cards => setItems(cards))
            .catch(err => console.log(err))
    }, [user])

    const onAddButtonPress = () => {
        if (route.params?.isVehicleList || isVehicleList.current) {
            navigation.navigate('AddVehicle', { isEditing: false })
        }
        else {
            navigation.navigate('EditCreditCard', { isEditing: false })
        }   
    }

    const getAddButtonText = () => {
        if (route.params?.isVehicleList || isVehicleList.current) {
            return t('addVehicle')
        }
        else {
            return t('addCreditCard')
        }
    }

    return (
        <View style={styles.container}>
            <FlatList
                style={styles.vehicleList} 
                data={items}
                renderItem={({ item }) => {
                        if (isVehicleList.current) {
                            return (
                                <VehicleRenderItem 
                                    item={item} 
                                    onDeleteCallback={loadVehicleList}
                                />
                            )
                        }
                        else {
                            return (
                                <CreditCarRenderItem 
                                    item={item}
                                    onDeleteCallback={loadCreditCardList}
                                />
                            )
                        }
                    }
                }
                keyExtractor={item => item.id}
            />
            <View style={styles.addButton}>
                <CustomButton onPress={onAddButtonPress} text={getAddButtonText()} />
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        padding: 20,
    },
    vehicleList: {
        flexGrow: 0,
        minHeight: 100,
        maxHeight: 550,
    },
    addButton: {
        marginTop: 25
    },
})

export default ItemListScreen