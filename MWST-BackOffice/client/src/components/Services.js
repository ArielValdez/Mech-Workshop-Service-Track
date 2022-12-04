import { Create, Datagrid, DateField, DateTimeInput, DeleteButton, Edit, EditButton, List, SimpleForm, TextField, TextInput } from "react-admin"

export const ServiceList = (props) => {
    return (
        <List title='Services' {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='serviceType' />
                <TextField source='description' />
                <TextField source='state' />
                <TextField source='plate' label='Car'/>
                <DateField source='startedAt' />
                <DateField source='expectedAt' />
                <DateField source='finishedAt' />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    )
}

export const ServiceCreate = (props) => {
    return (
        <Create title='Create new service' {...props}>
            <SimpleForm>
                <TextInput source='description' multiline/>
                <TextInput source='plate' placeholder='0F00105'/>
                <DateTimeInput source='startedAt' />
                <DateTimeInput source='expectedAt' />
                <DateTimeInput source='finishedAt'/>
            </SimpleForm>
        </Create>
    )
}

export const ServiceEdit = (props) => {
    return (
        <Edit title='Edit service' {...props}>
            <SimpleForm>
                
            </SimpleForm>
        </Edit>
    )
}