using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FeedController : Controller
    {
        public FeedController(IFeedRepository todoItems)
        {
            FeedItems = todoItems;
        }
        public IFeedRepository FeedItems { get; set; }


        [HttpGet]
        public IEnumerable<FeedItem> GetAll()
        {
            return FeedItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = FeedItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FeedItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            FeedItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }
    }
}