using System;
using System.Collections;
using enums.FormasPago;

public class Pago {
    //key
    public int ID_Pago { get; set; }
    //fk
    public int ID_Service { get; set; }
    public FormasPago Forma_Pago { get; set; } //THis should be standardize


    public Pago() {
        this.Forma_Pago = FormasPago.Debito;
    }

    //Temp: This converts the role into a string
    public string FormaPago() {
        try
        {
            if ((int)Forma_Pago.Debito == 0)
            {
                return "Debito";
            }
            else if((int)Forma_Pago.Credito == 1)
            {
                return "Credito";
            }
        }
        catch (System.Exception)
        {
            return "An error has occurred";
        }   
    }
}