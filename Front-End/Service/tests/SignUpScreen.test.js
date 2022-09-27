import SignUpScreen from "../src/screens/SignUpScreen"
import renderer, { act } from 'react-test-renderer'

const mockedNavigate = jest.fn()

jest.mock('@react-navigation/native', () => {
    const actualNav = jest.requireActual('@react-navigation/native')
    return {
        ...actualNav,
        useNavigation: () => ({
            navigate: mockedNavigate
        })
    }
})

const tree = renderer.create(<SignUpScreen />)

describe('Sign up screen', () => {
    it('has 1 child', () => {
        expect(tree.root.children.length).toBe(1)
    })
    it('Tests that navigation works', () => {
        const returnButton = tree.root.findByProps({testID: 'ReturnButton'}).props
        act(() => returnButton.onPress())
        expect(mockedNavigate).toHaveBeenCalledTimes(1)
    })
})