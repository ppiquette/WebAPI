using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FeedsController : Controller
    {
        public FeedsController(IFeedRepository todoItems)
        {
            FeedItems = todoItems;
        }
        public IFeedRepository FeedItems { get; set; }


        [HttpGet]
        public IEnumerable<FeedItem> GetAll()
        {
            return FeedItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetFeeds")]
        public IActionResult GetById(string id)
        {
            var item = FeedItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /*
        [HttpPost]
        public IActionResult Create([FromBody] FeedItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            FeedItems.Add(item);
            return CreatedAtRoute("GetFeeds", new { id = item.Id }, item);
        }
        */

    }
}