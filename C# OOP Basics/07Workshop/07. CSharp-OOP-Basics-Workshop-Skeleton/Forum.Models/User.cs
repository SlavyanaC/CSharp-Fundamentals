namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User(int id, string username, string password, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Posts = new List<int>(posts);
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> Posts { get; set; }
    }
}
