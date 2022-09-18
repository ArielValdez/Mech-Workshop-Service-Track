using System;
using System.Collections;
using userClass.Vehicle;

public class Detail {
    //key
    public int ID_Pago { get; set; } //ID from the class Pago
    //fk
    public int ID_Vehicle { get; set; }
    //fk
    public int ID_Workshop { get; set; }
    //fk
    public int ID_History { get; set; }

    public float Pago_Servicio { get; set; }
    public DateTime FechaInicio { set => DateTime.now } //Should be called from the class Service
    public DateTime FechaPromesa { get; set; }
    public DateTime FechaEntrega { get; set; }

    public Detail() {

    }
}