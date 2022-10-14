import React, { useState } from 'react';
import { Text, View, ScrollView, StyleSheet } from 'react-native';
import CustomButton from '../components/CustomButton';
import CustomInput from '../components/CustomInput';
import theme from '../Theme';
import { Ionicons } from '@expo/vector-icons'

const Message = () => {
	return (
		<View style={messageStyles.container}>
			<Ionicons name='person-circle' size={50}/>
			<View style={messageStyles.messageTextContainer}>
				<Text style={messageStyles.senderName}>David</Text>
				<Text>Hola, Mr Carlos</Text>
			</View>
		</View>
	)
}

const messageStyles = StyleSheet.create({
	container: {
		flexDirection: 'row',
		marginTop: 10,
		marginLeft: 10,
	},
	senderName: {
		color: theme.colors.gray
	},
	messageTextContainer: {
		marginLeft: 15,
		padding: 10,
		backgroundColor: theme.colors.white,
		borderRadius: 2,
		width: '80%',
	},
})

const ChatScreen = () => {
	const [ message, setMessage ] = useState('')

	const onSendPress = () => {
		console.log(message)
	}

	return (
		<View style={styles.container}>
			<ScrollView style={styles.messagesContainer}>
				<Message />
				<Message />
			</ScrollView>
			<View style={styles.bottomRow}>
				<View style={styles.messageInputBox}>
					<CustomInput placeholder='Mensaje' value={message} setValue={setMessage} padding={5} bgColor={theme.colors.white}/>
				</View>
				<View style={styles.sendButton}>
					<CustomButton text='Enviar' onPress={onSendPress} padding={15} bgColor='gray'/>
				</View>
			</View>
		</View>
	)
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
	},
	messagesContainer: {
		backgroundColor: '#E5e6e6',
	},
	bottomRow: {
		flexDirection: 'row',
		justifyContent: 'space-around',
		paddingTop: 5,
		paddingBottom: 3,
		backgroundColor: theme.colors.white
	},
	messageInputBox: {
		flex: 3,
		paddingLeft: 10,
	},
	sendButton: {
		flex: 1,
		marginHorizontal: 5,
	}
})

export default ChatScreen