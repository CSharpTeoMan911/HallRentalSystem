using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using HallRentalSystem.Classes;
using HallRentalSystem.Classes.StructuralAndBehavioralElements;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HallRentalSystem.Controllers
{
    [Firebase_Database]
    [ApiController]
    [Route("/halls")]
    public class Halls_Controller : Controller, CRUD_API_Strategy<string, string, string, string>
    {
        [HttpDelete("delete-halls")]
        public Task<ActionResult<string>> Delete([FromQuery] string? data)
        {
            ////////////////////////////////////////////////////////////////
            //                  !!! DO NOT IMPLEMENT !!!                  //
            ////////////////////////////////////////////////////////////////
            //  MODIFICATIONS TO THE HALLS ARE DONE ONLY IN THE ADMIN APP //
            ////////////////////////////////////////////////////////////////
            return Task.FromResult<ActionResult<string>>(Content("!!! NOT IMPLEMENTED !!!"));
        }

        [HttpGet("get-halls")]
        public async Task<ActionResult<string?>> Get([FromQuery] string data)
        {
            Halls? result = new Halls();
            Hall_ID hall_ID = new Hall_ID();

            ChildQuery? reference = Firebase_Database.firebaseClient?.Child("Halls");
            if (reference != null)
            {
                string r = await reference.OnceAsJsonAsync();
                result = Newtonsoft.Json.JsonConvert.DeserializeObject<Halls>(r);

                result.Hall_Id.TryGetValue("-NmvSQZA7Yb5HhHNjXMk", out hall_ID);


                //System.Diagnostics.Debug.WriteLine(result.Hall_ID.GetType());
                //System.Diagnostics.Debug.WriteLine(result.Hall_Id.Item2.Hall_Name);
                /*
                FilterQuery query = reference.OrderByKey().StartAt("").LimitToFirst(10);

                if (query != null)
                {
                    result = await query.OnceAsJsonAsync();
                }
                */
            }

            return new ActionResult<string?>(Newtonsoft.Json.JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented));
        }

        [HttpPost("insert-halls")]
        public Task<ActionResult<string>> Insert(string? data)
        {
            ////////////////////////////////////////////////////////////////
            //                  !!! DO NOT IMPLEMENT !!!                  //
            ////////////////////////////////////////////////////////////////
            //  MODIFICATIONS TO THE HALLS ARE DONE ONLY IN THE ADMIN APP //
            ////////////////////////////////////////////////////////////////
            return Task.FromResult<ActionResult<string>>(Content("!!! NOT IMPLEMENTED !!!"));
        }

        [HttpPut("update-halls")]
        public Task<ActionResult<string>> Update(string? data)
        {
            ////////////////////////////////////////////////////////////////
            //                  !!! DO NOT IMPLEMENT !!!                  //
            ////////////////////////////////////////////////////////////////
            //  MODIFICATIONS TO THE HALLS ARE DONE ONLY IN THE ADMIN APP //
            ////////////////////////////////////////////////////////////////
            return Task.FromResult<ActionResult<string>>(Content("!!! NOT IMPLEMENTED !!!"));
        }
    }
}

