using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ISoldier
    {
        string FirstName { get; }

        string LastName { get; }

        string Id { get; }
    }
}
