using System;
using System.Collections;

public class Marca{
    //Key
    public int ID_Marca { get; set; }
    public string Name_Marca { get; set; }

    public Marca(){

    }

    public Marca(string name) {
        this.Name_Marca = name;
    }
}