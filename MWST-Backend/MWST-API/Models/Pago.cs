using System;
using enums;

public class Pago {
    //key
    public int ID_Pago { get; set; }
    //fk
    public int ID_Service { get; set; }
    public FormasPago Forma_Pago { get; set; }

    #region Detail
    public int ID_Vehicle { get; set; }
    //fk
    public int ID_Workshop { get; set; }
    //fk
    public int ID_History { get; set; }

    public float Pago_Servicio { get; set; }
    public DateTime FechaInicio; //Should be called from the class Service
    public DateTime FechaPromesa { get; set; }
    public DateTime FechaEntrega { get; set; }
    #endregion

    // Defaulted Forma_Pago as Debito
    public Pago() {
        this.Forma_Pago = FormasPago.Debito;
    }

    public Pago(FormasPago formas)
    {
        this.Forma_Pago = formas;
    }

    //Temp: This converts the role into a string
    public string FormaPago() {
        try
        {
            int DebitorCredit = (int)Forma_Pago;
            if (DebitorCredit == 0)
            {
                return "Débito";
            }
            else if(DebitorCredit == 1)
            {
                return "Crédito";
            }
            else return "Por favor escoja un método de pago válido.";
        }
        catch (Exception e)
        {
            // Rollback is required in case of an exception
            return $"{e}";
        }   
    }
}