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
      Client testClient = new Client("Kyle", "3-9", 5555555, 1);
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
