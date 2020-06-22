using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IJWTConfigurator
    {
        string TokenString(string rol, string userName);
    }
}
