using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VasarloConsole.Models;

namespace VasarloConsole.Repos
{
    public class VasarloRepo
    {
        private List<Vasarlo> _vasarlok = new List<Vasarlo>();

        public List<Vasarlo> Vasarlok { get => _vasarlok; }

        public void AddVasarlo(Vasarlo vasarlo)
        {
            foreach(Vasarlo v in _vasarlok)
            {
                if (v.Email == vasarlo.Email)
                {
                    throw new Exception("Ez az email már létezik");
                }
            }
            _vasarlok.Add(vasarlo);
        }

        public void RemoveVasarlo(string email)
        {
            List<string> emails = new List<string>();
            foreach (Vasarlo v in _vasarlok)
            {
                emails.Add(v.Email);
            }

            if(emails.Contains(email))
            {
                Vasarlo vasarlo = _vasarlok.FirstOrDefault(v => v.Email == email);
                if (vasarlo != null)
                {
                    _vasarlok.Remove(vasarlo);
                }
            }
            else
            {
                throw new Exception("Ez az email nem létezik");
            }
        }
    }
}
