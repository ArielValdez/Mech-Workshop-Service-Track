import React, { useState, useRef } from 'react';
import { Text, View, ScrollView, StyleSheet, FlatList } from 'react-native';
import CustomButton from '../components/CustomButton';
import CustomInput from '../components/CustomInput';
import theme from '../Theme';
import { Ionicons } from '@expo/vector-icons'

const Message = ({senderName, content, isSenderMe}) => {
	return (
		<View style={[
			messageStyles.container,
			isSenderMe ? { alignSelf: 'flex-end', marginRight: 10, } : {},
		]}>
			{ !isSenderMe && <Ionicons name='person-circle' size={50}/> }
			<View style={[
				messageStyles.messageTextContainer,
			    isSenderMe ? { backgroundColor: 'gray' } : {},
			]}>
				<Text style={messageStyles.senderName}>
					{senderName}
				</Text>
				<Text>
					{content}
				</Text>
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

const MessageRenderItem = ({item}) => {
	return (
		<Message senderName={item.senderName} content={item.content} isSenderMe={item.isSenderMe}/>
	)
}

const ChatScreen = () => {
	const defaultMessages = [
		{ id: 1, senderName: 'David', content: 'Saludos, ¿En qué lo puedo ayudar?', isSenderMe: false }
	]

	const [ messages, setMessages ] = useState(defaultMessages)
	const [ messageTextBox, setMessageTextBox ] = useState('')
	const idCounter = useRef(2)

	const onSendPress = () => {
		const newArray = [...messages, {id: idCounter.current, senderName: 'Carlos Roque', content: messageTextBox, isSenderMe: true}]
		idCounter.current = idCounter.current + 1
		setMessages(newArray)
		setMessageTextBox('')
	}

	return (
		<View style={styles.container}>
			<FlatList
				style={styles.messagesContainer} 
				data={messages}
				renderItem={MessageRenderItem}
				keyExtractor={item => item.id}
			/>
			<View style={styles.bottomRow}>
				<View style={styles.messageInputBox}>
					<CustomInput placeholder='Mensaje' value={messageTextBox} setValue={setMessageTextBox} padding={5}/>
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
		backgroundColor: theme.colors.bgColor,
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