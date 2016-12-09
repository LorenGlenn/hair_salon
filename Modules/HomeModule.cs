using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using Salon.Objects;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Get["/clients/{id}"] = parameters => {
        List<Client> allClients = Client.GetAll(parameters.id);
        return View["clients.cshtml", allClients];
      };

      Get["/client/{id}"] = parameters => {
        Client foundClient = Client.Find(parameters.id);
        return View["client.cshtml", foundClient];
      };

      Get["/clients/add/{id}"] = parameters => {
        int model = parameters.id;
        return View["add-client.cshtml", model];
      };

      Post["/delete-stylist/{id}"] = parameters =>
      {
        Stylist newStylist = Stylist.Find(parameters.id);
        string name = newStylist.GetName();
        Stylist.RemoveAStylist(parameters.id);
        return View["stylist-deleted.cshtml", name];
      };

      Post["/delete-client/{id}"] = parameters =>
      {
        Client newClient = Client.Find(parameters.id);
        string name = newClient.GetName();
        Client.RemoveAClient(parameters.id);
        return View["client-deleted.cshtml", name];
      };

      Post["/stylist-added"] =_=>
      {
        string name = Request.Form["name"];
        string hours = Request.Form["hours"];
        int phone = Request.Form["phone"];
        Stylist newStylist = new Stylist(name, hours, phone);
        newStylist.Save();
        return View["stylist-added.cshtml", newStylist];
      };

      Post["/client-added/{id}"] = parameters =>
      {
        string name = Request.Form["name"];
        string hair_color = Request.Form["hair"];
        int phone = Request.Form["phone"];
        Client newClient = new Client(name, hair_color, phone, parameters.id);
        newClient.Save();
        return View["client-added.cshtml", newClient];
      };


    }
  }
}
