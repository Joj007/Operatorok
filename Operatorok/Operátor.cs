using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorok
{
    internal class Operátor
    {
        int eloTag;
        string muveletiJel;
        int utoTag;

        public Operátor(int eloTag, string jel, int utoTag)
        {
            this.eloTag = eloTag;
            this.muveletiJel = jel;
            this.utoTag = utoTag;
        }

        public static string Kiszamol(int eloTag, string muveletiJel, int utoTag)
        {
            string eredmeny = "";
            try
            {
                switch (muveletiJel)
                {
                    case "+":
                        eredmeny = $"{eloTag + utoTag}";
                        break;
                    case "-":
                        eredmeny = $"{eloTag - utoTag}";
                        break;
                    case "*":
                        eredmeny = $"{eloTag * utoTag}";
                        break;
                    case "/":
                        eredmeny = $"{eloTag / (double)utoTag}";
                        break;
                    case "div":
                        eredmeny = $"{eloTag / utoTag}";
                        break;
                    case "default":
                        eredmeny = "Hibás operátor!";
                        break;
                }
            }
            catch (Exception)
            {
                eredmeny = "Egyéb hiba!";
            }

            return eredmeny;
        }

        public int EloTag { get => eloTag;}
        public string MuveletiJel { get => muveletiJel;}
        public int UtoTag { get => utoTag;}
    }
}
