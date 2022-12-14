import { useNavigation, useFocusEffect, useNavigationState } from "@react-navigation/native"
import { useEffect, useState } from "react"
import { useTranslation } from "react-i18next"
import { ScrollView, View, FlatList, Text, StyleSheet, Pressable } from "react-native"
import CustomButton from "../components/CustomButton"
import LineBreak from "../components/LineBreak"
import { FontAwesome5, AntDesign } from "@expo/vector-icons"
import theme from "../Theme"
import { useUser } from "../context/UserContext"
import { getAllVehicles, deleteVehicle } from "../services/VehicleService"

const VehicleRenderItem = ({ item, onDeleteCallback, refreshCallback }) => {
    const navigation = useNavigation()

    const onEditPress = () => {
        navigation.navigate('AddVehicle', { refreshCallback: refreshCallback, isEditing: true, vehicle: item })
    }

    const onDeletePress = () => {
        deleteVehicle(item.id)
            .then(result => onDeleteCallback())
            .catch(err => console.log(err))
    }

    return (
        <View style={itemStyles.container}>
            <View style={itemStyles.dataContainer}>
                <View style={itemStyles.firstColumn}>
                    <FontAwesome5 name='car' size={40} color={theme.colors.darkPrimary} />
                </View>
                <View style={itemStyles.secondColumn}>
                    <Text>{item.plate}</Text>
                    <Text>{item.model}</Text>
                    <Text>{item.vin}</Text>
                </View>
                <View style={itemStyles.thirdColumn}>
                    <Pressable style={itemStyles.icons} onPress={onEditPress}>
                        <AntDesign name='edit' size={30} />
                    </Pressable>
                    <Pressable style={itemStyles.icons} onPress={onDeletePress}>
                        <AntDesign name='delete' size={30} />
                    </Pressable>
                </View>
            </View>
            <LineBreak />
        </View>
    )
}

const itemStyles = StyleSheet.create({
    container: {
        marginVertical: 5,
    },
    dataContainer: {
        flexDirection: 'row',
    },
    firstColumn: {
        flex: 1,
        marginRight: 15,
        justifyContent: 'center'
    },
    secondColumn: {
        flex: 4,
        paddingVertical: 5,
    },
    thirdColumn: {
        flex: 2,
        flexDirection: 'row',
        alignItems: 'center',
    },
    icons: {
        marginHorizontal: 7,
    }
})

const VehicleListScreen = () => {
    const [ vehicles, setVehicles ] = useState()

    const [ user, setUser ] = useUser()
    const navigation = useNavigation()
    const { t, i18n } = useTranslation()

    useEffect(() => {
        loadVehicleList()
    }, [])

    const loadVehicleList = () => {
        getAllVehicles(user.id)
            .then(vehicles => setVehicles(result))
            .catch(err => console.log(err))
    }

    const onAddVehiclePress = () => {
        navigation.navigate('AddVehicle', { refreshCallback: loadVehicleList, isEditing: false })
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