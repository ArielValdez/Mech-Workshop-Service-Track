import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View} from 'react-native';
import History from './components/history';
import RegisterUser from './components/registerUser';
import SignInScreen from './screens/SignInScreen';


export default function App() {
  return (
    <View style={styles.container}>
      <SignInScreen />
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#F9FBFC',
  },
});
