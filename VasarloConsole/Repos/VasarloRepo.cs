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

        public List<Vasarlo> GetVasarloWithHighestBalance()
        {
            List<Vasarlo> vasarlos = new List<Vasarlo>();

            double max = _vasarlok.Max(v => v.Balance);

            foreach (Vasarlo v in _vasarlok)
            {
                if (v.Balance == max)
                {
                    vasarlos.Add(v);
                }
            }

            return vasarlos;
        }

        public List<Vasarlo> GetVasarloWithLowestBalance()
        {
            List<Vasarlo> vasarlos = new List<Vasarlo>();

            double min = _vasarlok.Min(v => v.Balance);

            foreach (Vasarlo v in _vasarlok)
            {
                if (v.Balance == min)
                {
                    vasarlos.Add(v);
                }
            }

            return vasarlos;
        }

        public int GetAvgBalanceRounded()
        {
            List<Vasarlo> vasarlos = new List<Vasarlo>();

            foreach (Vasarlo v in _vasarlok)
            {
                if (v.Balance >= 0)
                {
                    vasarlos.Add(v);
                }
            }

            double avg = vasarlos.Average(v => v.Balance);

            return (int)Math.Round(avg / 1000)*1000;
        }

        public List<Vasarlo> GetVasarlokWithBalanceBetween(int min, int max)
        {
            return _vasarlok.Where(_vasarlok => _vasarlok.Balance >= min && _vasarlok.Balance <= max).ToList();
        }

        public double SumOfBalances()
        {
            return _vasarlok.Sum(v=>v.Balance);
        }

        public Vasarlo GetVasarloByEmail(string email)
        {
            Vasarlo vasarlo = _vasarlok.FirstOrDefault(v => v.Email == email);
            if (vasarlo != null)
            {
                return vasarlo;
            }
            else
            {
                throw new Exception("Ez az email nem létezik");
            }
        }

        public Dictionary<string,double> CategorizeVasarlok()
        {
            return _vasarlok
                .OrderBy(v=>v.Balance)
                .GroupBy(v => v.Balance <= 0 ? "0 Ft** (pl. nincs pénze)**" : 
                    v.Balance >=1 && v.Balance <= 10000 ? "1 - 10 000 Ft" :
                    v.Balance >= 10001 && v.Balance < 50000 ? "10 001 - 50 000 Ft" :
                    v.Balance >= 50001 ? "50 001 Ft felett": "Err")
                .ToDictionary(g => g.Key, h => h.Count() /(double)_vasarlok.Count());
        }

        public List<string> GetAllNames()
        {
            return _vasarlok.Select(v => v.Name).ToList();
        }

        public List<string> GetAllEmails()
        {
            return _vasarlok.Select(v => v.Email).ToList();
        }

        public List<VasarloDto> ToDtos()
        {
            List<VasarloDto> dtoList = new List<VasarloDto>();
            foreach (Vasarlo v in _vasarlok)
            {
                dtoList.Add(new VasarloDto(v.Name, v.Email, v.Balance));
            }
            return dtoList;
        }

        public List<string> GetListText()
        {
            List<string> text = new List<string>();
            foreach(Vasarlo v in _vasarlok)
            {
                text.Add($"Név: {v.Name}, Egyenleg: {v.Balance} Ft");
            }
            return text;
        }

    }
}
