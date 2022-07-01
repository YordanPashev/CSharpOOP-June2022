using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState State)
        {
            CodeName = codeName;
            this.State = State;
        }

        public string CodeName { get; private set; }

        public MissionState State 
        {
            get;
            private set;
        }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
           => $"Code Name: {CodeName} State: {State}";
    }
}
