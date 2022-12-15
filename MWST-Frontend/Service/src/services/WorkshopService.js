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