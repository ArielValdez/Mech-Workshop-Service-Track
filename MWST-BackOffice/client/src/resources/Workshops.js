import { Datagrid, DateField, List, TextField, field,
    Create, SimpleForm, TextInput, TimeInput, EditButton,
    DeleteButton, Edit, NumberInput } from "react-admin"

export const WorkshopList = (props) => {
    return (
        <List {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='name' />
                <TextField source='managerId' />
                <DateField source='openAt' showTime showDate={false} />
                <DateField source='closedAt' showTime showDate={false} />
                <TextField source="latitude" />
                <TextField source="longitude" />
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
                <TimeInput source='openAt' />
                <TimeInput source='closedAt' />
                <NumberInput source="latitude" />
                <NumberInput source="longitude" />
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
                <TimeInput source='openAt' />
                <TimeInput source='closedAt' />
                <NumberInput source="latitude" />
                <NumberInput source="longitude" />
            </SimpleForm>
        </Edit>
    )
}