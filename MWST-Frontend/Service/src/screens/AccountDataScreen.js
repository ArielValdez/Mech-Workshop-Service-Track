import { React, useState } from 'react'
import { ScrollView, View, StyleSheet, FlatList, Text, Pressable } from "react-native"
import { StackActions, useNavigation } from "@react-navigation/native";
import { useTranslation } from 'react-i18next';
import { Ionicons, MaterialIcons, MaterialCommunityIcons, FontAwesome, Octicons, Entypo, AntDesign, FontAwesome5 } from '@expo/vector-icons'
import LineBreak from '../components/LineBreak'
import CustomButton from '../components/CustomButton'
import CustomText from '../components/CustomText';
import theme from '../Theme';
import DropDownPicker from 'react-native-dropdown-picker';
import { LocaleConfig } from 'react-native-calendars';
import { LinearGradient } from 'expo-linear-gradient'
import { useUser } from '../context/UserContext';

const AccountDataButton = ({text, greyedText, onPress, LeftIcon, RightIcon}) => {
    return (
        <View>
            <Pressable style={accountDataStyles.container} onPress={onPress}>
                <View style={accountDataStyles.leftIcon}>
                    <LeftIcon />
                </View>
                <CustomText style={greyedText ? accountDataStyles.greyedText : accountDataStyles.text}>
                    {text}
                </CustomText>
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

const AccountDataScreen = () => {
    const { t, i18n } = useTranslation()
    const navigation = useNavigation()
    const [ user, setUser ] = useUser()

    const onLanguageSwitchPress = () => {
        if (i18n.language == 'es') {
            i18n.changeLanguage('en')
            LocaleConfig.defaultLocale = 'en'
        }
        else {
            i18n.changeLanguage('es')
            LocaleConfig.defaultLocale = 'es'
        } 
        navigation.navigate('Account')
    }

    const onPaymentHistoryPress = () => { 
        console.log('payment history pressed')
    }

    const onCarListPress = () => {
        navigation.navigate('VehicleList')
    }

    const onReturnToSignInPress = () => {
        navigation.navigate('SignIn')
    }

    return (
        <View style={styles.container}>
            <LinearGradient
                style={styles.gradientRectangle}
                colors={[theme.colors.darkPrimary, theme.colors.lightPrimary]}
                end={{x: 0.8, y: 0.5}} 
            >
            </LinearGradient>
            <View style={styles.whiteCircle}>
                <MaterialCommunityIcons style={styles.accountIcon} name='account' size={100}/>
            </View>
            <View style={styles.accountDataContainer}>
                <AccountDataButton 
                    LeftIcon={() => <MaterialCommunityIcons name='face-man' size={40} color={theme.colors.darkPrimary} />} 
                    text={user.name + ' ' + user.lastname}  
                    greyedText={true}
                    RightIcon={() => <Ionicons />}
                />
                <AccountDataButton 
                    LeftIcon={() => <FontAwesome name='phone' size={40} color={theme.colors.darkPrimary} />}
                    text={user.phone_number}
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
                <AccountDataButton 
                    LeftIcon={() => <FontAwesome5 name='car' size={40} color={theme.colors.darkPrimary} />}
                    text={t('vehicleList')}
                    RightIcon={() => <Ionicons />}
                    onPress={onCarListPress}
                />

                <Pressable onPress={onReturnToSignInPress}>
                    <LinearGradient 
                        style={styles.returnButton} 
                        colors={[theme.colors.darkPrimary, theme.colors.lightPrimary]}
                        end={{x: 0.9, y: 0.5}}
                    >
                        <CustomText style={styles.returnButtonText}>{t('returnToSignIn')}</CustomText>
                    </LinearGradient>
                </Pressable> 
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.white,
    },
    gradientRectangle: {
        height: 150,
        width: '100%',
        backgroundColor: theme.colors.darkPrimary,
        marginBottom: 100,
    },
    whiteCircle: {
        backgroundColor: theme.colors.white,
        position: 'absolute',
        left: 125,
        top: 80,
        width: 125, height: 125,
        borderRadius: 125 / 2,
        borderWidth: 1.5,
        borderColor: theme.colors.black,
        alignItems: 'center',
        justifyContent: 'center',
    }, 
    accountIcon: {
        
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
    returnButton: {
        width: '60%', height: 40,
        marginTop: 30,
        borderRadius: 15,
        alignSelf: 'center',
        alignItems: 'center',
        justifyContent: 'center',
    },
    returnButtonText: {
        color: theme.colors.white,
        fontFamily: 'UbuntuBold',
        fontWeight: 'normal',
        fontSize: 16,
    }
})

export default AccountDataScreen