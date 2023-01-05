import { useEffect, useState } from "react"
import { View, StyleSheet } from "react-native"
import CustomInput from "../../components/Inputs/CustomInput"
import CustomText from "../../components/CustomText"
import { useTranslation } from "react-i18next"
import CustomButton from "../../components/CustomButton"
import { editCard, createCard } from "../../services/CreditCardsService"
import { useUser } from "../../context/UserContext"

const CreditCarEditScreen = ({route}) => {
    const [ cardNumber1, setCardNumber1 ] = useState()
    const [ cardNumber2, setCardNumber2 ] = useState()
    const [ cardNumber3, setCardNumber3 ] = useState()
    const [ cardNumber4, setCardNumber4 ] = useState()
    const [ expirationDate, setExpirationDate ] = useState()
    const [ cvv, setCvv ] = useState()
    const [ cardHolderName, setCardHolderName ] = useState() 

    const { t, i18n } = useTranslation()
    const user = useUser()

    useEffect(() => {
        if (route.params.isEditing) {
            const card = route.params.creditCard
            setCardNumber1(card.numbers.substring(0, 4))
            setCardNumber2(card.numbers.substring(4, 8))
            setCardNumber3(card.numbers.substring(8, 12))
            setCardNumber4(card.numbers.substring(12, 16))
            setExpirationDate(card.expiration_date)
            setCvv(card.cvv)
            setCardHolderName(card.name)
        }
    }, [])

    const onSavePress = () => {
        // Check for validity before editing/creating
        if (route.params.isEditing) {
            editCard(route.params.creditCard.id, user.id, numbers, expirationDate, cvv, cardHolderName)
                .then(result => console.log(result))
                .catch(err => console.log(err))
        }
        else {
            createCard(user.id, numbers, expirationDate, cvv, cardHolderName)
                .then(result => console.log(result))
                .catch(err => console.log(err))
        }
    }

    return (
        <View style={styles.container}>
            <View>
                <CustomText type="Medium">Número de tarjeta</CustomText>
                <View style={styles.cardNumberRow}>
                    <View style={styles.numberInput}>
                        <CustomInput value={cardNumber1} setValue={setCardNumber1} maxLength={4} keyboard-type="number-pad" />
                    </View>
                    <View style={styles.numberInput}>
                        <CustomInput value={cardNumber2} setValue={setCardNumber2} maxLength={4} keyboard-type="number-pad" />
                    </View> 
                    <View style={styles.numberInput}>
                        <CustomInput value={cardNumber3} setValue={setCardNumber3} maxLength={4} keyboard-type="number-pad" />
                    </View> 
                    <View style={styles.numberInput}>
                        <CustomInput value={cardNumber4} setValue={setCardNumber4} maxLength={4} keyboard-type="number-pad" />
                    </View> 
                </View>
            </View>
            <View style={styles.secondRow}>
                <View style={styles.secondRowItem}>
                    <CustomText type="Medium">Fecha de vto.</CustomText>
                    <CustomInput value={expirationDate} setValue={setExpirationDate}/>
                </View>
                <View style={styles.secondRowItem}>
                    <CustomText type="Medium">CVV</CustomText>
                    <CustomInput value={cvv} setValue={setCvv} placeholder='426'
                        maxLength={3} keyboard-type="number-pad"/>
                </View>
            </View>
            <View style={styles.thirdRow}>
                <CustomText type="Medium">Nombre</CustomText>
                <CustomInput value={cardHolderName} setValue={setCardHolderName} />
            </View>

            <CustomButton text={t('save')} onPress={onSavePress} />
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 10,
    },
    cardNumberRow: {
        flexDirection: 'row'
    },
    numberInput: {
        flex: 1,
        marginHorizontal: 3,
    },
    secondRow: {
        flexDirection: 'row'
    },
    secondRowItem: {
        flex: 1,
        marginHorizontal: 5,
    },
    thirdRow: {

    }
})

export default CreditCarEditScreen