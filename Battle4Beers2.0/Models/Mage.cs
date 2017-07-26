﻿using System;

public class Mage : Hero, ICaster
{
    private int mana;

    public Mage(string name, int health) : base(name, health)
    {
    }

    public int Mana
    {
        get
        {
            return this.mana;
        }
        protected set
        {
            this.mana = value;
        }
    }
}