import moment from "moment"

export function dateToSting(date: string) {
    date = moment(date).format("YYYY-M-DD HH:mm")
    return date == "Invalid date" ? "" : date;
}

export function stringToDate(date: string) {
    date = moment(date).format("YYYY-M-DDTHH:mm")
    return date == "Invalid date" ? "" : date;;
}
