using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SporthalHuren.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Vul een zaalnummer in")]
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public int HallID { get; set; }
        [JsonIgnore]
        public virtual SportsHall Hall { get; set; }
    }
}
