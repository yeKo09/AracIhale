using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.VM
{
    public class LoginVM
    {

        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public bool BeniHatirla { get; set; }

    }
}
