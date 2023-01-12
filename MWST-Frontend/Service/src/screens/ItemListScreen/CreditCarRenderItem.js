import { useNavigation, useFocusEffect, useNavigationState } from "@react-navigation/native"
import { useCallback, useEffect, useState } from "react"
import { useTranslation } from "react-i18next"
import { ScrollView, View, FlatList, Text, StyleSheet, Pressable } from "react-native"
import CustomButton from "../../components/CustomButton"
import CustomText from "../../components/CustomText"
import LineBreak from "../../components/LineBreak"
import { FontAwesome, AntDesign } from "@expo/vector-icons"
import theme from "../../Theme"
import { useUser } from "../../context/UserContext"
import { getAllVehicles, deleteVehicle } from "../../services/VehicleService"
import { getAllCards, createCard, editCard, deleteCard } from "../../services/CreditCardsService"
import PressableOpacity from "../../components/PressableOpacity"

const CreditCarRenderItem = ({ item, onDeleteCallback }) => {
    const navigation = useNavigation()

    const formatCardNumbers = (numbers) => {
        return (
            numbers.substring(0, 4) + '-' + numbers.substring(4, 8) + '-'
            + numbers.substring(8, 12) + '-' + numbers.substring(12, 16)
        )
    }

    const onEditPress = () => {
        navigation.navigate('EditCreditCard', { isEditing: true, creditCard: item })
    }

    const onDeletePress = () => {
        deleteCard(item.id)
            .then(result => onDeleteCallback())
            .catch(err => console.log(err))
    }

    return (
        <View style={styles.container}>
            <View style={styles.dataContainer}>
                <View style={styles.firstColumn}>
                    <FontAwesome name='credit-card' size={40} color={theme.colors.darkPrimary} />
                </View>
                <View style={styles.secondColumn}>
                    <CustomText>{formatCardNumbers(item.numbers)}</CustomText>
                    <CustomText>{item.expirationDate}</CustomText>
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

export default CreditCarRenderItem