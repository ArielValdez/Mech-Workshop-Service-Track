import SignInScreen from "../src/screens/SignInScreen"
import renderer, { act } from 'react-test-renderer'
import CustomInput from "../src/components/CustomInput"
import CheckBox from 'expo-checkbox';
import { ScrollView } from "react-native";

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
const root = tree.root

describe('Rendering tests', () => {
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
    it('renders logo', () => {
        console.log(root.findAllByType('CustomInput'))
        expect(root.findAllByType('Image').length).toEqual(1)
    })
})