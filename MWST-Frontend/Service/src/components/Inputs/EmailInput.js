import { useTranslation } from "react-i18next"
import CustomInput from "./CustomInput.js"

const emailRegex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/

const EmailInput = ({value, setValue}) => {
    const { t, i18n } = useTranslation()

    return (
		<CustomInput
			placeholder={t("emailInputPlaceholder")}
			value={value}
			setValue={setValue}
			keyboardType="email-address"
			errorMessage={t("invalidEmailMessage")}
			pattern={emailRegex}
			textContentType="emailAddress"
			autoComplete="email"
			autoCapitalize="none"
		/>
	)
}

export default EmailInput