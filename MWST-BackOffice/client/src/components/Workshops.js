import { Datagrid, DateField, List, TextField, field, Create, SimpleForm, TextInput, TimeInput, EditButton, DeleteButton, Edit } from "react-admin"

export const WorkshopList = (props) => {
    return (
        <List {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='name' />
                <TextField source='managerId' />
                <TextField source='locationId' />
                <DateField source='openAt' showTime showDate={false} />
                <DateField source='closedAt' showTime showDate={false} />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    )
}

export const WorkshopCreate = (props) => {
    return (
        <Create title='Create new workshop' {...props}>
            <SimpleForm>
                <TextInput source='name' />
                <TextInput source='managerId' />
                <TextInput source='locationId' />
                <TimeInput source='openAt' />
                <TimeInput source='closedAt' />
            </SimpleForm>
        </Create>
    )
}

export const WorkshopEdit = (props) => {
    return (
        <Edit title='Edit workshop' {...props}>
            <SimpleForm>
                <TextInput source='name' />
                <TextInput source='managerId' />
                <TextInput source='locationId' />
                <TimeInput source='openAt' />
                <TimeInput source='closedAt' />
            </SimpleForm>
        </Edit>
    )
}