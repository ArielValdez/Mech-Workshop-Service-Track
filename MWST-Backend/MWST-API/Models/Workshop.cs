using System;
using System.Collections;

public class WorkShop
{
    public int ID_WorkShop { get; set; }
    public string Name_WorkShop { get; set; }
    public string Location { get; set; } //string is a placeholder for now

    public DateTime OpenTime;
    public DateTime ClosedTime;

    public WorkShop()
    {

    }

    public float RecivePayment()
    {
        //Code for the payment recieved
        return 0f;
    }

    public void Services()
    {
        //Code for the services given by the workshop
    }
}