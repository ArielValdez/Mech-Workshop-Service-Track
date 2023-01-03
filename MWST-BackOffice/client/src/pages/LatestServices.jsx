import "./latestServices.css"

const getStateClassName = (state) => {
    if (state == "In Process")
        return "InProcess"
    else if (state == "Not started")
        return "NotStarted"
    else
        return "Finished"
}

const LatestServices = ({ services }) => {
    const Button = ({ state }) => {
        return (
            <button className={"widgetLgButton " + getStateClassName(state)}>{state}</button>
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
                {services.map(service => (
                    <tr className="widgetLgTr">
                    <td className="widgetLgUser">
                        <span className="widgetLgName">Susan Carol</span>
                    </td>
                    <td className="widgetLgDate">{service.startedAt}</td>
                    <td className="widgetLgAmount">$122.00</td>
                    <td className="widgetLgStatus">
                        <Button state={service.state}/>
                    </td>
                </tr>
                ))}
            </table>
        </div>
    )
}

export default LatestServices