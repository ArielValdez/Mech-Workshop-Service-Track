import { useEffect, useState } from "react"
import "./latestServices.css"

const getStateClassName = (state) => {
    if (state == "In Process")
        return "InProcess"
    else if (state == "Not started")
        return "NotStarted"
    else
        return "Finished"
}

const LatestServices = ({ services, dataProvider }) => {
    const Button = ({ state }) => {
        return (
            <button className={"widgetLgButton " + getStateClassName(state)}>{state}</button>
        )
    }

    const TableRow = ({ service }) => {
        const [ user, setUser ] = useState({
            name: '',
            lastname: ''
        })
        const [ payment, setPayment ] = useState({
            amount: ''
        }) 

        useEffect(() => {
            dataProvider.getOne('users', { id: service.userId })
                .then(result => setUser(result.data))
            dataProvider.getOne('payments', { id: service.paymentId })
                .then(result => setPayment(result.data))
        }, [])

        return (
            <tr className="widgetLgTr">
                <td className="widgetLgUser">
                    <span className="widgetLgName">{user.name + ' ' + user.lastname}</span>
                </td>
                <td className="widgetLgDate">{service.startedAt}</td>
                <td className="widgetLgAmount">${payment.amount}</td>
                <td className="widgetLgStatus">
                    <Button state={service.state}/>
                </td>
            </tr>
        )
    }

    return (
        <div className="widgetLg">
            <h3 className="widgetLgTitle">Latest services</h3>
            <table className="widgetLgTable">
                <tr className="widgetLgTr">
                    <th className="widgetLgTh">Customer</th>
                    <th className="widgetLgTh">Date</th>
                    <th className="widgetLgTh">Amount</th>
                    <th className="widgetLgTh">Status</th>
                </tr>
                {services.map(service => <TableRow service={service} />)}
            </table>
        </div>
    )
}

export default LatestServices