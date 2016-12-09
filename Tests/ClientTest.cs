using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Salon.Objects;
using Salon;

namespace ClientTest
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=LOREN-PC\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_SavesToDatabase()
    {
      Client testClient = new Client("Cindy", "Red", 5555555, 1);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test1_ChecksClientAssociatedWithStylist_True()
    {
      Stylist newStylist = new Stylist("Kyle", "3-9", 5555555);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      int stylistId = allStylists[0].GetId();
      Client newClient = new Client("Cindy", "Blue", 8888888, stylistId, 3);
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      int clientStylistId = allClients[0].GetStylistId();
      Assert.Equal(stylistId, clientStylistId);
    }

    [Fact]
    public void Test2_ChecksMultipleClientsAssociatedWithStylist_True()
    {
      Stylist newStylist = new Stylist("Kyle", "3-9", 5555555);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      int stylistId = allStylists[0].GetId();
      Client newClient = new Client("Cindy", "Blue", 8888888, stylistId, 3);
      Client otherNewClient = new Client("Dan", "Black", 8988888, stylistId, 4);
      newClient.Save();
      otherNewClient.Save();
      List<Client> allClients = Client.GetAll();
      int clientStylistIdOne = allClients[0].GetStylistId();
      int clientStylistIdTwo = allClients[1].GetStylistId();
      int stylistIdFinal = (stylistId + stylistId);
      int clientStylistIdFinal = (clientStylistIdOne + clientStylistIdTwo);
      Assert.Equal(stylistIdFinal, clientStylistIdFinal);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
