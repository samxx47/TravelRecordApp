using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TravelRecordApp.Model
{
    public class VenuesDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string VenueTitle { get; set; }
        public string Address { get; set; }




    }
}
