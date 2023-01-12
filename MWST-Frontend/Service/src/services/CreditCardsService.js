import { API_URL } from "@env"

export const getAllCards = async (userId) => {
    const response = await fetch(`${API_URL}/credit_cards?userId=${userId}`, {
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
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            'userId': userId,
            'numbers': numbers,
            'expirationDate': expirationDate,
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
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            'id': id,
            'userId': userId,
            'numbers': numbers,
            'expirationDate': expirationDate,
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