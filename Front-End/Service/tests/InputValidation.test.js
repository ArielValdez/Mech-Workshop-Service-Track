import { UsernameRegex, EmailRegex, PasswordRegex } from "../src/Constants"; 

describe('Test username validation', () => {
    it('Tests valid username', () => {
        var regex = new RegExp(UsernameRegex)
        expect(regex.test('MyUsername')).toBe(true)
    })
})

describe('Test email validation', () => {
    it('Tests valid email', () => {
        var regex = new RegExp(EmailRegex)
        expect(regex.test('carlosroque198@gmail.com')).toBe(true)
    })
    it('Tests invalid email', () => {
        var regex = new RegExp(EmailRegex)
        expect(regex.test('abc.def@mail#archive.com')).toBe(false)
    })
})

describe('Test password validation', () => {
    it('Tests invalid password', () => {
        var regex = new RegExp(PasswordRegex)
        expect(regex.test('123')).toBe(false)
    })
})