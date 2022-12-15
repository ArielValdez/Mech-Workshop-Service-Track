import { LocaleConfig } from "react-native-calendars";

const CalendarConfigSetup = () => {
    LocaleConfig.locales['en'] = { 
        monthNames: [
          'January',
          'February',
          'March',
          'April',
          'May',
          'June',
          'July',
          'August',
          'September',
          'October',
          'November',
          'December'
        ],
        monthNamesShort: [
          'Jan.',
          'Feb.',
          'Mar.',
          'Apr.',
          'May.',
          'Jun.',
          'Jul.',
          'Aug.',
          'Sep.',
          'Oct.',
          'Nov.',
          'Dec.'
        ],
        dayNames: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
        dayNamesShort: ['Sun.', 'Mon.', 'Tue.', 'Wed.', 'Thu.', 'Fri.', 'Sat.'],
        today: 'Today'
      }
      
    LocaleConfig.locales['es'] = {
        monthNames: [
            'Enero',
            'Febrero',
            'Marzo',
            'Abril',
            'Mayo',
            'Junio',
            'Julio',
            'Agosto',
            'Septiembre',
            'Octubre',
            'Noviembre',
            'Diciembre'
        ],
        monthNamesShort: ['Ene.', 'Feb.', 'Mar.', 'Abr.', 'May.', 'Jun.', 'Jul.', 'Ago.', 'Sep.', 'Oct.', 'Nov.', 'Dic.'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sabado'],
        dayNamesShort: ['Dom.', 'Lun.', 'Mar.', 'Mié.', 'Jue.', 'Vie.', 'Sab.'],
        today: 'Hoy'
    }
      
    LocaleConfig.defaultLocale = 'es'
}

export default CalendarConfigSetup