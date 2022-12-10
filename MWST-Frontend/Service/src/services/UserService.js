

export const GetUser = (email, password) =>  {
    fetch('http://10.0.0.7:3000', {
        method: 'GET'
    })
}

export const CreateUser = (firstname, lastname, email, phone, username, idCard, password) => {

}