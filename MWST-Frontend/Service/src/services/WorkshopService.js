import { API_URL } from "@env"

export const getWorkshop = async (workshopId) => {
    const response = await fetch(`${API_URL}/workshops/${workshopId}`, {
        method: 'GET'
    })

    if (response.ok) {
        const result = await response.json()
        return Promise.resolve(result)
    }
    else {
        return Promise.reject(response)
    }
}

export const getAllWorkshops = async () => {
    const response = await fetch(`${API_URL}/workshops`, {
        method: 'GET'
    })

    if (response.ok) {
        const result = await response.json()
        return Promise.resolve(result)
    }
    else {
        return Promise.reject(response)
    }
}

export const getEmptyWorkshop = () => {
    return {
        "id": "",
        "name": "",
        "managerId": "",
        "address": "",
        "openAt": "",
        "closedAt": ""
    }
}