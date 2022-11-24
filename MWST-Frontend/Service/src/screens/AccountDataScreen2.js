import { React, useState } from 'react'
import { ScrollView, View, StyleSheet, FlatList, Text, Pressable } from "react-native"
import { useNavigation } from "@react-navigation/native";
import { useTranslation } from 'react-i18next';
import { Ionicons, MaterialIcons, MaterialCommunityIcons, FontAwesome, Octicons, Entypo, AntDesign, FontAwesome5 } from '@expo/vector-icons'
import LineBreak from '../components/LineBreak'
import CustomButton from '../components/CustomButton'
import theme from '../Theme';
import DropDownPicker from 'react-native-dropdown-picker';
import { LocaleConfig } from 'react-native-calendars';

const AccountDataButton = ({text, greyedText, onPress, LeftIcon, RightIcon}) => {
    return (
        <View>
            <Pressable style={accountDataStyles.container} onPress={onPress}>
                <View style={accountDataStyles.leftIcon}>
                    <LeftIcon />
                </View>
                <Text style={greyedText ? accountDataStyles.greyedText : accountDataStyles.text}>{text}</Text>
                <View style={accountDataStyles.rightIcon}>
                    <RightIcon />
                </View>
            </Pressable>
            <LineBreak />
        </View>
    )
}

const accountDataStyles = StyleSheet.create({
    container: {
        flexDirection: 'row',
        marginHorizontal: 10, marginVertical: 10,
        paddingHorizontal: 10,
        alignItems: 'center',
    },
    leftIcon: {
        flex: 1,
    },
    text: {
        flex: 5,
        color: theme.colors.black,
        textAlign: 'center',
        paddingLeft: 15,
        fontSize: 16,
    },
    greyedText: {
        flex: 5,
        color: '#616160',
        textAlign: 'center',
        paddingLeft: 15,
        fontSize: 16,
    },
    rightIcon: {
        flex: 1
    },
})

const AccountDataScreen2 = () => {
    const { t, i18n } = useTranslation()

    const onLanguageSwitchPress = () => {
        if (i18n.language == 'es') {
            i18n.changeLanguage('en')
            LocaleConfig.defaultLocale = 'en'
        }
        else {
            i18n.changeLanguage('es')
            LocaleConfig.defaultLocale = 'es'
        } 
    }

    const onPaymentHistoryPress = () => { 
        console.log('payment history pressed')
    }

    return (
        <View style={styles.container}>
            <View style={styles.blueCircle}>
            </View>
            <MaterialIcons style={styles.accountIcon} name='account-circle' size={200}/>
            <View style={styles.accountDataContainer}>
                <AccountDataButton 
                    LeftIcon={() => <MaterialCommunityIcons name='face-man' size={40} color={theme.colors.darkPrimary} />} 
                    text='Carlos Roque'  
                    greyedText={true}
                    RightIcon={() => <Ionicons />}
                />
                <AccountDataButton 
                    LeftIcon={() => <FontAwesome name='phone' size={40} color={theme.colors.darkPrimary} />}
                    text='(829) 341-2424'
                    greyedText={true}
                    RightIcon={() => <Ionicons />}
                />
                <AccountDataButton 
                    LeftIcon={() => <Entypo name='language' size={40} color={theme.colors.darkPrimary} />}
                    text={t('switchLanguage')}
                    RightIcon={() => <Octicons name='arrow-switch' size={40} />}
                    onPress={onLanguageSwitchPress}
                />
                <AccountDataButton 
                    LeftIcon={() => <AntDesign name='creditcard' size={40} color={theme.colors.darkPrimary} />}
                    text={t('paymentHistory')}
                    RightIcon={() => <Ionicons />}
                    onPress={onPaymentHistoryPress}
                /> 
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.white,
    },
    blueCircle: {
        height: 150,
        width: '100%',
        backgroundColor: theme.colors.darkPrimary,
        marginBottom: 100,
    }, 
    accountIcon: {
        position: 'absolute',
        left: 100,
        top: 50
    },
    name: {
        fontSize: 28,
        textAlign: 'center'
    },
    accountDataContainer: {
        
    },
    carsHeader: {
        textAlign: 'left'
    },
})

export default AccountDataScreen2