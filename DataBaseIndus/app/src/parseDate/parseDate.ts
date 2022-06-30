import moment from "moment"

export function dateToSting(date: string|null) {
    date = moment(date).format("YYYY-M-DD HH:mm")
    return date == "Invalid date" ? null : date;
}

export function stringToDate(date: string|null) {
    date = moment(date).format("YYYY-M-DDTHH:mm:ss")
    return date == "Invalid date" ? null : date;
}
