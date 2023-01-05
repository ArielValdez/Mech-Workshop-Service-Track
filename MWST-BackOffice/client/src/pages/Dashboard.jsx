import { React, useEffect, useState } from "react";
import { Card, CardContent } from '@mui/material';
import { Title } from 'react-admin';
import "./dashboard.css"
import FeaturedInfo from "./FeaturedInfo"
import LatestServices from "./LatestServices";
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

const Dashboard = () => {
    const [ services, setServices ] = useState([])
    
    useEffect(() => {
        dataProvider.getList('services', {
            sort: { field: 'id', order: 'ASC' },
            pagination: { page: 1, perPage: 5 }
        }).then(result => setServices(result.data))
    }, [])

    return (
        <Card className="card">
            <Title title="Dashboard"/>
            <CardContent>
                <FeaturedInfo />
                <LatestServices services={services} dataProvider={dataProvider}/>
            </CardContent>
        </Card>
    )
}

export default Dashboard