// // /*******************************************************
// //  * Copyright (C) Christian Hüning - All Rights Reserved
// //  * Unauthorized copying of this file, via any medium is strictly prohibited
// //  * Proprietary and confidential
// //  * This file is part of the MARS LIFE project, which is part of the MARS System
// //  * More information under: http://www.mars-group.org
// //  * Written by Christian Hüning <christianhuening@gmail.com>, 30.11.2017
// //  *******************************************************/

using System.Collections.Generic;
using System.Threading.Tasks;

namespace WolfLayer
{
    public interface IWolf : IAgent
    {
        
    }
    
    public enum WolfPlan
    {
        WalkAround,
        AttackSheep,
    }
    
    public class WolfState
    {
        public double Hunger;
        public WolfPlan Plan;
        public ISheep Target;
        // public IWolf Leader;
        public IEnumerable<PositionAction> Sheeps; // can get sheep instances from Action.GetSource<ISheep>()
        public double CurrentHeight;
        public double ReproductionProbability;
        public double GainFromFood;
    }
    
    public class WolfAgent : AgentBase<WolfState>, IWolf {
        
        public async Task Initialize()
        {
            AgentState.Plan = WolfPlan.WalkAround;
            
            SubscribeAction<PositionAction>()
                .From<ISheep>()
                .Near(Parameters.Optional<double>("WOLF_VIEW_RADIUS", 5.0d))
                .Memory(AgentState.Sheeps, 3)
                .MemoryFilter((action) => true /* some check if nearby */)
                .ForgetIf<OutOfSightAction>() // not necessary? just check if out of range if moved? but what if other agent moves out of range?
                .ForEach((action) => { // instead of lambda member function is also possible
                    if (AgentState.Hunger > 100)
                    {
                        AgentState.Plan = WolfPlan.AttackSheep;
                    }
                });
                
            await WriteStateAsync();
        }

        public async Task Tick()
        {
            // do something
            if (AgentState.Target != null)
            {
                if (await AgentState.Target.TryKill())
                {
                    AgentState.Hunger -= 100;
                }
            }

            // TryAction(PositionAction())
        }
    }
}