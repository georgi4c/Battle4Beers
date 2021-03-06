﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Battle4Beers.Client.Models
{
    public class ProtectionWarrior : Warrior, IPassiveActivator
    {
        public ProtectionWarrior(string name, int health, int healthRegen, List<Action> actions, int armor, int rage, int attackPower) : base(name, health, healthRegen, actions, armor, rage, attackPower)
        {
            this.Hibernating = false;
        }

        public bool Hibernating { get; set; }

        public int PassiveDuration { get; set; }

        public void ActivatePassive(string nameOfPassive, Hero player)
        {
            this.Hibernating = true;
            player.GetHealed(AbilityConstants.HibernationHeal);
            this.PassiveDuration = AbilityDurationConstants.HibernateDuration;
            player.Actions.First(a => a.Name == nameOfPassive).SetCooldown(AbilityCooldownConstants.HibernateCooldown);
        }

        public override void TakeDamage(int amount)
        {
            if(this.Hibernating && amount != 0)
            {
                amount /= 2;
            }

            if (this.Armor <= amount)
            {
                amount -= this.Armor;
                this.Health -= amount;
                this.Armor = 0;
            }
            else if (this.Armor > amount)
            {
                this.Armor -= amount;
            }
        }
    }
}
