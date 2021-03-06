﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Battle4Beers.Client.Models
{
    public class ShadowPriest : Priest, IPassiveActivator
    {
        public ShadowPriest(string name, int health, int healthRegen, List<Action> actions, int armor, int mana, int manaRegen, int spellPower) : base(name, health, healthRegen, actions, armor, mana, manaRegen, spellPower)
        {
            this.Sadist = false;
        }

        public int PassiveDuration { get; set; }

        public bool Sadist { get; set; }

        public void ActivatePassive(string nameOfPassive, Hero player)
        {
            ShadowPriest priest = (ShadowPriest)player;
            priest.Sadist = true;
            this.PassiveDuration = AbilityDurationConstants.SadismDuration;
            player.Actions.First(a => a.Name == nameOfPassive).SetCooldown(AbilityCooldownConstants.SadismCooldown);
        }

        public void DeactivatePassive(string nameOfPassive)
        {
            this.Sadist = false;
        }
    }
}
