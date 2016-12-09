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
    }
  }
}
