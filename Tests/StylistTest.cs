using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Salon.Objects;
using Salon;

namespace StylistTest
{
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=LOREN-PC\\SQLEXPRESS;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_SavesToDatabase()
    {
      Stylist testStylist = new Stylist("Kyle", "3-9", 5555555, 1);
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
