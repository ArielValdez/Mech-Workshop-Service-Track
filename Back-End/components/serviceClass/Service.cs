using System;
using System.Collections;

public class Service
{
    //Key
    public int ID_Service { get; set; }
    //FK
    public int ID_Mantenimiento { get; set; }
    public string Service_Type { get; set; }
    public DateTime FechaPromesa { get; set; }

    // The WorkShop where the services were done
    public WorkShop WorkShop;

    public Service()
    {

    }

    public bool Notifications ()
    {
        // The notifications of the app
        return false;
    }
}