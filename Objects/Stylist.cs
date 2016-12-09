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

  SqlCommand cmd = new SqlCommand("INSERT INTO hair_salon (name, hours, phone) OUTPUT INSERTED.id VALUES (@StylistName, @StylistHours, @StylistPhone);", conn);

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
