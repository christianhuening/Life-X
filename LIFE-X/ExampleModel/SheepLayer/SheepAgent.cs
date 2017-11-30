// // /*******************************************************
// //  * Copyright (C) Christian Hüning - All Rights Reserved
// //  * Unauthorized copying of this file, via any medium is strictly prohibited
// //  * Proprietary and confidential
// //  * This file is part of the MARS LIFE project, which is part of the MARS System
// //  * More information under: http://www.mars-group.org
// //  * Written by Christian Hüning <christianhuening@gmail.com>, 30.11.2017
// //  *******************************************************/

using System.Threading.Tasks;

namespace SheepLayer
{
    
    public interface ISheep : IAgent
    {
        Task<bool> TryKill();
    }
    
    public class SheepState
    {
        public IGrass Grass;
    }

    public class SheepAgent : AgentBase<SheepState>, ISheep {
        public async Task Initialize()
        {
            SubscribeLayer<IGrass>().Memory(AgentState.Grass);

            await WriteStateAsync();
        }

        public Task Tick()
        {
            AgentState.Grass.EatBiomass(0.123);
            return Task.CompletedTask;
        }
        
        public Task<bool> TryKill()
        {
            return Task.FromResult(true);
        }
    }
}