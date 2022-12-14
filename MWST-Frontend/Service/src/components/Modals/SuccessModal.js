import theme from "../../Theme"
import { AntDesign } from "@expo/vector-icons"
import BaseModal from "./BaseModal"

const SuccessModal = ({ visible, successText, onRequestClose, buttonText }) => {
    return (
        <BaseModal 
            visible={visible} 
            text={successText} 
            onRequestClose={onRequestClose}
            buttonText={buttonText}
            firstRowBgColor={theme.colors.successGreen}
            Icon={() => <AntDesign name='checkcircleo' size={100} color={theme.colors.white} />}
        />
    )
}

export default SuccessModal