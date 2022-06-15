using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {





           public  static List<VenuesDetails> GetVenus()
           {
               List<VenuesDetails> venus = new List<VenuesDetails>();
               VenuesDetails venuesDetails1 = new VenuesDetails();
               venuesDetails1.VenueTitle = "VenueOne";
               venuesDetails1.Address = "Bagal me";
               venus.Add(venuesDetails1);


               VenuesDetails venuesDetails2 = new VenuesDetails();
               venuesDetails2.VenueTitle = "VenueOne";
               venuesDetails2.Address = "Bagal me";
               venus.Add(venuesDetails2);
             
             
             
             
               VenuesDetails venuesDetails3 = new VenuesDetails();
               venuesDetails3.VenueTitle = "VenueOne";
               venuesDetails3.Address = "Bagal me";
               venus.Add(venuesDetails3);
             
             
             
               VenuesDetails venuesDetails4 = new VenuesDetails();
               venuesDetails1.VenueTitle = "VenueOne";
               venuesDetails1.Address = "Bagal me";
               venus.Add(venuesDetails3);





















            // var client = new HttpClient();
            // var request = new HttpRequestMessage
            // {
            //     Method = HttpMethod.Get,
            //     RequestUri = new Uri("https://api.foursquare.com/v3/places/nearby"),
            //     Headers =
            // {
            //     { "Accept", "application/json" },
            //     { "Authorization", "fsq3u/3bKQKPFsNZjEHmg5kgcixAKZd2ixGbkYTwjn3Efxk=" },
            //   },
            // };

            // var url= Venue.GenerateURL();



            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var body = await response.Content.ReadAsStringAsync();
            //    //Console.WriteLine(body);
            //}





            //   using (HttpClient client = new HttpClient())
            //   {
            //       var response = await client.GetAsync(url);
            //       var json = await response.Content.ReadAsStringAsync(); 
            //   } 

            //  var client = new HttpClient();
            //  var request = new HttpRequestMessage
            //  {
            //      Method = HttpMethod.Get,
            //      RequestUri = new Uri("https://dog.ceo/api/breeds/image/random"),
            //      Headers =
            //      {
            //          { "content-type", "application/json" },
            //          { "accept", "application/json" },
            //      },
            //  };
            //  using (var response = await client.SendAsync(request))
            //  {
            //      response.EnsureSuccessStatusCode();
            //      var body = await response.Content.ReadAsStringAsync();
            //      Console.WriteLine(body);
            //  }



            return venus; 

        }
    }
}
