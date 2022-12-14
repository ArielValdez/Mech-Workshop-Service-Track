import { Modal, View, StyleSheet, Text} from 'react-native'
import theme from '../../Theme'
import CustomButton from '../CustomButton'

const BaseModal = ({ visible, text, onRequestClose, buttonText, firstRowBgColor, Icon }) => {
    return (
        <Modal 
            animationType='fade'
            visible={visible}
            transparent={true}
            onRequestClose={onRequestClose}
        >
            <View style={styles.background}>
                <View style={styles.container}>
                    <View style={[styles.firstRow, { backgroundColor: firstRowBgColor }]}>
                        <Icon />
                    </View>
                    <View style={styles.secondRow}>
                        <Text style={styles.errorText}>{text}</Text>
                        <View style={styles.buttonContainer}>
                            <CustomButton style={styles.button} onPress={onRequestClose} text={buttonText} width='55%' />
                        </View>
                    </View>
                </View>
            </View>
        </Modal>
    )
}

const styles = StyleSheet.create({
    background: {
        flex: 1,
        backgroundColor: 'rgba(0, 0, 0, 0.6)',
        alignItems: 'center',
        justifyContent: 'center'
    },
    container: {
        marginHorizontal: 30,
        height: '35%',
        width: '85%',
        shadowColor: '#000',
        shadowOffset: {
            width: 0,
            height: 2
        },
        shadowOpacity: 0.25,
        shadowRadius: 4,
        elevation: 5,
    }, 
    firstRow: {
        flex: 5,
        alignItems: 'center',
        justifyContent: 'center',
        borderTopLeftRadius: 10, borderTopRightRadius: 10,
    },
    secondRow: {
        backgroundColor: theme.colors.white,
        flex: 6,
        alignItems: 'center',
        paddingHorizontal: 20,
        borderBottomLeftRadius: 10, borderBottomRightRadius: 10,
    },
    errorText: {
        fontFamily: 'UbuntuMedium',
        flex: 1,
        justifyContent: 'center',
        textAlignVertical: 'center',
    },
    buttonContainer: {
        flex: 1,
    },
    button: {
    }
})

export default BaseModal