using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VasarloConsole.Models
{
    public class VasarloDto
    {
        public VasarloDto(string name, string email, double balance)
        {
            Name = name;
            Email = email;
            Balance = balance;
        }

        public string Name { get; set; }
        public string Email { get; }
        public double Balance { get;}


    }
}
