﻿namespace Formula1.Models.Race
{
    using System;
    using System.Collections.Generic;

    using Formula1.Utilities;
    using Formula1.Models.Contracts;
   
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.TookPlace = false;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot) => this.pilots.Add(pilot);

        public string RaceInfo()
            => $"The { this.RaceName } race has:" + Environment.NewLine +
               $"Participants: { pilots.Count }" + Environment.NewLine +
               $"Number of laps: { this.NumberOfLaps }" + Environment.NewLine +
               $"Took place: { string.Format(this.TookPlace ? "Yes" : "No") }";
    }
}
