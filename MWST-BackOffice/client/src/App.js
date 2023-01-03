import React from "react";
import { Admin, CustomRoutes, Resource } from "react-admin";
import { Route } from "react-router-dom"
import restProvider from "ra-data-simple-rest";
import { UserList, UserCreate, UserEdit } from "./components/Users";
import { WorkshopList, WorkshopCreate, WorkshopEdit } from "./components/Workshops";
import { ServiceList, ServiceCreate, ServiceEdit } from "./components/Services";
import { PaymentList } from "./components/Payments";
import { VehicleList, VehicleCreate, VehicleEdit } from "./components/Vehicles";
import PersonIcon from '@mui/icons-material/Person';
import BuildIcon from '@mui/icons-material/Build';
import CreditCardIcon from '@mui/icons-material/CreditCard';
import HomeRepairServiceIcon from '@mui/icons-material/HomeRepairService';
import DirectionsCarIcon from '@mui/icons-material/DirectionsCar'
import authProvider from "./AuthProvider";
import Dashboard from "./pages/Dashboard";

const App = () => {
	return (
		<Admin dashboard={Dashboard} dataProvider={restProvider("http://localhost:3000")} authProvider={authProvider}>
			<Resource name="users" list={UserList} create={UserCreate} 
				edit={UserEdit} icon={PersonIcon} recordRepresentation="name">
			</Resource>
			<Resource name="workshops" list={WorkshopList} create={WorkshopCreate}
				edit={WorkshopEdit} icon={HomeRepairServiceIcon} recordRepresentation="name">
			</Resource>
			<Resource name="services" list={ServiceList} create={ServiceCreate} 
				edit={ServiceEdit} icon={BuildIcon}>
			</Resource>
			<Resource name="payments" list={PaymentList} icon={CreditCardIcon}>
			</Resource>
			<Resource name="vehicles" list={VehicleList} create={VehicleCreate} 
				edit={VehicleEdit} icon={DirectionsCarIcon} recordRepresentation="plate">
			</Resource>
		</Admin>
	)
}

export default App
