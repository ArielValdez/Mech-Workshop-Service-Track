import React from "react";
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import FeedScreen from "./FeedScreen";
import MyCarScreen from "./MyCarScreen";
import ChatScreen from "./ChatScreen";
import AppointmentsScreen from "./AppointmentsScreen"
import { Ionicons, AntDesign } from '@expo/vector-icons'

const Tab = createBottomTabNavigator()

const HomeScreen = () => {
    return (
        <Tab.Navigator>
            <Tab.Screen name='Feed' component={FeedScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-home' size={28}/>
                }}
            />
            <Tab.Screen name='MyCar' component={MyCarScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-car' size={28}/>
                }}
            />
            <Tab.Screen name='Messages' component={ChatScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <AntDesign name='message1' size={28}/>
                }}
            />
            <Tab.Screen name='Citas' component={AppointmentsScreen} 
                options={{
                    tabBarIcon: ({color, size}) => <Ionicons name='md-calendar' size={28}/>
                }}
            />
        </Tab.Navigator>
    )
}

export default HomeScreen