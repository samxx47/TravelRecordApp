using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(1250)]
        public string Experience { get; set; }   
        public string UserName { get; set; }

        
    }
}
