using Challenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Challenge.Controllers
{
    //[EnableCors(origins: "http://micajota.es", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Index(Room room)
        {
            Room ro = new Room();

            return View(ro);

        }

        public ActionResult Create()
        {
            ViewBag.Title = "Create Room";
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {           

            if (!ModelState.IsValid)
            {               
                return View(room);
            }  

            return View(room);
        }


        public ActionResult Delete()
        {
            ViewBag.Title = "Delete Room";
            List<SelectListItem> listado = new List<SelectListItem>();
            SelectListItem itemr = new SelectListItem();

            itemr.Text = "";
            itemr.Value = "0";
            listado.Add(itemr);

            Rooms lrooms = DataBase.GetAllRooms();
            Room ro = new Room();

            foreach (Room item in lrooms.RoomList)
            {
                itemr = new SelectListItem();
                itemr.Text = item.Id + "-" + item.Occupant;
                itemr.Value = item.Id;
                listado.Add(itemr);
            }

            ro.InRoom = listado;

            return View(ro);
            
        }
        public ActionResult Update()
        {
            ViewBag.Title = "Update Room";

            List<SelectListItem> listado = new List<SelectListItem>();
            SelectListItem itemr = new SelectListItem();

            itemr.Text = "";
            itemr.Value = "0";
            listado.Add(itemr);


            Rooms lrooms = DataBase.GetAllRooms();
            Room ro = new Room();

            foreach (Room item in lrooms.RoomList)
            {
                itemr = new SelectListItem();
                itemr.Text = item.Id + "-" + item.Occupant;
                itemr.Value = item.Id;
                listado.Add(itemr);
            }

            ro.InRoom = listado;
            return View(ro);
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Room room)
        {
            List<SelectListItem> listado = new List<SelectListItem>();
            SelectListItem itemr = new SelectListItem();

            itemr.Text = "";
            itemr.Value = "0";
            listado.Add(itemr);


            Rooms lrooms = DataBase.GetAllRooms();
            Room ro = new Room();

            foreach (Room item in lrooms.RoomList)
            {
                itemr = new SelectListItem();
                itemr.Text = item.Id + "-" + item.Occupant;
                itemr.Value = item.Id;
                listado.Add(itemr);
            }

            ro.InRoom = listado; 
                       
            return View(ro);
        }

        public ActionResult List()
        {
            ViewBag.Title = "List Rooms";          

            WebRequest request = WebRequest.Create("http://micajota.es/api/values/");
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = request.GetResponse();
            
            string responseFromServer ="";
            using (Stream dataStream = response.GetResponseStream())
            {               
                StreamReader reader = new StreamReader(dataStream);               
                responseFromServer = reader.ReadToEnd();               
            }

            string a1 = responseFromServer.Substring(1);
            string b1 = a1.Substring(0, a1.Length - 1);

            Rooms data = new Rooms();            

            char[] dep = { ']' };

            string[] array = b1.Split(dep, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in array)
            {
                string[] items = item.Split('|');

                 
                    Room  room = new Room ();
                    room.Id = items[0].ToString();
                    room.Name = items[1].ToString();
                    room.Number = items[2].ToString();
                    room.Occupant = items[3].ToString();
                data.RoomList.Add(room);
                 
            }
            return View(data);
        }        
    }
}
