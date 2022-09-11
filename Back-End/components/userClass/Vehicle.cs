using System;
using System.Collections;

public class Vehicle
{
    // Key for Vehicle
    public int ID_Vehicle { get; set; }
    public int ID_User { get; set; }; //Should be the id of the user
    public int ID_Marca { get; set; } //FK for Marca
    public int ID_Model { get; set; } //FK for Model

    public string YearModel { get;set; } //This should store years
    public string VIN { get; set; }

    public Vehicle()
    {
        //Store the id of the user in User
    }

    public Vehicle(string marca, string model, string yearModel, string vin)
    {
        this.Marca = marca;
        this.Model = model;
        this.YearModel = yearModel;
        this.VIN = vin;
    }
}