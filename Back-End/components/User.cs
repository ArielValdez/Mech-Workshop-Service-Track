using System;
using System.Collections;

// Checking the security of the user is important
public class User
{
    //Key of the user
    public int ID_User { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    // Role of the user, to check the permissions of said user
    public Role User_Role { get; set; }

    // Foreign key for Profile class
    public Profile User_Profile;

    public bool Active;

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
        this.Role = Role.User;
    }
    #endregion
}