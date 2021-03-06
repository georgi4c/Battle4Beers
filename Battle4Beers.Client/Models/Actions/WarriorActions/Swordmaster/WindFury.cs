﻿using Battle4Beers.Client.BattleGround;
using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System;
using System.Linq;

namespace Battle4Beers.Client.Models.Actions.WarriorActions.Swordmaster
{
    public class WindFury : Action, IAgressiveAction
    {
        private int damage;

        public WindFury(string name, int coolDown, int cost, int damage) : base(name, coolDown, cost)
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
            SwordmasterWarrior playerOnTurn = (SwordmasterWarrior)player;
            player.Actions.Where(a => a.Name == this.Name).First().SetCooldown(AbilityCooldownConstants.MirrorImageCooldown);
            if (playerOnTurn.CriticalStrike)
            {
                bool isCrit = CriticalChecker.CheckForCrit(player);
                if (isCrit)
                {
                    CriticalPrinter.PrintCritical(player);
                    enemy.TakeDamage(this.Damage);
                }
            }

            enemy.TakeDamage(this.Damage);
        }

        public override string ToString()
        {
            return $"{this.Name}: Damage the selected opponent for {this.Damage} damage. Cooldown: {this.CoolDown}, Cost: {this.Cost} Rage";
        }

    }
}
