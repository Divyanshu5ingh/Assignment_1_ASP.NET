using System.ComponentModel.DataAnnotations;

namespace Assignment_1_Web_API.Models
{
    public class KeyValues
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
