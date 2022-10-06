using System;
using System.Collections;

// This should store information about the cars for the user to see

public class History
{
    //Key
    public int ID_History { get; set; }
    public int ID_User { get; set; } // FK for Profile
    public int ID_Pago { get; set; } // Payment, implement later
    public DateTime Fecha;

    public History()
    {
        Fecha = DateTime.Now;
    }

    public void CallHistory()
    {
        //This Method should call the activities of the user, once called
    }
}