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

    [Fact]
    public void Test1_CheckUpdateStylistInfo_True()
    {
      Stylist testStylist = new Stylist("Dan", "3-5", 8888888, 1);
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      Stylist toUpdate = result[0];
      int id = toUpdate.GetId();
      Stylist.Update("Dan", "3-5", 5555555, id);
      Stylist updated = Stylist.Find(id);
      Assert.Equal(updated.GetPhone(), 5555555);
    }

    [Fact]
    public void Test3_CheckDeleteStylist_False()
    {
      Stylist testStylist = new Stylist("Dan", "3-5", 8888888, 1);
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      Stylist.RemoveAStylist(testStylist.GetId());
      List<Stylist> deleted = Stylist.GetAll();
      bool isEqual = (result == deleted);
      Assert.Equal(false, isEqual);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
