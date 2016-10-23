using System.Collections.Generic;

namespace WebApi.Models
{
    public interface IFeedRepository
    {
        void Add(FeedItem item);
        IEnumerable<FeedItem> GetAll();
        FeedItem Find(string key);
        FeedItem Remove(string key);
        void Update(FeedItem item);
    }
}
