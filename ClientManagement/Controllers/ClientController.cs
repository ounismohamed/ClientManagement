using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppData.Models;
using System.Data;

namespace ClientManagement.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        readonly ContextClass ContextC;
        //cstrtor
        public ClientController(ContextClass context)
        {
            ContextC = context;
        }



        //GetClient
        [HttpGet]
        public IActionResult GetClient()
        {
            var clients = ContextC.Client.ToList();

            return Ok(clients);
        }



        //POSTClient
        [HttpPost]
        public ActionResult CreateCient([FromBody] Client client)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("--> client: -",client.Nom," ",client.Prenom,"- is being Added to the Database ");
                    ContextC.Add(client);
                    ContextC.SaveChanges();
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return Ok("Creation Client terminée avec success");
        }

        //UpdateClient
        [HttpPut]
        public ActionResult UpdateCient([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("--> client: -", client.Nom, " ", client.Prenom, "- is being Modified ");
                    ContextC.Update(client);
                    ContextC.SaveChanges();
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return Ok("Creation Client terminée avec success");
        }
        [HttpDelete]
        public ActionResult DeleteClient ([FromBody]Client client)
        { 
          try
            {
                Console.WriteLine("--> client: -", client.Nom, " ", client.Prenom, "- is being Deleted ");
                ContextC.Remove(client);
                ContextC.SaveChanges();
                return Ok(" Client Supprimé avec Success ");

            } catch (Exception )
            { return Ok("An error accured during the deleting operation of the client , please try again in a while "); }

        }

     
    }
}