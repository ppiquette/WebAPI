using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WebApi.Models
{
    public class FeedRepository : IFeedRepository
    {
        private static ConcurrentDictionary<string, FeedItem> _feeds =
              new ConcurrentDictionary<string, FeedItem>();

        public FeedRepository()
        {
            Add(new FeedItem { Name = "Temperature", Id = "615913" });
            Add(new FeedItem { Name = "Humidity", Id = "616438" });
        }

        public IEnumerable<FeedItem> GetAll()
        {
            return _feeds.Values;
        }

        public void Add(FeedItem item)
        {
            //item.Id = Guid.NewGuid().ToString();
            _feeds[item.Id] = item;
        }

        public FeedItem Find(string id)
        {
            FeedItem item;
            _feeds.TryGetValue(id, out item);
            return item;
        }

        public FeedItem Remove(string id)
        {
            FeedItem item;
            _feeds.TryRemove(id, out item);
            return item;
        }

        public void Update(FeedItem item)
        {
            _feeds[item.Id] = item;
        }
    }
}