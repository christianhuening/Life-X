// // /*******************************************************
// //  * Copyright (C) Christian Hüning - All Rights Reserved
// //  * Unauthorized copying of this file, via any medium is strictly prohibited
// //  * Proprietary and confidential
// //  * This file is part of the MARS LIFE project, which is part of the MARS System
// //  * More information under: http://www.mars-group.org
// //  * Written by Christian Hüning <christianhuening@gmail.com>, 30.11.2017
// //  *******************************************************/

using System.Threading.Tasks;

namespace GrassWolfSheep
{
    public interface IGrass : ILayerValue<double>
    {
        Task<double> EatBiomass(double amount);
    }
    
    public class GrassLayer : LayerValue<double>, IGrass
    {
        public async Task<double> EatBiomass(double amount)
        {
            LayerState -= amount; // simple, without checking if enough biomass
            await WriteStateAsync();
            return amount;
        }

        public Task Tick()
        {
            return Task.CompletedTask;
        }
    }
}