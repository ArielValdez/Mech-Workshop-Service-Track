import { API_URL } from "@env"
import { format } from "../utils/DateFormatting";

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
    const response =  await fetch(`${API_URL}/services?user_id=${userId}`, {
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

export const getEmptyAppointment = () => {
    return {
        id: '',
        serviceType: '',
        description: '',
        state: '',
        state_description: '',
        vehicle_id: '',
        startedAt: '',
        expectedAt: '',
        finishedAt: '',
        payment_id: '',
        workshop_id: '',
        user_id: ''
    }
}

export const createAppointment = async (serviceType, title, vehicleId, selectedTime, userId) => {
    const response = await fetch(`${API_URL}/services`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            serviceType: serviceType,
            description: title,
            state: 'Not started',
            state_description: 'The mechanics have not looked at the vehicle',
            vehicle_id: vehicleId,
            startedAt:  format(selectedTime),
            expectedAt: format(selectedTime),
            finishedAt: format(selectedTime),
            payment_id: 1,
            workshop_id: 1,
            user_id: user.id
        })
    })

    if (response.ok) {
        return Promise.resolve()
    }
    else {
        return Promise.reject(response)
    }
}