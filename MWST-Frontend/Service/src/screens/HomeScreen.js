import React from "react";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import FeedScreen from "./FeedScreen";
import MyCarScreen from "./MyCarScreen";
import ChatScreen from "./ChatScreen";
import AppointmentsScreen from "./AppointmentsScreen"
import AccountDataScreen from "./AccountDataScreen"
import { Ionicons, AntDesign, MaterialCommunityIcons } from '@expo/vector-icons'
import { useTranslation } from "react-i18next";

const Tab = createBottomTabNavigator()

const HomeScreen = () => {
    const { t, i18n } = useTranslation()

    return (
        <Tab.Navigator>
            <Tab.Screen name={t('feed')} component={FeedScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-home' size={28}/>
                }}
            />
            <Tab.Screen name={t('myCar')} component={MyCarScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-car' size={28}/>
                }}
            />
            <Tab.Screen name={t('messages')} component={ChatScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <AntDesign name='message1' size={28}/>
                }}
            />
            <Tab.Screen name={t('appointments')} component={AppointmentsScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-calendar' size={28}/>
                }}
            />
            <Tab.Screen name={t('account')} component={AccountDataScreen}
                options={{
                    tabBarIcon: ({color, size}) => <MaterialCommunityIcons name='account' size={28} />
                }}
            />
        </Tab.Navigator>
    )
}

export default HomeScreen