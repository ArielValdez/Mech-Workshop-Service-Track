using System;
using System.Collections;

public class Pieza {
    //key
    public int ID_Pieza { get; set ;}
    //fk
    public int ID_Pago { get; set; }
    public string Nombre_Pieza { get; set; }
    public string Descripcion_Pieza { get; set; }
    public float Precio { get; set; }
    public int Cantidad { get; set; }

    public Pieza() {

    }

    public Pieza(string nombre, string desc, float precio, int cant) {
        this.Nombre_Pieza = nombre;
        this.Descripcion_Pieza = desc;
        this.Precio = precio;
        this.cant = Math.Abs(cant); //There cannot be a negative number
    }
}