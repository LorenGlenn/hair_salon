using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Salon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;
    private string _hair_color;
    private int _phone;

    public Client(string name, string hair, int phone, int id = 0)
    {
      _id = id;
      _name = name;
      _hair_color = hair;
      _phone = phone;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool colorEquality = (this.GetColor() == newClient.GetColor());
        bool phoneEquality = (this.GetPhone() == newClient.GetPhone());
        return (nameEquality && colorEquality && phoneEquality);
      }
    }

    public override int GetHashCode()
    {
     return this.GetName().GetHashCode();
    }
