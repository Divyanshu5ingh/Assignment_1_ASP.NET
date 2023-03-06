using Assignment_1.Data;
using Assignment_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValueController : ControllerBase
    {
        private readonly KeyValueDbContext _keyValueDbContext;

        public KeyValueController(KeyValueDbContext keyValueDbContext)
        {
            _keyValueDbContext = keyValueDbContext;
        }

        // GET: api/<KeyValuesController>
        [HttpGet]
        public async Task<IActionResult> GetAllKeyValues()
        {
            var keyValues = await _keyValueDbContext.KeyValues.ToListAsync();
            return Ok(keyValues);
        }

        // GET api/<KeyValuesController>/5
        [HttpGet("{key}")]
        public async Task<IActionResult> GetById(string key)
        {
            var keyValue = await _keyValueDbContext.KeyValues.FirstOrDefaultAsync(x => x.Key == key);

            if (keyValue != null)
            {
                return Ok(keyValue);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<KeyValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KeyValue keyValue)
        {
            if (await _keyValueDbContext.KeyValues.AnyAsync(x => x.Key == keyValue.Key))
            {
                return Conflict();
            }
            else
            {
                await _keyValueDbContext.KeyValues.AddAsync(keyValue);
                await _keyValueDbContext.SaveChangesAsync();
                return Ok(keyValue);
            }
        }

        // PUT api/<KeyValuesController>/5
        //[HttpPut("{key}")]
        [HttpPut]
        public async Task<IActionResult> Put(string key, [FromBody] KeyValue keyValue)
        {           
            var KeyValue = await _keyValueDbContext.KeyValues.FirstOrDefaultAsync(x => x.Key == key);

            if (KeyValue != null)
            {
                KeyValue.Value = keyValue.Value;
                await _keyValueDbContext.SaveChangesAsync();
                return Ok(KeyValue);
            }
            else
            {
                return NotFound();
            }
        }

        // PATCH api/<KeyValuesController>/5
        [HttpPatch("{key}")]
        public async Task<IActionResult> Patch(string key, [FromBody] KeyValue keyValue)
        {
            var KeyValue = await _keyValueDbContext.KeyValues.FirstOrDefaultAsync(x => x.Key == key);

            if (KeyValue != null)
            {
                KeyValue.Value = keyValue.Value;
                await _keyValueDbContext.SaveChangesAsync();
                return Ok(KeyValue);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<KeyValuesController>/5
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var KeyValue = await _keyValueDbContext.KeyValues.FirstOrDefaultAsync(x => x.Key == key);

            if (KeyValue != null)
            {
                _keyValueDbContext.KeyValues.Remove(KeyValue);
                await _keyValueDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
