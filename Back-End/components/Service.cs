using System;
using System.Collections;

public class Service
{
    public int ID_Service { get; set; }
    
    //THis should describe the type of service
    public string Detail_Service { get; set; }
    public string Status{ get; set; }
    //This should give a description of the status the service is currently in
    public string Detail_Status { get; set; }
    public string Matricula { get; set; }

    //Image of the current status of the vehicle
    //Public Image Image;

    public DateTime Fecha_Inicio { set => Datetime.now; }
    public DateTime Fecha_Promesa;
    public DateTime Fecha_Entrega;

    public History History; //Probably, not necessary here
    // The debt of the user, to pay the WorkShop
    public Payment Pay;
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