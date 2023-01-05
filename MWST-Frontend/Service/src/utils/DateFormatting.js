import { parse, format } from "date-fns"

export const formatDate = (date) => {
    return date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear() + ' '
            + date.getHours() + ':' + date.getMinutes()
}

export const formatAsLongDate = (dateString) => {
    return format(new Date(dateString), 'PPPP')
}

export const diffHours = (dt2, dt1) => {
    //console.log(dt2.toString())
    // divide by 1,000 to convert from miliseconds to seconds
    var diff = (dt2.getTime() - dt1.getTime()) / 1000 
    // multiply by 3,600 to convert from seconds to hours
    diff /= (60 * 60)
    return Math.abs(Math.round(diff))
}