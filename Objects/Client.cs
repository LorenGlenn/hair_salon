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
        bool colorEquality = (this.GetHairColor() == newClient.GetHairColor());
        bool phoneEquality = (this.GetPhone() == newClient.GetPhone());
        return (nameEquality && colorEquality && phoneEquality);
      }
    }

    public override int GetHashCode()
    {
     return this.GetName().GetHashCode();
    }

    public string GetName()
    {
      return _name;
    }

    public string GetHairColor()
    {
      return _hair_color;
    }

    public int GetPhone()
    {
      return _phone;
    }

    public int GetId()
    {
      return _id;
    }
  }
}
