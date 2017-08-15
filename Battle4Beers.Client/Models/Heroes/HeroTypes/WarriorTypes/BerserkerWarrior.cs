﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Battle4Beers.Client.Models
{
    public class BerserkerWarrior : Warrior, IPassiveActivator
    {
        public BerserkerWarrior(string name, int health, int healthRegen, List<Action> actions, int armor, int rage, int attackPower) : base(name, health, healthRegen, actions, armor, rage, attackPower)
        {
            this.IsBerserk = false;
        }

        public bool IsBerserk { get; set; }

        public int PassiveDuration { get; set; }

        public void ActivatePassive(string nameOfPassive, Hero player)
        {
            BerserkerWarrior warr = (BerserkerWarrior)player;
            warr.IsBerserk = true;
            warr.TakeDamage(AbilityConstants.BerserkModeCost);
            this.PassiveDuration = AbilityDurationConstants.BerserkDuration;
            player.Actions.First(a => a.Name == nameOfPassive).SetCooldown(AbilityCooldownConstants.GoBerserkCooldown);
        }

        public void DeactivatePassive(string nameOfPassive)
        {
            this.IsBerserk = false;
        }
    }
}
