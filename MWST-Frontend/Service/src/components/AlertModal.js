import React from 'react'
import { View, Modal, Text, StyleSheet, Pressable, Image } from 'react-native'
import ImageButton from './ImageButton'
import LineBreak from './LineBreak'
import Close from '../../assets/Close-256.png'
import CustomButton from './CustomButton'
import theme from '../Theme'

const AlertModal = ({visible, title, text, onClosePress}) => {
    return (
        <Modal 
            animationType='fade'
            visible={visible}
            transparent={true}
        >
            <View style={styles.container}>
                <View style={styles.modalView}>
                    <View style={styles.header}>
                        <Text style={styles.headerText}>{title}</Text>
                        <ImageButton 
                            source={Close} width={25} height={25}
                            style={styles.closeButton}
                            onPress={onClosePress}
                        />
                    </View>
                    <LineBreak marginHorizontal={20} />
                    <View style={styles.body}>
                        <Text>{text}</Text>
                    </View>
                    <View style={styles.footer}>
                        <CustomButton text='Ok' onPress={() => onClosePress()} width='35%' type='Primary' bgColor={theme.colors.primary}/>
                    </View>
                </View>
            </View>
        </Modal>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
        backgroundColor: 'rgba(0, 0, 0, 0.5)'
    },
    modalView: {
        backgroundColor: 'white',
        height: '25%',
        paddingHorizontal: 3,
        paddingTop: 5,
        marginHorizontal: 30,
        shadowColor: '#000',
        shadowOffset: {
            width: 0,
            height: 2
        },
        shadowOpacity: 0.25,
        shadowRadius: 4,
        elevation: 5,
    },
    header: {
        flexDirection: 'row',
        alignItems: 'center',
        padding: 5,
    },
    headerText: {
        fontWeight: 'bold',
        fontSize: 20, 
        flex: 5,
        textAlign: 'center',
        marginTop: 3,   
    },
    closeButton: {
        flex: 1,
    },
    body: {
        backgroundColor: 'white',
        justifyContent: 'center',
        padding: 10,
    },
    footer: {
        flex: 1,
        alignItems: 'center',
        paddingTop: 25,
    },
})

export default AlertModal