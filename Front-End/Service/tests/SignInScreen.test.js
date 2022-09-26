import SignInScreen from "../components/screens/SignInScreen"
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

const tree = renderer.create(<SignInScreen />)

describe('<SignInScreen />', () => {
    it('has 1 child', () => {
        expect(tree.root.children.length).toBe(1)
    })
    it('tests that navigation works', () => {
        const signInButton = tree.root.findByProps({testID: 'SignInButton'}).props
        const signUpButton = tree.root.findByProps({testID: 'SignUpButton'}).props
        act(() => signInButton.onPress())
        act(() => signUpButton.onPress())
        expect(mockedNavigate).toHaveBeenCalledTimes(2)
    })
})