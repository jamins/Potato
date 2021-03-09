using PotatoApi.Models;
using PotatoApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotatoController : ControllerBase
    {
        private readonly PotatoServices _potatoService;

        public PotatoController(PotatoServices potatoService)
        {
            _potatoService = potatoService;
        }

        [HttpGet]
        public ActionResult<List<PotatoQ>> Get() =>
            _potatoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPotato")]
        public ActionResult<PotatoQ> Get(string id)
        {
            var potato = _potatoService.Get(id);

            if (potato == null)
            {
                return NotFound();
            }

            return potato;
        }

        [HttpPost]
        public ActionResult<PotatoQ> Create(PotatoQ potato)
        {
            _potatoService.Create(potato);

            return CreatedAtRoute("GetPotato", new { id = potato.Id.ToString() }, potato);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PotatoQ potatoIn)
        {
            var potato = _potatoService.Get(id);

            if (potato == null)
            {
                return NotFound();
            }

            _potatoService.Update(id, potatoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _potatoService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _potatoService.Remove(book.Id);

            return NoContent();
        }
    }
}