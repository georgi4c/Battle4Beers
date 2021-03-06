﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System.Linq;

namespace Battle4Beers.Client.Models.Actions
{
    public class Silence : Action, IAgressiveAction
    {
        public Silence(string name, int coolDown, int cost) : base(name, coolDown, cost)
        {
            this.Type = "agressive";
        }

        public int Damage
        {
            get;
        }

        public void ExecuteAgressiveAction(Hero player, Hero enemy)
        {
            enemy.StunnedDuration += AbilityDurationConstants.SilenceDuration;

            DisciplinePriest priest = (DisciplinePriest)player;
            priest.PassiveDuration--;
            player.Actions.Where(a => a.Name == this.Name).First().SetCooldown(AbilityCooldownConstants.SilenceCooldown);
            if (priest.PassiveDuration <= 0)
            {
                priest.IsShielded = false;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: Disables the target from casting any spells or actions for {AbilityDurationConstants.SilenceDuration} turns Cooldown: {this.CoolDown}, Cost: {this.Cost} Mana";
        }
    }
}
