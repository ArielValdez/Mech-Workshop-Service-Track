import React from "react";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import FeedScreen from "./FeedScreen";
import DashboardScreen from "./NewDashboardScreen/DashboardScreen";
import MyCarScreen from "./MyCarScreen";
import ChatScreen from "./ChatScreen";
import AppointmentsScreen from "./AppointmentsScreen"
import AccountDataScreen from "./AccountDataScreen.js"
import { Ionicons, AntDesign, MaterialCommunityIcons } from '@expo/vector-icons'
import { useTranslation } from "react-i18next";

const Tab = createBottomTabNavigator()

const HomeScreen = () => {
    const { t, i18n } = useTranslation()

    return (
        <Tab.Navigator>
            <Tab.Screen name='Feed' component={DashboardScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-home' size={28}/>,
                    title: t('feed'),
                    headerShown: false
                }}
            />
            <Tab.Screen name='MyCar' component={MyCarScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-car' size={28}/>,
                    title: t('myCar'),
                }}
            />
            <Tab.Screen name='Messages' component={ChatScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <AntDesign name='message1' size={28}/>,
                    title: t('messages')
                }}
            />
            <Tab.Screen name='Appointments' component={AppointmentsScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-calendar' size={28}/>,
                    title: t('appointments')
                }}
            />
            <Tab.Screen name='Account' component={AccountDataScreen}
                options={{
                    tabBarIcon: ({color, size}) => <MaterialCommunityIcons name='account' size={28} />,
                    title: t('account')
                }}
            />
        </Tab.Navigator>
    )
}

export default HomeScreen