﻿namespace Battle4Beers.Client.Models.Actions.PriestActions.DisciplinePriest
{
    public class Shield : Buff
    {
        private double shieldRatio;

        public Shield(string name, int coolDown, int cost, int duration, double shieldRatio) : base(name, coolDown, cost, duration)
        {
            this.ShieldRatio = shieldRatio;
        }

        public double ShieldRatio
        {
            get { return this.shieldRatio; }
            protected set { this.shieldRatio = value; }
        }

        public override string ToString()
        {
            return $"{this.Name}: Buff target ally to receive only {this.ShieldRatio}% damage for the next {this.Duration} turns Cooldown: {this.CoolDown}, Cost: {this.Cost} Mana";
        }
    }
}
