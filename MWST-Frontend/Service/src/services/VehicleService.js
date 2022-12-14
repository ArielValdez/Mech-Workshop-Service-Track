import { API_URL } from "@env"

export const getAllVehicles = async (userId) => {
    const response = await fetch(`${API_URL}/vehicles?user_id=${userId}`, {
        method: 'GET'
    })

    let result
    if (response.ok)
        result = response.json()
    else
        return Promise.reject(response)
    
    return Promise.resolve(result)
}

export const createVehicle = async (userId, plate, model, vin) => {
    const response = await fetch(`${API_URL}/vehicles`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            user_id: userId,
            plate: plate,
            model: model,
            vin: vin
        })
    })
    
    if (response.ok)
        return Promise.resolve()
    else
        return Promise.reject(response)
}

export const editVehicle = async (id, plate, model, vin) => {
    const response = await fetch(`${API_URL}/vehicles/${id}`, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            user_id: userId,
            plate: plate,
            model: model,
            vin: vin
        })
    })

    if (response.ok)
        return Promise.resolve()
    else
        return Promise.reject(response)
}

export const deleteVehicle = async (id) => {
    const response = await fetch(`${API_URL}/vehicles/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-type': 'application/json'
        }
    })

    if (response.ok)
        return Promise.resolve('The vehicle was deleted successfully')
    else
        return Promise.reject(response)
}