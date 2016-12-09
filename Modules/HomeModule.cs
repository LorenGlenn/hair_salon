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

      Get["/stylist/update/{id}"] = parameters => {
        Stylist model = Stylist.Find(parameters.id);
        return View["update-stylist.cshtml", model];
      };

      Get["/client/update/{id}"] = parameters => {
        Client model = Client.Find(parameters.id);
        return View["update-client.cshtml", model];
      };

      Post["/stylist/delete/{id}"] = parameters =>
      {
        Stylist newStylist = Stylist.Find(parameters.id);
        string name = newStylist.GetName();
        Stylist.RemoveAStylist(parameters.id);
        return View["stylist-deleted.cshtml", name];
      };

      Post["/client/delete/{id}"] = parameters =>
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

      Post["/client-updated/{id}"] = parameters =>
      {
        string name = Request.Form["name"];
        string hair_color = Request.Form["hair"];
        int phone = Request.Form["phone"];
        Client.Update(name, hair_color, phone, parameters.id);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

      Post["/stylist-updated/{id}"] = parameters =>
      {
        string name = Request.Form["name"];
        string hours = Request.Form["hours"];
        int phone = Request.Form["phone"];
        Stylist.Update(name, hours, phone, parameters.id);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };

    }
  }
}
