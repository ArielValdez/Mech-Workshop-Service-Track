using System;
using System.Collections;
using enums.FormasPago;

public class Pago {
    //key
    public int ID_Pago { get; set; }
    //fk
    public int ID_Service { get; set; }
    public FormasPago Forma_Pago { get; set; } //THis should be standardize

    #region Detail
    public int ID_Vehicle { get; set; }
    //fk
    public int ID_Workshop { get; set; }
    //fk
    public int ID_History { get; set; }

    public float Pago_Servicio { get; set; }
    public DateTime FechaInicio { set => DateTime.now } //Should be called from the class Service
    public DateTime FechaPromesa { get; set; }
    public DateTime FechaEntrega { get; set; }
    #endregion

    public Pago() {
        this.Forma_Pago = FormasPago.Debito;
    }

    //Temp: This converts the role into a string
    public string FormaPago() {
        try
        {
            if ((int)Forma_Pago.Debito == 0)
            {
                return "Débito";
            }
            else if((int)Forma_Pago.Credito == 1)
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