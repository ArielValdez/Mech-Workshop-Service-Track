import { Create, Datagrid, DateField, DateTimeInput, DeleteButton, 
    Edit, EditButton, List, SimpleForm, TextField, TextInput,
    ReferenceField, 
    SelectInput,
    ReferenceInput} from "react-admin"

export const ServiceList = (props) => {
    return (
        <List title='Services' {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='serviceType' />
                <TextField source='description' />
                <TextField source='state' />
                <ReferenceField source='vehicle_id' reference='vehicles'>
                    <TextField source='plate'/>
                </ReferenceField>
                <DateField source='startedAt' showTime showDate />
                <DateField source='expectedAt' showTime showDate />
                <DateField source='finishedAt' showTime showDate />
                <ReferenceField source='workshop_id' reference='workshops'>
                    <TextField source='name' />
                </ReferenceField>
                <ReferenceField source='payment_id' reference='payments'>
                    <TextField source='amount' />
                </ReferenceField>
                <ReferenceField source='user_id' reference='users'>
                    <TextField source='name' />
                </ReferenceField>
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
                <SelectInput source='serviceType' choices={[
                    { id: 'Reparation', name: 'Reparation' },
                    { id: 'Checkup', name: 'Checkup' },
                ]} />
                <TextInput source='description' multiline />
                <SelectInput source='state' choices={[
                    { id: 'Not started', name: 'Not started'},
                    { id: 'In Process', name: 'In Process'},
                    { id: 'Finished', name: 'Finished'},
                ]} />
                <ReferenceInput source='vehicle_id' reference='vehicles'/>
                <DateTimeInput source='startedAt' />
                <DateTimeInput source='expectedAt' />
                <DateTimeInput source='finishedAt'/>
                <ReferenceInput source='workshop_id' reference='workshops'/>
                <ReferenceInput source='payment_id' reference='payments'/>
                <ReferenceInput source='user_id' reference='users'/>
            </SimpleForm>
        </Create>
    )
}

export const ServiceEdit = (props) => {
    return (
        <Edit title='Edit service' {...props}>
            <SimpleForm>
            <SelectInput source='serviceType' choices={[
                    { id: 'Reparation', name: 'Reparation' },
                    { id: 'Checkup', name: 'Checkup' },
                ]} />
                <TextInput source='description' multiline />
                <SelectInput source='state' choices={[
                    { id: 'Not started', name: 'Not started'},
                    { id: 'In Process', name: 'In Process'},
                    { id: 'Finished', name: 'Finished'},
                ]} />
                <ReferenceInput source='vehicle_id' reference='vehicles'/>
                <DateTimeInput source='startedAt' />
                <DateTimeInput source='expectedAt' />
                <DateTimeInput source='finishedAt'/>
                <ReferenceInput source='workshop_id' reference='workshops'/>
                <ReferenceInput source='payment_id' reference='payments'/>
                <ReferenceInput source='user_id' reference='users'/>
            </SimpleForm>
        </Edit>
    )
}