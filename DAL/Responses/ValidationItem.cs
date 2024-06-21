using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Responses
{
    public class ValidationItem
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ValidationItem(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
