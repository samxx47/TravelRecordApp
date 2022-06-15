using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class Venue
    {
        public static string GenerateURL()
        {
            // var request = new HttpRequestMessage
            // {
            //     Method = HttpMethod.Get,
            //     RequestUri = new Uri("https://api.foursquare.com/v3/places/nearby"),
            //     Headers =
            //          {
            //               { "Accept", "application/json" },
            //               { "Authorization", "fsq3u/3bKQKPFsNZjEHmg5kgcixAKZd2ixGbkYTwjn3Efxk=" },
            //          },
            // };
            
            return string.Format(Constants.VENUE_SEARCH, 24.592192490655073, 80.8584444943988, Constants.CLIENT_ID, Constants.CLIENT_SECRET,DateTime.Now.ToString("yyyyMMdd"));
            //return request.Content.ReadAsStringAsync().Result;  
        }
    }
}
