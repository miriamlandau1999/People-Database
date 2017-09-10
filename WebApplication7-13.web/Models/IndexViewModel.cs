using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication7_13.data;

namespace WebApplication7_13.web.Models
{
    public class IndexViewModel
    {
       public IEnumerable<Person> People { get; set; } 
    }
}