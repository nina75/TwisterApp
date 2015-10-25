namespace Twister.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface ITwisterData
    {
        IRepository<User> Users { get; }

        IRepository<Reply> Replies { get; }

        IRepository<Tweet> Tweets { get; }

        IRepository<TweetFavourite> TweetFavourites { get; }

        //IRepository<Message> Messages { get; }

        //IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}
