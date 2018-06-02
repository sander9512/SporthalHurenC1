using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SporthalHuren.Models.Domain
{
    public class Booking
    {
        [BindNever]
        public int ID { get; set; }
        [JsonRequired]
        public string UserId { get; set; }
        [JsonRequired]
        public int HallID { get; set; }
        public virtual SportsHall Hall { get; set; }

        [Display(Name = "Datum")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Date { get; set; }
        [JsonRequired]
        public int? ActivityID { get; set; }
        public virtual Activity Activity { get; set; }
        [JsonRequired]
        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }
        [JsonRequired]
        public int Approved { get; set; }
        [Required]
        public int RemainingCapacity { get; set; }
        [Required]
        [Display(Name = "Starttijd")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Eindtijd")]
        public DateTime EndTime { get; set; }

    }
}
