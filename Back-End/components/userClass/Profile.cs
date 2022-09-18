using System;
using System.Collections;

public class Profile
{
    //Key
    public int ID_User { get; set; }

    //Username and password of the user. The user can use either their username or email to log in
    public string Username { get; set; }
    public string Password { get; set; }

    //Should be limited to thirteen digits in the following manner: 0-1234567-891
    public string Cedula { get; set; }
    //Should be limited to thirteen digits in the following order: (809)000-0000
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    public DateTime Fecha_Creacion { set => DateTime.now }
    private bool Active;

    public Profile()
    {
        //Props

        //Once created an account, the profile of the user will be automatically active
        // for a certain period of time.
        Active = true;
    }

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