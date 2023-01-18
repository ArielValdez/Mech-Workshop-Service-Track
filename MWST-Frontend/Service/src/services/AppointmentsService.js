import { API_URL } from "@env"
import { formatDate } from "../utils/DateFormatting";
import { format } from "date-fns";

export const getAppointment = async (appointmentId) => {
    const response = await fetch(`{API_URL}/services/${appointmentId}`, {
        method: 'GET'
    })

    if (response.ok) {
        const result = await response.json()
        return Promise.resolve(result[0])
    }
    else {
        return Promise.reject(response)
    }
}

export const getAllAppointments = async (userId) => {
    const response =  await fetch(`${API_URL}/services?userId=${userId}`, {
        method: 'GET',
    })

    if (response.ok) {
        const result = await response.json()
        return Promise.resolve(result)
    }
    else {
        return Promise.reject(response)
    }
}

export const getLatestFinishedAppointments = async (userId) => { 
    const response =  await fetch(`${API_URL}/services?userId=${userId}&state=Finished&_expand=payment`, {
        method: 'GET',
    })

    if (response.ok) {
        const result = await response.json()
        return Promise.resolve(result.slice(0, 3))
    }
    else {
        return Promise.reject(response)
    }
}

export const getPendingAppointment = async (userId) => {
    const response = await fetch(`${API_URL}/services?userId=${userId}&state=In Process&_expand=workshop`, {
        method: 'GET'
    })

    if (response.ok) {
        const result = await response.json()
        return Promise.resolve(result[0])
    }
    else {
        return Promise.reject(response)
    }
}

export const getEmptyAppointment = () => {
    return {
        id: '',
        serviceType: '',
        description: '',
        state: '',
        stateDescription: '',
        vehicleId: '',
        startedAt: '',
        expectedAt: '',
        finishedAt: '',
        paymentId: '',
        workshopId: '',
        userId: ''
    }
}

export const createAppointment = async (serviceType, title, vehicleId, formattedDate, userId, workshopId) => {
    const response = await fetch(`${API_URL}/services`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            serviceType: serviceType,
            description: title,
            state: 'Not started',
            stateDescription: 'The mechanics have not looked at the vehicle',
            vehicleId: vehicleId,
            startedAt:  formattedDate,
            expectedAt: formattedDate,
            finishedAt: formattedDate,
            paymentId: 1,
            workshopId: workshopId,
            userId: userId
        })
    })

    if (response.ok) {
        return Promise.resolve()
    }
    else {
        return Promise.reject(response)
    }
}