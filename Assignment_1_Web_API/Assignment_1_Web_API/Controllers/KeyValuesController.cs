using Assignment_1_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment_1_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValuesController : ControllerBase
    {
        private static readonly Dictionary<string, string> _keyValueStore = new Dictionary<string, string>();        
        // GET: api/<KeyValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<KeyValues>> Get()
        {
            return Ok(_keyValueStore);
        }


        [HttpGet]
        [Route("{key}")]
        public ActionResult<IEnumerable<string>> Get(string key)
        {
            if (_keyValueStore.ContainsKey(key))
            {
                return Ok(_keyValueStore[key]);
            }
            else
            {
                return NotFound();
            }
        }
                
        // POST api/<KeyValuesController>
        [HttpPost]
        public ActionResult<KeyValues> Post([FromBody] KeyValues keyValue)
        {
            if (_keyValueStore.ContainsKey(keyValue.Key))
            {
                return Conflict();
            }
            else
            {
                _keyValueStore.Add(keyValue.Key, keyValue.Value);
                return Ok();
            }
        }

        // PUT api/<KeyValuesController>/5
        [HttpPut]
        public ActionResult<KeyValues> Put([FromBody] KeyValues keyValue)
        {
            if (_keyValueStore.ContainsKey(keyValue.Key))
            {                
                return Conflict();
            }
            else
            {
                _keyValueStore.Add(keyValue.Key, keyValue.Value);
                return Ok();
            }
        }

        [HttpPatch]
        [Route("{key}/{value}")]
        public IActionResult Patch(string key, string value)
        {
            if (_keyValueStore.ContainsKey(key))
            {
                _keyValueStore[key] = value;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<KeyValuesController>/5
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            if (_keyValueStore.ContainsKey(key))
            {
                _keyValueStore.Remove(key);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
