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
                <TextField source="stateDescription"/>
                <ReferenceField source='vehicleId' reference='vehicles'>
                    <TextField source='plate'/>
                </ReferenceField>
                <DateField source='startedAt' showTime showDate />
                <DateField source='expectedAt' showTime showDate />
                <DateField source='finishedAt' showTime showDate />
                <ReferenceField source='workshopId' reference='workshops'>
                    <TextField source='name' />
                </ReferenceField>
                <ReferenceField source='paymentId' reference='payments'>
                    <TextField source='amount' />
                </ReferenceField>
                <ReferenceField source='userId' reference='users'>
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
                <TextInput source='stateDescription' multiline />
                <ReferenceInput source='vehicleId' reference='vehicles'/>
                <DateTimeInput source='startedAt' />
                <DateTimeInput source='expectedAt' />
                <DateTimeInput source='finishedAt'/>
                <ReferenceInput source='workshopId' reference='workshops'/>
                <ReferenceInput source='paymentId' reference='payments'/>
                <ReferenceInput source='userId' reference='users'/>
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
                <TextInput source='stateDescription' multiline />
                <ReferenceInput source='vehicleId' reference='vehicles'/>
                <DateTimeInput source='startedAt' />
                <DateTimeInput source='expectedAt' />
                <DateTimeInput source='finishedAt'/>
                <ReferenceInput source='workshopId' reference='workshops'/>
                <ReferenceInput source='paymentId' reference='payments'/>
                <ReferenceInput source='userId' reference='users'/>
            </SimpleForm>
        </Edit>
    )
}