namespace Twister.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using Repositories;
    using Models;

    public class TwisterData : ITwisterData
    {
        private ITwisterContext context;
        private IDictionary<Type, object> repositories;

        public TwisterData(ITwisterContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public IRepository<Reply> Replies
        {
            get { return this.GetRepository<Reply>(); }
        }

        public IRepository<TweetFavourite> TweetFavourites
        {
            get
            {
                return this.GetRepository<TweetFavourite>();
            }
        }

        //public IRepository<Notification> Notifications
        //{
        //    get { return this.GetRepository<Notification>(); }
        //}

        //public IRepository<Message> Messages
        //{
        //    get { return this.GetRepository<Message>(); }
        //}

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
