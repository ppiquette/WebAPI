using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WebApi.Models
{
    public class FeedRepository : IFeedRepository
    {
        private static ConcurrentDictionary<string, FeedItem> _todos =
              new ConcurrentDictionary<string, FeedItem>();

        public FeedRepository()
        {
            Add(new FeedItem { Name = "Item1" });
        }

        public IEnumerable<FeedItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(FeedItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public FeedItem Find(string key)
        {
            FeedItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public FeedItem Remove(string key)
        {
            FeedItem item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(FeedItem item)
        {
            _todos[item.Key] = item;
        }
    }
}