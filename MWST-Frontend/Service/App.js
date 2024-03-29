import React from 'react';
import { SafeAreaView, StyleSheet, Text, View, StatusBar } from 'react-native';
import SignInScreen from './src/screens/SignInScreen';
import SignUpScreen from './src/screens/SignUpScreen';
import ConfirmEmailScreen from './src/screens/ConfirmEmailScreen';
import ForgotPasswordScreen from './src/screens/ForgotPasswordScreen';
import NewPasswordScreen from './src/screens/NewPasswordScreen';
import VehicleListScreen from './src/screens/VehicleListScreen/VehicleListScreen.js';
import AddVehicleScreen from './src/screens/AddVehicleScreen/AddVehicleScreen.js';
import AppointmentDetailScreen from './src/screens/AppointmentDetailScreen/AppointmentDetailScreen.js'
import ItemListScreen from './src/screens/ItemListScreen/ItemListScreen';
import CreditCarEditScreen from './src/screens/CreditCarEditScreen/CreditCarEditScreen.js'
import WorkshopsMarkerScreen from './src/screens/WorkshopsMarkerScreen/WorkshopsMarkerScreen';
import AppointmentSchedulingScreen from './src/screens/AppointmentSchedulingScreen.js/AppointmentSchedulingScreen';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { LocaleConfig } from 'react-native-calendars'
import HomeScreen from './src/screens/HomeScreen';
import './assets/translations/i18n'
import CalendarConfigSetup from './src/CalendarSetup';
import { UserProvider } from './src/context/UserContext';
import { useFonts } from 'expo-font';
import "intl"
import "intl/locale-data/jsonp/en";

CalendarConfigSetup()

const Stack = createNativeStackNavigator()

export default function App() {
	const [ fontsLoaded ] = useFonts({
		UbuntuRegular: require("./assets/fonts/Ubuntu/Ubuntu-Regular.ttf"),
		UbuntuMedium: require("./assets/fonts/Ubuntu/Ubuntu-Medium.ttf"),
		UbuntuBold: require("./assets/fonts/Ubuntu/Ubuntu-Bold.ttf"),
	})

	if (!fontsLoaded) 
		return <></>
	else {
		return (
			<SafeAreaView style={styles.container}>
				<StatusBar barStyle="light-content" backgroundColor="rgba(0, 0, 0, 0.9)"/>
				<UserProvider>
					<NavigationContainer>
						<Stack.Navigator>
							<Stack.Screen
								name="SignIn"
								component={SignInScreen}
								options={{ headerShown: false }}
							/>
							<Stack.Screen
								name="SignUp"
								component={SignUpScreen}
								options={{ headerShown: false }}
							/>
							<Stack.Screen
								name="ForgotPassword"
								component={ForgotPasswordScreen}
								options={{ headerShown: false }}
							/>
							<Stack.Screen
								name="NewPassword"
								component={NewPasswordScreen}
								options={{ headerShown: false }}
							/>
							<Stack.Screen
								name="Home"
								component={HomeScreen}
								options={{ headerShown: false }}
							/>
							<Stack.Screen
								name="VehicleList"
								component={VehicleListScreen}
								options={{
									headerShown: true,
									title: "Vehicle list",
								}}
							/>
							<Stack.Screen
								name="AddVehicle"
								component={AddVehicleScreen}
								options={{
									headerShown: true,
									title: "Add vehicle",
								}}
							/>
							<Stack.Screen
								name="AppointmentDetail"
								component={AppointmentDetailScreen}
								options={{
									headerShown: true,
									title: "Details"
								}}
							/>
							<Stack.Screen 
								name="ItemList"
								component={ItemListScreen}
								options={{
									headerShown: true,
									title: "Item List"
								}}
							/>
							<Stack.Screen 
								name="EditCreditCard"
								component={CreditCarEditScreen}
								options={{
									headerShown: true,
									title: "Edit card"
								}}
							/>
							<Stack.Screen 
								name="WorkshopsMarker"
								component={WorkshopsMarkerScreen}
								options={{
									headerShown: true,
									title: "Workshops"
								}}
							/>
							<Stack.Screen 
								name="AppointmentScheduling"
								component={AppointmentSchedulingScreen}
								options={{
									headerShown: true,
									title: "Appointment scheduling"
								}}
							/>
						</Stack.Navigator>
					</NavigationContainer>
				</UserProvider>
				<StatusBar style="auto" />
			</SafeAreaView>
		)
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		backgroundColor: "#F9FBFC",
	},
});
