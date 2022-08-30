import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaView, StyleSheet, Text, View} from 'react-native';
import History from './components/history';
import RegisterUser from './components/registerUser';
import SignInScreen from './screens/SignInScreen';
import SignUpScreen from './screens/SignUpScreen';


export default function App() {
  return (
    <SafeAreaView style={styles.container}>
      <SignUpScreen />
      <StatusBar style="auto" />
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#F9FBFC',
  },
});
