import { List, Datagrid, TextField, DateField, EditButton,
    DeleteButton, Create, SimpleForm, Edit, TextInput, PasswordInput,
    BooleanInput, SelectInput, ReferenceField, EmailField, SearchInput, ReferenceInput } from 'react-admin'


export const UserList = (props) => {
    return (
        <List title='User list' {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='name' />
                <TextField source='lastname' />
                <TextField source='password' />
                <TextField source='idCard'/>
                <TextField source='role' />
                <TextField source='active' />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    )
}

export const UserCreate = (props) => {
    return (
        <Create title='Create new user' {...props}>
            <SimpleForm>
                <TextInput source='name' />
                <TextInput source='lastname' />
                <PasswordInput source='password'/>
                <SelectInput source='role' choices={[
                    { id: 'client', name: 'Client' },
                    { id: 'assistant', name: 'Assistant' },
                    { id: 'mechanic', name: 'Mechanic' }
                ]} />
                <BooleanInput source='active'/>
            </SimpleForm>
        </Create>
    )
}

export const UserEdit = (props) => {
    return (
        <Edit title='Edit user' {...props}>
            <SimpleForm>
                <TextInput source='id' disabled />
                <TextInput source='name' />
                <TextInput source='lastname' />
                <PasswordInput source='password' />
                <SelectInput source='role' choices={[
                    { id: 'client', name: 'Client' },
                    { id: 'assistant', name: 'Assistant' },
                    { id: 'mechanic', name: 'Mechanic' }
                ]} />
                <BooleanInput source='active' />
            </SimpleForm>
        </Edit>
    )
}