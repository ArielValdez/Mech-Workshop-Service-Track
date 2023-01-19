using System;
using System.Collections;
using enums;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public int ID_User { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Cedula { get; set; }
    public string PhoneNumber { get; set; }
    public string Cellphone { get; set; }
    public string Email { get; set; }

    public DateTime Fecha_Creacion;
    private bool Active;
    // Role of the user, to check the permissions of said user
    private Role User_Role { get; set; }

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
        this.User_Role = Role.Customer;
    }
    #endregion

    public string GetUserRol()
    {
        int intRol = (int)User_Role;
        string rol = "N"; // No role
        if (intRol == 0)
        {
            rol = "C"; // Customer
        }
        else if (intRol == 1)
        {
            rol = "M"; // Mechanic
        }
        else if (intRol == 2)
        {
            rol = "A"; // Adviser
        }
        else if (intRol == 3)
        {
            rol = "O"; // Owner / Adming
        }
        else
        {
            rol = "C"; // Customer
        }
        return rol;
    }
}