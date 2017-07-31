﻿using System;
using Battle4Beers.Client.Interfaces;

namespace Battle4Beers.Client.Models.Actions.FireMage
{
    public class FireArmor : Action, IBuff
    {
        private int damageOverTime;
        private int armor;
        private int duration;

        public FireArmor(string name, int coolDown, int cost, int damageOverTime, int armor, int duration) : base(name, coolDown, cost)
        {
            this.DamageOverTime = damageOverTime;
            this.Armor = armor;
            this.Duration = duration;
        }

        public int DamageOverTime
        {
            get { return this.damageOverTime; }
            protected set { this.damageOverTime = value; }
        }

        public int Armor
        {
            get { return this.armor; }
            protected set { this.armor = value; }
        }

        public int Duration
        {
            get { return this.duration; }
            protected set { this.duration = value; }
        }

       

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
