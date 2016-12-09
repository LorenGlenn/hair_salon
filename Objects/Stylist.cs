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

    public Stylist(string name, string hours, int phone, int id = 0)
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

    public string GetName()
    {
      return _name;
    }

    public string GetHours()
    {
      return _hours;
    }

    public int GetPhone()
    {
      return _phone;
    }

    public int GetId()
    {
      return _id;
    }

    public void Update(string newName, string newHours, int newPhone, int id = 0)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET name = @StylistName, hours = @StylistHours, phone = @StylistPhone WHERE id = @StylistId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@StylistName";
      nameParameter.Value = newName;

      SqlParameter hoursParameter = new SqlParameter();
      hoursParameter.ParameterName = "@StylistHours";
      hoursParameter.Value = newHours;

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@StylistPhone";
      phoneParameter.Value = newName;

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(hoursParameter);
      cmd.Parameters.Add(phoneParameter);
      cmd.Parameters.Add(stylistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

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

    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);
      SqlParameter sytlistIdParameter = new SqlParameter();
      sytlistIdParameter.ParameterName = "@StylistId";
      sytlistIdParameter.Value = id.ToString();
      cmd.Parameters.Add(sytlistIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundStylistId = 0;
      int foundStylistPhone = 0;
      string foundStylistName = null;
      string foundStylistHours = null;
      while(rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName = rdr.GetString(1);
        foundStylistHours = rdr.GetString(2);
        foundStylistPhone = rdr.GetInt32(3);
      }
      Stylist foundStylist = new Stylist(foundStylistName, foundStylistHours, foundStylistPhone, foundStylistId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundStylist;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
