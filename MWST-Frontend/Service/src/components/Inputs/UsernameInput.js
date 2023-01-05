import { useTranslation } from "react-i18next";
import CustomInput from "./CustomInput.js"

const usernameRegex = /[a-zA-Z0-9]{4,16}/

const UsernameInput = ({value, setValue}) => {
    const { t, i18n } = useTranslation()

    return (
		<CustomInput
			placeholder={t("usernameInputPlaceholder")}
			value={value}
			setValue={setValue}
			pattern={usernameRegex}
			errorMessage={t("invalidUsernameMessage")}
			autoComplete="username"
		/>
	);
}

export default UsernameInput