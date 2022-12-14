export const format = (date) => {
    return date.getDate() + '/' + (date.getMonth() + 1) + '/' + date.getFullYear() + ' '
            + date.getHours() + ':' + date.getMinutes()
}