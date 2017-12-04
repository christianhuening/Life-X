using System;
using System.Collections.Generic;

namespace LifeX.API
{
    public class ActionSubscription<TAction> where TAction : Action
    {
        // Can subscribe to specific type of agent
        public ActionSubscription<TAction> From<TAgent>() where TAgent : IAgent
        {
            return this;
        }

        // Can subscribe to specifc instance of an agent, e.g. Wolf wants to know where pack-leader is going:
        // SubscribeAction<PositionAction>()
        //    .From(AgentState.Leader)
        //    .ForEach((action) => { /* do something */ });
        public ActionSubscription<TAction> From<TAgent>(TAgent instance) where TAgent : IAgent
        {
            return this;
        }
        
        public ActionSubscription<TAction> Near(double radius)
        {
            return this;
        }
        
        public ActionSubscription<TAction> ForEach(System.Action<TAction> fn)
        {
            return this;
        }

        public ActionSubscription<TAction> Memory(IEnumerable<TAction> memory, int count, Func<TAction, TAction, bool> determineMemoryFn = null)
        {
            return this;
        }
        
        public ActionSubscription<TAction> Memory(TAction memory)
        {
            return this;
        }
        
        // TODO: is there a better generic way?
        // Working with memory it is often desirable to forget about something on another Action,
        // e.g. only track sheeps that are in sight, `ForgetIf` is a shorthand for:
        // SubscribeAction<OutOfSightAction>()
        //     .From<ISheep>()
        //     .ForgetMemory(AgentState.Sheeps);
        // public ActionSubscription<TAction> ForgetIf<TOtherAction>(Func<TOtherAction, bool> fn = null) where TOtherAction : AssociationAction
        // {
        //     return this;
        // }
        // ^ this would be preferred, but the two actions need to have an distinguishable association!
        // => Therefore forgettable actions need to fulfill an interface IForgettableAction, which provides
        //    a GetMemoryKey-method associating memories by some unique key (hash).
        //    In the above example this would mean, PositionAction and OutOfSightAction have a unique key based on the 
        //    source-agent.
        public ActionSubscription<TAction> ForgetIfOutOfSight()
        {
            return this;
        }
    }
}