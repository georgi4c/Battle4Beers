﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System;
using System.Linq;

namespace Battle4Beers.Client.Models.Actions.PriestActions.HolyPriest
{
    public class Renew : Buff
    {
        private int heal;

        public Renew(string name, int coolDown, int cost, int duration, int heal) : base(name, coolDown, cost, duration)
        {
            this.Heal = heal;
            this.Type = "buff";
        }

        public int Heal
        {
            get { return this.heal; }
            protected set { this.heal = value; }
        }

        public override void BuffPlayer(Hero player)
        {
            player.GetHealed(this.Heal);
            player.buffs.Where(a => a.Name == this.Name && a.Duration == this.Duration).First().ReduceDuration(player);
        }

        public override void GivePlayerBuff(Buff buff, Hero player)
        {
            Buff renew = new Renew("RENEW", 0, 0, AbilityDurationConstants.RenewDuration, this.Heal);
            player.buffs.Add(renew);
            player.Actions.Where(a => a.Name == this.Name).First().SetCooldown(AbilityCooldownConstants.RenewCooldown);
        }

        public override string ToString()
        {
            return $"{this.Name}: Heal target ally for {this.Heal} for the next {this.Duration} turns. Cooldown: {this.CoolDown}, Cost: {this.Cost} Mana";
        }

    }
}
