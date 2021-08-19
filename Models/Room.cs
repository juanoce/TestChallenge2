using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Challenge.Models
{
    public class Room
    {
        public string Id { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Name is not valid.")]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Number is not valid.")]
        public string Number { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Occupant is not valid.")]
        public string Occupant { get; set; }
        public IEnumerable<SelectListItem> InRoom { get; set; }

        public Room()
        {
            Id = "";
            Name = "";
            Number = "";
            Occupant = "";

        }
    }

    public class Rooms
    {
        public List<Room> RoomList { get; set; }

        public Rooms()
        {
            RoomList = new List<Room>();
        }
    }

    public class Room2
    {
        public string Id { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Name is not valid.")]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Number is not valid.")]
        public string Number { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessage = "Occupant is not valid.")]
        public string Occupant { get; set; }
        public Room2()
        {


        }
    }

    public class ListRoom2
    {
        public List<Room2> room2list { get; set; }
        public ListRoom2()
        {
            room2list = new List<Room2>();

        }
    }


}