import { React, useState } from 'react'
import { ScrollView, View, StyleSheet, FlatList, Text } from "react-native"
import { useNavigation } from "@react-navigation/native";
import { Ionicons, MaterialIcons } from '@expo/vector-icons'
import LineBreak from '../components/LineBreak'
import CustomButton from '../components/CustomButton'
import theme from '../Theme';

const carRenderItem = ({item}) => {
    return (
        <View style={carStyles.container}>
            <Text style={carStyles.brand}>{item.marca}</Text>
            <Text style={carStyles.model}>{item.modelo} {item.añoModelo}</Text>
            <Text style={carStyles.plateNumber}>{item.matricula}</Text>
            <LineBreak style={carStyles.lineBreak} height={2.5}/>
        </View>
    )
}

const carStyles = StyleSheet.create({
    container: {
        padding: 10,
    },
    brand: {
        fontWeight: 'bold'
    },
    model: {

    },
    plateNumber: {
        marginBottom: 5,
    },
})

const AccountDataScreen = () => {
    const defaultCars = [
        { id: 1, marca: 'Toyota', modelo: 'C    amry', añoModelo: '1993', matricula: 'YX01405' }
    ]

    const [ cars, setCars ] = useState(defaultCars)
    const navigation = useNavigation()

    const onAddVehiclePress = () => {
        //navigate to corresponding page
    }

    return (
        <View style={styles.container}>
            <MaterialIcons style={styles.accountIcon} name='account-circle' size={200}/>
            <Text style={styles.name}>Carlos Roque</Text>
            <View style={styles.accountDataContainer}>
                <Text style={styles.carsHeader}>Automóviles</Text>
                <FlatList
                    data={cars}
                    renderItem={carRenderItem}
                    keyExtractor={item => item.id}
                />
                <CustomButton onPress={onAddVehiclePress} text='Agregar nuevo vehículo' width='60%'/>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.bgColor,
    },  
    accountIcon: {
        alignSelf: 'center',
    },
    name: {
        fontSize: 28,
        textAlign: 'center'
    },
    accountDataContainer: {
        padding: 20
    },
    carsHeader: {
        textAlign: 'left'
    },
})

export default AccountDataScreen