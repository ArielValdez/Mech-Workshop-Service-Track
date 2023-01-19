import React, { useState, useRef, Component } from 'react';
import { Text, View, ScrollView, StyleSheet, FlatList } from 'react-native';
import CustomButton from '../components/CustomButton';
import CustomInput from '../components/Inputs/CustomInput';
import CustomText from '../components/CustomText';
import theme from '../Theme';
import { Ionicons } from '@expo/vector-icons'
import { useTranslation } from 'react-i18next';
import { NavigationContainer } from '@react-navigation/native';
import { WebView } from 'react-native-webview'




class ChatScreen extends Component {
	render() {
	  return <WebView source={{ uri: 'https://tawk.to/chat/63c896dd47425128790e7442/1gn3oqkue' }} />;
	}
  }


export default ChatScreen