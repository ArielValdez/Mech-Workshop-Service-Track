using System;
using System.Collections;
using enums;

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
    public Role User_Role { get; set; }

    public User()
    {
        this.Active = true;
    }

    // Overloads
    #region Overloaded
    public User(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
        this.Active = true;
        this.Fecha_Creacion = DateTime.Now;
        this.User_Role = Role.User;
    }
    #endregion

    // This should be used after the user registers, then verifies the existence of the user
    public void EmailVerification()
    {
        // Implement later
    }

    public string GetUserRol()
    {
        int intRol = (int)User_Role;
        if (intRol == 0)
        {
            return "Usuario";
        }
        else if (intRol == 1)
        {
            return "Personal";
        }
        else if (intRol == 2)
        {
            return "Admin";
        }
        else
        {
            return "Not a Rol";
        }
    }

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