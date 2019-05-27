using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppData.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

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
            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
        }



        //GetClient
        [HttpGet]
        public IActionResult GetClient()
        {
            var clients = ContextC.Client.ToList();

            return Ok(clients);
        }

        //GetClient_by_id
        [HttpGet("{id}")]
        public IActionResult GetClient_by_id(int id)
        {
            var clients = ContextC.Client.ToList();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].id == id)
                {
                    return Ok(clients[i]);

                }
            }
            return NotFound();
        }


        //POSTClient
        [HttpPost]
        public ActionResult CreateClient([FromBody] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("--> client: -", client.Nom, " ", client.Prenom, "- is being Added to the Database ");
                    ContextC.Add(client);
                    ContextC.SaveChanges();
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return Ok();
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

            return Ok(client);
        }

        //UpdateClient_with_id
        [HttpPut("{id}")]
        public ActionResult UpdateCient_with_id(int id, [FromBody] Client client)
        {
            /*
            ContextC.Entry(client).State = EntityState.Modified;
            
            ContextC.SaveChanges();

            return Ok();

            */
                        var client1 = ContextC.Client.Find(id);

                        if (client1 != null)
                        {
                            ContextC.Entry<Client>(client1).State = EntityState.Detached;
                            try
                            {

                                if (ModelState.IsValid)
                                {
                                  //  Console.WriteLine("--> client: -", client.Nom, " ", client.Prenom, "- is being Modified ");
                                   // ContextC.Entry<Client>(client).State = EntityState.Detached;
                                    ContextC.Entry(client).State = EntityState.Modified;
                                    
                                    ContextC.SaveChanges();
                                }
                            }
                            catch (DataException)
                            {
                                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                            }
                            return Ok(client);
                        }
                        return NotFound();
                     }


        [HttpDelete]
        public ActionResult DeleteClient([FromBody]Client client)
        {
            try
            {
                Console.WriteLine("--> client: -", client.Nom, " ", client.Prenom, "- is being Deleted ");
                ContextC.Remove(client);
                ContextC.SaveChanges();
                return Ok("{\"message\":\"client Supprimé avec Success\"}");
            }
            catch ( Exception e)
            {
                string errorstring = "An error accured during the deleting operation of the client , please try again in a while " + e.StackTrace.ToString();
                return Ok(errorstring); }

        }
        //Delete_with_id
        [HttpDelete("{id}")]
        public ActionResult DeleteClient_with_id(int id)
        {

            Client client = new Client(id);
            var client1 = ContextC.Client.Find(id);
            if (client1 != null)
            {
                ContextC.Entry<Client>(client1).State = EntityState.Detached;

                try
                {
                    Console.WriteLine("--> client: -", client.Nom, " ", client.Prenom, "- is being Deleted ");
                    ContextC.Entry<Client>(client1).State = EntityState.Detached;
                    ContextC.Remove(client);
                    ContextC.SaveChanges();
                    return Ok("{\"message\":\"client Supprimé avec Success\"}");

                }
                catch (Exception e)


                {
                    string errorstring = "An error accured during the deleting operation of the client , please try again in a while " + e.StackTrace.ToString();
                    return Ok(errorstring);
                }
                
                
            }
            return Ok("The Client is not found ");
        }
    }
}