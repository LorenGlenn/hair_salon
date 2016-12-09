using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Salon.Objects;

namespace SalonTest
{
  public class BeanieTest : IDisposable
  {
    public BeanieTest()
    {
      Inventory.DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }
  }
}
