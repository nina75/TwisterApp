namespace Twister.Data
{
    using System.Data.Entity;
    using Models;

    public interface ITwisterContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<TweetFavourite> TweetFavorites { get; set; }

        IDbSet<Reply> Replies { get; set; }

        int SaveChanges();
    }
}
