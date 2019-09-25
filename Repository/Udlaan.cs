using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Udlaan : ClassNotify
    {
        public void udlaan()
        {
            
        }

        private DateTime _afleveringsDato;

        public DateTime afleveringsDato
        {
            get { return _afleveringsDato; }
            set
            {
                if (value != _afleveringsDato)
                {
                    _afleveringsDato = value;
                    Notify("afleveringsDato");
                }
            }
        }
        public void BeregnAfleveringsDato()
        {

        }
    }
}
