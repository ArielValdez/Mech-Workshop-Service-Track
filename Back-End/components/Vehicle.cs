using System;
using System.Collections;

public class Vehicle
{
    // Key for Vehicle
    public int ID_Vehicle { get; set; }
    public User User; //Should be the id of the user
    public string Marca { get; set; }
    public string Model { get; set; }
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