using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace.Models
{
    public class TonPost
    {
        public Info info { get; set; }
    }

    public class Info
    {
        public List<Post> posts { get; set; }
        public string postsNextFrom { get; set; }
        public int posts_count { get; set; }
        public bool is_follow_from_me { get; set; }
        public bool is_follow_to_me { get; set; }
        public int scheduledCount { get; set; }
        public int sponsoredPostsCount { get; set; }
        public int totalLikesCount { get; set; }
        public string subscriptionMessage { get; set; }
        public string nftAddress { get; set; }
        public int subscriptionPrice { get; set; }
        public int photoWidth { get; set; }
        public int photoHeight { get; set; }
        public int subscriptionEurPrice { get; set; }
        public object welcomeVideo { get; set; }
        public bool isMediaUser { get; set; }
    }

    public class Post
    {
        public int id { get; set; }
        public string text { get; set; }
        public int ownerId { get; set; }
        public int publisherId { get; set; }
        public int createdAt { get; set; }
        public int updatedAt { get; set; }
        public int parentId { get; set; }
        public int views { get; set; }
        public int likes { get; set; }
        public bool isLiked { get; set; }
        public int comments { get; set; }
        public int shares { get; set; }
        public bool canDelete { get; set; }
        public object replyTo { get; set; }
        public int level { get; set; }
        public int type { get; set; }
    }
}
