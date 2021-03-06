﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System.Linq;

namespace Battle4Beers.Client.Models.Actions.WarriorActions
{
    public class ShieldSlam : Action, IAgressiveAction
    {
        private int damage;

        public ShieldSlam(string name, int coolDown, int cost, int damage) : base(name, coolDown, cost)
        {
            this.Damage = damage;
            this.Type = "agressive";
        }

        public int Damage
        {
            get { return this.damage; }
            protected set { this.damage = value; }
        }

        public void ExecuteAgressiveAction(Hero player, Hero enemy)
        {
            enemy.StunnedDuration++;
            player.Actions.Where(a => a.Name == this.Name).First().SetCooldown(AbilityCooldownConstants.ShieldSlamCooldown);
            enemy.TakeDamage(player.Armor);
            ProtectionWarrior warr = (ProtectionWarrior)player;
            warr.PassiveDuration--;
            if(warr.PassiveDuration <= 0)
            {
                warr.Hibernating = false;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: Damage the selected opponent for damage equal to your current armor. Stun target for {AbilityDurationConstants.ShieldSlamDuration} turns. Cooldown: {this.CoolDown}, Cost: {this.Cost} Rage";
        }

    }
}
