using System;
using System.Collections;

public class Vehicle
{
    // Key for Vehicle
    public int ID_Vehicle { get; set; }
    public string Matricula { get; set; }
    public int ID_User { get; set; } //Should be the id of the user
    public int ID_Marca { get; set; } //FK for Marca
    public int ID_Model { get; set; } //FK for Model
    public string VIN { get; set; }
    //Change to an enum or a list
    public string Color { get; set; }

    public Vehicle()
    {
        //Store the id of the user in User
    }

    public Vehicle(int marca, int model, string yearModel, string vin)
    {
        this.ID_Marca = marca;
        this.ID_Model = model;
        this.YearModel = yearModel;
        this.VIN = vin;
    }
}