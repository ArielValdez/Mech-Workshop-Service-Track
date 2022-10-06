using System;
using System.Collections;

public class Condition {
    //key
    public int ID_Estado { get; set; }
    //fk
    public int ID_Service { get; set; }
    public string Nombre_Estado { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }

    public Condition(){

    }

    public Condition(string nombre, string desc) {
        this.Nombre_Estado = nombre;
        this.Descripcion = desc;
    }

    //This method is to see the description of the state, given the ID
    public string ViewDescription(Condition Estado) {
        try
        {
            if (Estado.ID_Estado == null) {
            return "Nada que ver por el momento.";
            }
            else { // The ID exists
                return this.Descripcion;
            }
        }
        catch (Exception e)
        {
            return $"{e}";
        }
    }
}