import { useNavigation, useFocusEffect, useNavigationState } from "@react-navigation/native"
import { useCallback, useEffect, useState } from "react"
import { useTranslation } from "react-i18next"
import { ScrollView, View, FlatList, Text, StyleSheet, Pressable } from "react-native"
import CustomButton from "../../components/CustomButton"
import CustomText from "../../components/CustomText"
import LineBreak from "../../components/LineBreak"
import { FontAwesome5, AntDesign } from "@expo/vector-icons"
import theme from "../../Theme"
import { useUser } from "../../context/UserContext"
import { getAllVehicles, deleteVehicle } from "../../services/VehicleService"
import PressableOpacity from "../../components/PressableOpacity"
import VehicleRenderItem from "./VehicleRenderItem.js"

const VehicleListScreen = ({ route }) => {
    const [ vehicles, setVehicles ] = useState()

    const [ user, setUser ] = useUser()
    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        loadVehicleList()
    }, [])

    useEffect(() => {
        if (route.params?.shouldRefresh) {
            loadVehicleList()
        }
    }, [route.params?.shouldRefresh])

    const loadVehicleList = useCallback(() => {
        getAllVehicles(user.id)
            .then(vehicles => setVehicles(vehicles))
            .catch(err => console.log(err))
    }, [user])

    const onAddVehiclePress = () => {
        navigation.navigate('AddVehicle', { isEditing: false })
    }

    return (
        <View style={styles.container}>
            <FlatList
                style={styles.vehicleList} 
                data={vehicles}
                renderItem={({ item }) => 
                    <VehicleRenderItem 
                        item={item} 
                        onDeleteCallback={loadVehicleList}
                        refreshCallback={loadVehicleList}
                    />}
                keyExtractor={item => item.id}
            />
            <View style={styles.addButton}>
                <CustomButton onPress={onAddVehiclePress} text={t('addVehicle')} />
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

export default VehicleListScreen