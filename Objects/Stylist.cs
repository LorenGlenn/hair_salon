using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Salon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private string _hours;
    private int _phone;

    public Stylist(string name, string _hours, int phone, int id = 0)
    {
      _id = id;
      _name = name;
      _hours = hours;
      _phone = phone;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool nameEquality = (this.GetName() == newStylist.GetName());
        bool hoursEquality = (this.GetHours() == newStylist.GetHours());
        bool phoneEquality = (this.GetPhone() == newStylist.GetPhone());
        return (nameEquality && hoursEquality && phoneEquality);
      }
    }

    public override int GetHashCode()
    {
     return this.GetName().GetHashCode();
    }

    public string GetHours()
    {
      return _hours;
    }

    public string GetPhone()
    {
      return _phone;
    }

    public string GetId()
    {
      return _id;
    }

    public void Save()
{
  SqlConnection conn = DB.Connection();
  conn.Open();

  SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, hours, phone) OUTPUT INSERTED.id VALUES (@StylistName, @StylistHours, @StylistPhone);", conn);

  SqlParameter nameParameter = new SqlParameter();
  nameParameter.ParameterName = "@StylistName";
  nameParameter.Value = this.GetName();

  SqlParameter hoursParameter = new SqlParameter();
  hoursParameter.ParameterName = "@StylistHours";
  hoursParameter.Value = this.GetHours();

  SqlParameter phoneParameter = new SqlParameter();
  phoneParameter.ParameterName = "@StylistPhone";
  phoneParameter.Value = this.GetPhone();

  cmd.Parameters.Add(nameParameter);
  cmd.Parameters.Add(hoursParameter);
  cmd.Parameters.Add(phoneParameter);
  SqlDataReader rdr = cmd.ExecuteReader();

  while(rdr.Read())
  {
    this._id = rdr.GetInt32(0);
  }
  if (rdr != null)
  {
    rdr.Close();
  }
  if (conn != null)
  {
    conn.Close();
  }
}

public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        string stylistHours = rdr.GetString(2);
        int stylistPhone = rdr.GetInt32(3);
        Stylist newStylist = new Stylist(stylistName, stylistHours, stylistPhone, stylistId);
        allStylists.Add(newStylist);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allStylists;
    }
