using AdapterPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Classes
{
    public class Serum
    {
        private IMixture mixture;
        public Serum(IMixture mixture)
        {
            this.mixture = mixture;
        }

        public void SerumMixture()
        {
            this.mixture.GlowingSkin();
        }
    }
}
