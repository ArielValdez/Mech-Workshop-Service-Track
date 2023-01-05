import { useTranslation } from "react-i18next";
import CustomInput from "./CustomInput"

const passwordRegex = /[a-zA-Z0-9@]{8,}/

const PasswordInput = ({value, setValue, placeholder}) => {
    const { t, i18n } = useTranslation()

    return (
		<CustomInput
			placeholder={placeholder}
			value={value}
			setValue={setValue}
			secureTextEntry
			pattern={passwordRegex}
			errorMessage={t("invalidPasswordMessage")}
			autoCapitalize="none"
			textContentType="password"
			autoComplete="password"
		/>
	);
}

export default PasswordInput