import i18next from "i18next"
import { initReactI18next } from "react-i18next"
import en from './en.json'
import es from './es.json'

i18next.use(initReactI18next).init({
    lng: 'es',
    fallbackLng: 'es',
    compatibilityJSON: 'v3',
    resources: {
        es: es,
        en: en
    },
    interpolation: {
        escapeValue: false
    }
})

export default i18next