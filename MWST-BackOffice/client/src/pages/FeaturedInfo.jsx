import "./featuredInfo.css"
import ArrowDownwardIcon from '@mui/icons-material/ArrowDownward';
import { React, useEffect, useState } from "react";
import restProvider from "ra-data-simple-rest"

const dataProvider = restProvider("http://localhost:3000")

const getMostCommonProp = (obj) => {
    let mostCommonVal = 0
    let mostCommonProp = ''
    for (const [key, value] of Object.entries(obj)) {
        if (value > mostCommonVal) {
            mostCommonVal = value
            mostCommonProp = key
        }
    }

    return mostCommonProp
}

const FeaturedInfo = () => {
    const [ mostCommonModel, setMostCommonModel ] = useState('')
    const [ mostCommonService, setMostCommonService ] = useState('')

    useEffect(() => {
        dataProvider
			.getList("vehicles", {
				sort: { field: "model", order: "ASC" },
				pagination: { page: 1, perPage: 5 },
			})
			.then((result) => {
				const models = result.data.reduce((prev, curr) => {
					isNaN(prev[curr.model]) ? (prev[curr.model] = 1) : prev[curr.model]++
					return prev
				}, {})

				setMostCommonModel(getMostCommonProp(models))
			})
        
        dataProvider
            .getList('services', {
                sort: { field: 'serviceType', order: 'ASC' },
                pagination: { page: 1, perPage: 20 }
            })
            .then(result => {
                const services = result.data.reduce((prev, curr) => {
                    isNaN(prev[curr.serviceType]) ? (prev[curr.serviceType] = 1) : prev[curr.serviceType]++
                    return prev
                }, {})

                console.log(services)
                setMostCommonService(getMostCommonProp(services))
            })
    }, [])

    return (
        <div className="featured">
            <div className="featuredItem">
                <span className="featuredTitle">Automovil más común</span>
                <div className="featuredMoneyContainer">
                    <span className="featuredMoney">{mostCommonModel}</span>
                </div>
            </div>
            <div className="featuredItem">
                <span className="featuredTitle">Tipo de servicio más deseado</span>
                <div className="featuredMoneyContainer">
                    <span className="featuredMoney">{mostCommonService}</span>
                </div>
            </div>
        </div>
    )
}

export default FeaturedInfo