import { Datagrid, List, TextField } from "react-admin"

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