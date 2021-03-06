﻿using System.Threading.Tasks;
using LifeX.Components.Layers;
using WolfSheep.Model.Interfaces;

namespace WolfSheep.Model.Implementation
{

    public class GrassState : LayerState
    {
        public double GrassHeight;
    }
    
    public class GrassLayer : LayerBase<GrassState>, IGrass
    {
        public async Task<double> EatBiomass(double amount)
        {
            State.GrassHeight -= amount; // simple, without checking if enough biomass
            await WriteStateAsync();
            return amount;
        }

        public Task Tick()
        {
            return Task.CompletedTask;
        }
    }
}