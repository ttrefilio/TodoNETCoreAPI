using Microsoft.AspNetCore.Mvc;
using Project.API.ViewModels;
using Project.Domain.Models;
using Project.Domain.Interfaces.Repositories;
using System;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository itemRepository;

        public ItemsController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        [HttpPost]
        public IActionResult Post(CreateItemViewModel itemViewModel)
        {
            var item = new Item
            {
                Title = itemViewModel.Title,
                Description = itemViewModel.Description
            };

            try
            {
                itemRepository.Add(item);
                return Ok(new { Message = "Item successfully created." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateItemViewModel itemViewModel)
        {
            var item = new Item
            {
                Id = int.Parse(itemViewModel.Id),
                Title = itemViewModel.Title,
                Description = itemViewModel.Description,
                IsDone = itemViewModel.IsDone
            };

            try
            {
                itemRepository.Update(item);
                return Ok(new { Message = "Item successfully updated." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("ChangeState")]
        public IActionResult ChangeState(ChangeStateViewModel itemViewModel)
        {
            var item = itemRepository.GetById(int.Parse(itemViewModel.Id));
            item.IsDone = itemViewModel.IsDone;

            try
            {
                itemRepository.Update(item);
                return Ok(new { Message = "Item state successfully changed." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var item = new Item { Id = int.Parse(id) };
                itemRepository.Remove(item);

                return Ok(new { Message = "Item removed." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(itemRepository.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("Done")]
        public IActionResult GetDone()
        {
            try
            {
                return Ok(itemRepository.GetDone());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("Pending")]
        public IActionResult GetPending()
        {
            try
            {
                return Ok(itemRepository.GetPending());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return Ok(itemRepository.GetById(int.Parse(id)));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
