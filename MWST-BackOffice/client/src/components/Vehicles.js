import { PropaneSharp } from "@mui/icons-material"
import { Create, Datagrid, Edit, List, SimpleForm, TextField, TextInput } from "react-admin"

export const VehicleList = (props) => {
    return (
        <List title='Vehicle list' {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='user_id' />
                <TextField source='plate' />
                <TextField source='model' />
                <TextField source='vin' />
            </Datagrid>
        </List>
    )
}

export const VehicleCreate = (props) => {
    return (
        <Create title='Create vehicle' {...props}>
            <SimpleForm>
                <TextInput source='user_id' />
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
                <TextInput source='user_id' />
                <TextInput source='plate' placeholder='A759686'/>
                <TextInput source='model' />
                <TextInput source='vin' placeholder='4Y1SL65848Z411439'/>
            </SimpleForm>
        </Edit>
    )
}