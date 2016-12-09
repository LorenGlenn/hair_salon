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
    private int _stylist_id;

    public Client(string name, string hair, int phone, int stylistId, int id = 0)
    {
      _id = id;
      _name = name;
      _hair_color = hair;
      _phone = phone;
      _stylist_id = stylistId;
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
        bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (nameEquality && colorEquality && phoneEquality && stylistEquality);
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

    public int GetStylistId()
    {
      return _stylist_id;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetPhone(int newPhone, int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE clients SET phone = @ClientPhone WHERE id = @ClientId;", conn);

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@ClientPhone";
      phoneParameter.Value = newPhone;

      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = id;

      cmd.Parameters.Add(phoneParameter);
      cmd.Parameters.Add(clientIdParameter);
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

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, hair_color, phone, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientHairColor, @ClientPhone, @StylistId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();

      SqlParameter hairParameter = new SqlParameter();
      hairParameter.ParameterName = "@ClientHairColor";
      hairParameter.Value = this.GetHairColor();

      SqlParameter phoneParameter = new SqlParameter();
      phoneParameter.ParameterName = "@ClientPhone";
      phoneParameter.Value = this.GetPhone();

      SqlParameter stylistParameter = new SqlParameter();
      stylistParameter.ParameterName = "@StylistId";
      stylistParameter.Value = this.GetStylistId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(hairParameter);
      cmd.Parameters.Add(phoneParameter);
      cmd.Parameters.Add(stylistParameter);
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

    public static List<Client> GetAll(int newStylistId)
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);

      SqlParameter stylistParameter = new SqlParameter();
      stylistParameter.ParameterName = "@StylistId";
      stylistParameter.Value = newStylistId;

      cmd.Parameters.Add(stylistParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientHairColor = rdr.GetString(2);
        int clientPhone = rdr.GetInt32(3);
        int stylistId = rdr.GetInt32(4);
        Client newClient = new Client(clientName, clientHairColor, clientPhone, stylistId, clientId);
        allClients.Add(newClient);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allClients;
    }

    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = id.ToString();
      cmd.Parameters.Add(clientIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundClientId = 0;
      int foundClientPhone = 0;
      string foundClientName = null;
      string foundClientHair = null;
      int foundClientStylist = 0;
      while(rdr.Read())
      {
        foundClientId = rdr.GetInt32(0);
        foundClientName = rdr.GetString(1);
        foundClientHair = rdr.GetString(2);
        foundClientPhone = rdr.GetInt32(3);
        foundClientStylist = rdr.GetInt32(4);
      }
      Client foundClient = new Client(foundClientName, foundClientHair, foundClientPhone, foundClientStylist, foundClientId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundClient;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
