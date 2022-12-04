import { Datagrid, List, NumberField, TextField } from "react-admin"

export const PaymentList = (props) => {
    return (
        <List title='Payments' {...props}>
            <Datagrid>
                <TextField source='id' />
                <TextField source='service_id' />
                <TextField source='payment_type' />
                <NumberField source='amount' locales='en-US' options={{style: 'currency', currency: 'USD'}} />
            </Datagrid>
        </List>
    )
}