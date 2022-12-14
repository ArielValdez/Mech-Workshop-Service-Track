import theme from '../../Theme'
import { AntDesign } from '@expo/vector-icons'
import BaseModal from './BaseModal'

const ErrorModal = ({ visible, errorText, onRequestClose, buttonText}) => {
    return (
        <BaseModal 
            visible={visible}
            text={errorText}
            onRequestClose={onRequestClose}
            buttonText={buttonText}
            firstRowBgColor={theme.colors.warningRed}
            Icon={() => <AntDesign name='closecircleo' size={100} color={theme.colors.white} />}
        />
    )
}

export default ErrorModal