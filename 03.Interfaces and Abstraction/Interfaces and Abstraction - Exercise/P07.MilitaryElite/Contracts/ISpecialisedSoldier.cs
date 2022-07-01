using System;
using System.Collections.Generic;
using MilitaryElite.Enums;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
         Corps Corps { get; }
    }
}
