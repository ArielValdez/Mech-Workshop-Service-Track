import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import completionBar from './components/completionBar';
import history from './components/history';
import login from './components/login';
import registerUser from './components/registerUser';


export default function App() {
  return (
    <View style={styles.container}>
      <Text>Open up App.js to start working on your app!</Text>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
