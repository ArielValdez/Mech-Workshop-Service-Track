import { API_URL } from "@env"


export const getUser = async (email, password) =>  {
    const response = await fetch(`${API_URL}/users?email=${email}&password=${password}`, {
        method: 'GET'
    })
    
    if (response.ok) {
        const result = await response.json()
        if (result.length > 0) {
            return Promise.resolve(result[0])
        }
        else {
            return Promise.resolve(undefined)
        }
    }
    else {
        return Promise.reject(response)
    }
    // if (response.ok)
    //     result = await response.json()
    // else
    //     return Promise.reject(response)
        
    // if (result.length > 0) {
    //     return Promise.resolve(result[0])
    // }
    // else {
    //     return Promise.reject('No user was found with the given credentials')
    // }
}

export const createUser = async (firstname, lastname, email, phone, username, idCard, password) => {
    const response = await fetch(`${API_URL}/users`, {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            username: username,
		    password: password,
		    email: email,
		    name: firstname,
		    lastname: lastname,
		    //Should be limited to thirteen digits in the following manner: 0-1234567-891
		    idCard: idCard,
		    role: 'Client',
		    //Should be limited to thirteen digits in the following order: (809)000-0000
		    phoneNumber: phone,
            active: true //change this later to false
        })
    }) 

    if (response.ok) {
        return Promise.resolve()
    }
    else {
        return Promise.reject('We failed to create the user for some reason')
    }
}