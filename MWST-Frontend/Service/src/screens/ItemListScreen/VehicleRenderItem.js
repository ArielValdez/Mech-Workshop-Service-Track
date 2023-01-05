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

const VehicleRenderItem = ({ item, onDeleteCallback }) => {
    const navigation = useNavigation()

    const onEditPress = () => {
        navigation.navigate('AddVehicle', { isEditing: true, vehicle: item })
    }

    const onDeletePress = () => {
        deleteVehicle(item.id)
            .then(result => onDeleteCallback())
            .catch(err => console.log(err))
    }

    return (
        <View style={styles.container}>
            <View style={styles.dataContainer}>
                <View style={styles.firstColumn}>
                    <FontAwesome5 name='car' size={40} color={theme.colors.darkPrimary} />
                </View>
                <View style={styles.secondColumn}>
                    <CustomText>{item.plate}</CustomText>
                    <CustomText>{item.model}</CustomText>
                    <CustomText>{item.vin}</CustomText>
                </View>
                <View style={styles.thirdColumn}>
                    <PressableOpacity animatedViewStyle={styles.icons} onPress={onEditPress}>
                        <AntDesign name='edit' size={30} />
                    </PressableOpacity>
                    <PressableOpacity animatedViewStyle={styles.icons} onPress={onDeletePress}>
                        <AntDesign name='delete' size={30} />
                    </PressableOpacity>
                </View>
            </View>
            <LineBreak />
        </View>
    )
}

const styles = StyleSheet.create({
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

export default VehicleRenderItem