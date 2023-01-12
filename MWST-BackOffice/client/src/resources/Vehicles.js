import { Create, Datagrid, DeleteButton, Edit, EditButton, List, SimpleForm, TextField, TextInput, ReferenceInput } from "react-admin"


export const VehicleList = (props) => {
    return (
        <List title='Vehicle list' {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='userId' />
                <TextField source='plate' />
                <TextField source='model' />
                <TextField source='vin' />
                <EditButton />
                <DeleteButton />
            </Datagrid>
        </List>
    )
}

export const VehicleCreate = (props) => {
    return (
        <Create title='Create vehicle' {...props}>
            <SimpleForm>
                <TextInput source='userId' />
                <TextInput source='plate' placeholder='A759686'/>
                <TextInput source='model' />
                <TextInput source='vin' placeholder='4Y1SL65848Z411439'/>
            </SimpleForm>
        </Create>
    )
}

export const VehicleEdit = (props) => {
    return (
        <Edit title='Edit vehicle' {...props}>
            <SimpleForm>
                <TextInput source='userId' />
                <TextInput source='plate' placeholder='A759686'/>
                <TextInput source='model' />
                <TextInput source='vin' placeholder='4Y1SL65848Z411439'/>
            </SimpleForm>
        </Edit>
    )
}