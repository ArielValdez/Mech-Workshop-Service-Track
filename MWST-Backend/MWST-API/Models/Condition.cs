using System;
using System.Collections;
using System.Drawing;

public class Condition {
    //key
    public int ID_Estado { get; set; }
    //fk
    public int ID_Service { get; set; }
    public string Nombre_Estado { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; } // This one should store an image instead

    public Condition(){
        
    }

    public Condition(string nombre, string desc) {
        this.Nombre_Estado = nombre;
        this.Descripcion = desc;
    }

    //This method is to see the description of the state, given the ID
    public string ViewDescription() {
        try
        {
            return this.Descripcion;
        }
        catch (Exception e)
        {
            return $"{e}";
        }
    }
}