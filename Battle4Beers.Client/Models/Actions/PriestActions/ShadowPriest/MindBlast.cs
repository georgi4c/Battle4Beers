﻿using Battle4Beers.Client.Interfaces;
using Battle4Beers.Client.Utilities.Constants;
using System.Linq;

namespace Battle4Beers.Client.Models.Actions
{
    public class MindBlast : Action, IAgressiveAction
    {
        private int damage;

        public MindBlast(string name, int coolDown, int cost, int damage) : base(name, coolDown, cost)
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
            ShadowPriest playerOnTurn = (ShadowPriest)player;
            player.Actions.Where(a => a.Name == this.Name).First().SetCooldown(AbilityCooldownConstants.MindBlastCooldown);
            if (playerOnTurn.Sadist)
            {
                enemy.TakeDamage((int)(this.Damage * 1.5));
                player.GetHealed((int)(this.Damage * 0.1));
            }
            else
            {
                enemy.TakeDamage(this.Damage);
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: Damage the selected opponent for {this.Damage} damage. Cooldown: {this.CoolDown}, Cost: {this.Cost} Mana";
        }
    }
}
