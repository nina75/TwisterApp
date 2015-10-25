namespace Twister.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TweetFavourite
    {
        public int Id { get; set; }

        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
