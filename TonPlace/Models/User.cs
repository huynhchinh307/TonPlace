using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int sex { get; set; }
        public string bDate { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int photoId { get; set; }
        public string photo { get; set; }
        public string photoMedium { get; set; }
        public string photoLarge { get; set; }
        public string thumbnail { get; set; }
        public int followers { get; set; }
        public int followed { get; set; }
        public int lastUpdate { get; set; }
        public string status { get; set; }
        public int invites { get; set; }
        public int rating { get; set; }
        public bool isBanned { get; set; }
    }

    public class Tweet_Profile
    {
        public string username { get; set; }
        public string name { get; set; }
        public string profile_pic_url { get; set; }
        public string description { get; set; }
        public int number_of_tweets { get; set; }
    }

    public class RootProfile
    {
        public List<Tweet_Profile> results { get; set; }
    }
}
