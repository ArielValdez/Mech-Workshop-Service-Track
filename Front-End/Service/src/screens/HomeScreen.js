import React from "react";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import FeedScreen from "./FeedScreen";
import MyCarScreen from "./MyCarScreen";

const Tab = createBottomTabNavigator()

const HomeScreen = () => {
    return (
        <Tab.Navigator>
            <Tab.Screen name='Feed' component={FeedScreen}/>
            <Tab.Screen name='MyCar' component={MyCarScreen}/>
        </Tab.Navigator>
    )
}

export default HomeScreen