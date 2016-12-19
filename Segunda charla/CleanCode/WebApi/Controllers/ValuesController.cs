using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ItemController : ApiController
    {
        private static Dictionary<int,Item> inMemoryItems = new Dictionary<int,Item>();

        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(inMemoryItems.Values.ToList());
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok(inMemoryItems[id]);
        }

        // POST api/values
        public void Post(Item value)
        {
            inMemoryItems.Add(value.Id, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
