import { API_URL } from "@env"

export const getAllCards = async (userId) => {
    const response = await fetch(`${API_URL}/credit_cards?user_id=${userId}`, {
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

export const createCard = async (userId, numbers, expirationDate, cvv, name) => {
    const response = await fetch(`${API_URL}/credit_cards`, {
        method: 'POST',
        body: JSON.stringify({
            'user_id': userId,
            'numbers': numbers,
            'expiration_date': expirationDate,
            'cvv': cvv,
            'name': name
        })
    })

    if (response.ok) {
        return Promise.resolve()
    }
    else {
        return Promise.reject(response)
    }
}

export const editCard = async (id, userId, numbers, expirationDate, cvv, name) => {
    const response = await fetch(`${API_URL}/credit_cards/${id}`, {
        method: 'PUT',
        body: JSON.stringify({
            'id': id,
            'user_id': userId,
            'numbers': numbers,
            'expiration_date': expirationDate,
            'cvv': cvv,
            'name': name
        })
    })

    if (response.ok) {
        return Promise.resolve()
    }
    else {
        return Promise.reject(response)
    }
}

export const deleteCard = async (id) => {
    const response = await fetch(`${API_URL}/credit_cards/${id}`, {
        method: 'DELETE'
    })

    if (response.ok) {
        return Promise.resolve()
    }
    else {
        return Promise.reject(response)
    }
}