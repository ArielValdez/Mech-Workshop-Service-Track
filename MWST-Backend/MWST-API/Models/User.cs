using System;
using System.Collections;
//using enums.Roles;

// Checking the security of the user is important
public class User
{
    //Key of the user
    public int ID_User { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    //Profile
    public string Username { get; set; }
    public string Password { get; set; }

    //Should be limited to thirteen digits in the following manner: 0-1234567-891
    public string Cedula { get; set; }
    //Should be limited to thirteen digits in the following order: (809)000-0000
    public string PhoneNumber { get; set; }
    public string Cellphone { get; set; }
    public string Email { get; set; }

    public DateTime Fecha_Creacion;
    private bool Active;
    // Role of the user, to check the permissions of said user
    //public Role User_Role { get; set; }

    public User()
    {

    }

    // Overloads
    #region Overloaded
    public User(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
        this.Active = true;
        this.Fecha_Creacion = DateTime.Now;
        //this.Role = Role.User;
    }
    #endregion

    //Profile
    public void Ask4Service() 
    {
        // Code to call service
    }

    public float Payment() // Check if this is better with data type "double" or "decimal"
    {
        //Code for the user to pay for the service
        return 0f;
    }
}