export const UsernameRegex = '[a-zA-Z0-9]{4,16}'
export const InvalidUsernameMessage = 'Nombre de usuario debe estar entre 4 y 16 carácteres'

export const EmailRegex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/
export const InvalidEmailMessage = 'El correo no es válido'

export const PasswordRegex = '[a-zA-Z0-9@]{8,}'
export const InvalidPasswordMessage = 'La contraseña debe tener al menos 8 carácteres' 