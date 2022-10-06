using System;
using System.Collections;

public class Mantenimiento {
    //key
    public int ID_Mantenimiento { get; set; }
    public string Tipo_Mantenimiento { get; set; } //Describes the maintenance

    public Mantenimiento() {

    }

    public Mantenimiento(string tipo) {
        this.Tipo_Mantenimiento = tipo;
    }
}