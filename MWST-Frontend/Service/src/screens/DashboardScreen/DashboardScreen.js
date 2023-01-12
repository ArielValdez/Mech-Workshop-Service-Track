import React, { useEffect, useState } from 'react'
import { SafeAreaView, View, Text, Image, StyleSheet } from 'react-native'
import Logo2 from '../../../assets/LogoOficial2.png'
import CustomText from '../../components/CustomText'
import theme from '../../Theme'
import PendingServiceInfo from './PendingServiceInfo'
import ServiceInfo from './ServiceInfo'
import LineBreak from '../../components/LineBreak'
import { getLatestFinishedAppointments, getPendingAppointment } from '../../services/AppointmentsService'
import { useUser } from '../../context/UserContext'
import { useTranslation } from 'react-i18next'

const DashboardScreen = () => {
    const [ pendingService, setPendingService ] = useState()
    const [ latestFinishedServices, setLatestFinishedServices ] = useState([])

    const { t, i18n } = useTranslation()
    const [ user, setUser ] = useUser()
    
    useEffect(() => {
        getPendingAppointment(user.id)
            .then(appointment => setPendingService(appointment))
        getLatestFinishedAppointments(user.id)
            .then(appointments => setLatestFinishedServices(appointments))
            .catch(err => console.log(err))
    }, [])

    return (
        <View style={styles.container}>
            <View style={styles.logoContainer}>
                <Image 
                    source={Logo2}
                    style={styles.logo}
                />
            </View>
            <CustomText style={styles.headerText} type='Bold'>{t('appointmentsAlredyStarted')}</CustomText>
            <PendingServiceInfo service={pendingService} />
            <CustomText style={styles.headerText} type='Bold'>{t('recent')}</CustomText>
            <View style={styles.recentServicesContainer}>
                <ServiceInfo service={latestFinishedServices[0]} />
                <LineBreak color='rgba(0, 0, 0, 0.45)' />
                <ServiceInfo service={latestFinishedServices[1]} />
                <LineBreak color='rgba(0, 0, 0, 0.45)' />
                <ServiceInfo service={latestFinishedServices[2]} />
            </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: theme.colors.white,
        padding: 10, paddingTop: 20
    },
    logoContainer: {
        backgroundColor: theme.colors.darkPrimary,
        height: 150,
        width: '100%',
        alignSelf: 'center',
        alignItems: 'center',
        borderRadius: 15,
        marginVertical: 10
    },
    logo: {
        height: 150,
        width: '80%',
    },
    headerText: {
        fontSize: 18,
        marginVertical: 10
    },
    recentServicesContainer: {
        borderRadius: 15,
        borderColor: 'rgba(0, 0, 0, 0.45)',
        borderWidth: 1,
    },
})

export default DashboardScreen