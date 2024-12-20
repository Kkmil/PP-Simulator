﻿using System;
using System.Diagnostics.Metrics;

namespace Simulator;
public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;
    public int Rage
    {
        get => _rage;
        init
        {
            _rage = Validator.Limiter(value, 0, 10);
        }
    }
    public void Hunt()
    {
        _huntCount++;
        Console.WriteLine($"{Name}is hunting.");
        if (_huntCount % 2 == 0)
        {
            if (_rage < 10) _rage++;
        }
    }

    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
    }
    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }
    public override string Info
    {
        get
        {
            return $"{Name}[{Level}][{Rage}]";
        }
    }
}