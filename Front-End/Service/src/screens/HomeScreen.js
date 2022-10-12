import React from "react";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import FeedScreen from "./FeedScreen";
import MyCarScreen from "./MyCarScreen";
import MessageScreen from "./MessageScreen";
import AppointmentsScreen from "./AppointmentsScreen"

const Tab = createBottomTabNavigator()

const HomeScreen = () => {
    return (
        <Tab.Navigator>
            <Tab.Screen name='Feed' component={FeedScreen}/>
            <Tab.Screen name='MyCar' component={MyCarScreen}/>
            <Tab.Screen name='Message' component={MessageScreen}/>
            <Tab.Screen name='Citas' component={AppointmentsScreen}/>
        </Tab.Navigator>
    )
}

export default HomeScreen