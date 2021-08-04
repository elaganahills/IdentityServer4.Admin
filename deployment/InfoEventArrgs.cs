using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hills.IdentityServer4.Deployment
{
    public class InfoEventArrgs : EventArgs
    {
        public bool Value { get; private set; }

        public InfoEventArrgs(bool value)
        {
            Value = value;
        }

    }
}
