using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

using Challenge.Models;
using System.Web.Script.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace Challenge.Controllers
{
    //[EnableCors(origins: "http://micajota.es", headers: "*", methods: "*")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        
        public string Get()
        {            
            string data = DataBase.GetAllRoomsList();
            return data;
        }
       
        public string Get(int id)
        {            
            Room room = DataBase.GetOneRoom(id.ToString());
            string ret = room.Id + "|" + room.Name + "|" + room.Number + "|" + room.Occupant + "|";
            return ret;
        }
        
        public string Post([FromBody]Room2 myData)        
        {
            string ret = DataBase.UpdateRoom(myData); 
            return ret;
        }

    }
}
