import { useEffect } from "react"


export const getUser = async (email, password) =>  {
    const userFetch = await fetch(`http://10.0.0.7:3000/users?email=${email}&password=${password}`, {
        method: 'GET'
    })
    const result = await userFetch.json()
    if (result.length > 0) {
        return Promise.resolve(result[0])
    }
    else {
        return Promise.resolve(null)
    }
}

export const createUser = (firstname, lastname, email, phone, username, idCard, password) => {

}