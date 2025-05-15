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

        public List<Vasarlo> GetVasarlokWithHigherBalanceThan(double bal)
        {
            return _vasarlok.Where(v=>v.Balance > bal).ToList();
        }

        public List<Vasarlo> GetVasarlokWithZeroBalance()
        {
            return _vasarlok.Where(v => v.Balance == 0).ToList();
        }

        public List<Vasarlo> GetVasarlokWhereNameIncludes(string s)
        {
            return _vasarlok.Where(v => v.Name.ToUpper().Contains(s.ToUpper())).ToList();
        }

        public List<Vasarlo> GetVasarlokWithHigherBalanceThanAndHasADomain(double bal, string domain)
        {
            return _vasarlok.Where(v => v.Balance > bal && v.Email.ToUpper().EndsWith(domain.ToUpper())).ToList();
        }

        public List<Vasarlo> GetVasarlokOrderedAlphabetically()
        {
            return _vasarlok.OrderBy(v => v.Name).ToList();
        }

        public List<Vasarlo> GetVasarlokOrderedByBalance()
        {
            return _vasarlok.OrderBy(v => v.Balance).ToList();
        }

        public List<Vasarlo> GetVasarlokOrderedAlphabeticallyAndByBalance()
        {
            return _vasarlok.OrderByDescending(v => v.Balance).OrderBy(v => v.Name).ToList();
        }

        public List<Vasarlo> GetVasarlokOrderedByEmailDomain()
        {
            return _vasarlok
                .OrderBy(v =>
                    v.Email.Contains("@") ? v.Email.Split('@')[1] : "")
                .ToList();
        }

        public List<string> GetUniqueDomains()
        {
            List<string> domains = new List<string>();
            foreach (Vasarlo v in _vasarlok)
            {
                if (v.Email.Contains("@"))
                {
                    string domain = v.Email.Split('@')[1];
                    if (!domains.Contains(domain))
                    {
                        domains.Add(domain);
                    }
                }
            }

            return domains;
        }

        public List<double> GetUniqueBalabnces()
        {
            List<double> balances = new List<double>();
            foreach (Vasarlo v in _vasarlok)
            {
                if (!balances.Contains(v.Balance))
                {
                    balances.Add(v.Balance);
                }
            }

            return balances;
        }

        public List<string> GetUniqueFirstLetters()
        {
            List<string> letters = new List<string>();
            foreach (Vasarlo v in _vasarlok)
            {
                string firstLetter = v.Name[0].ToString().ToUpper();
                if (!letters.Contains(firstLetter))
                {
                    letters.Add(firstLetter);
                }
            }

            return letters;
        }

        public List<Vasarlo> GetUniqueNameAndBalanceCombos()
        {
            return _vasarlok
                .GroupBy(v => new { v.Name, v.Balance })
                .Select(g => g.First())
                .ToList();
        }
    }
}
