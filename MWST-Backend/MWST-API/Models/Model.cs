using System;
using System.Collections;

public class Model{
    //Key
    public int ID_Model { get; set; }
    public string Name_Model { get; set; }
    public int ID_Marca { get; set; } //FK for Marca

    public Model(){

    }
}