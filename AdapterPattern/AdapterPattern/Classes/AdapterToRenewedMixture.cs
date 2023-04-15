using AdapterPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Classes
{
    public class AdapterToRenewedMixture : IMixture
    {
        private IRenewedMixture mixture;
        public AdapterToRenewedMixture(IRenewedMixture mixture)
        {
            this.mixture = mixture;
        }
        public void GlowingSkin()
        {
            mixture.GlowingSkinNewMixture();
        }
    }
}
