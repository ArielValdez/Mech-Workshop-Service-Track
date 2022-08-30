import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaView, StyleSheet, Text, View} from 'react-native';
import SignInScreen from './components/screens/SignInScreen';
import SignUpScreen from './components/screens/SignUpScreen';


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
