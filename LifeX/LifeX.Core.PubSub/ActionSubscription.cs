using System;
using System.Collections.Generic;

// TODO: Use type GUID to map types to actions et cetera?
//
// "The purpose of Type.GUID is to get the value associated with the class using [Guid("...")]. 
//  However, it also returns a guid when this attribute is not associated. The problem is where 
//  it gets this. A small test shows that the guid is stable. I checked the guid of a class, 
//  and verified that it changed when I renamed the class. When I renamed the class back, 
//  I got the original guid again. However, since these guids appear out of thin air, they 
//  shouldn't be trusted to be stable over time, releases, framework versions, etc."
// "By examining the SSCLI implementation, the GUID is generated from a combination of the 
//  full class name (including namespace), the full assembly name (including version 
//  or [assembly: ComCompatibleVersion] if present, public key token etc.), and a generic "namespace" 
//  signature for all CLR-generated GUIDs.
//  The generation itself is deterministic (it uses an MD5 hash as per the IETF draft document) so the 
//  GUID is stable across compilations and runs.
//  (This is true for the SSCLI implementation and not guaranteed to be true for the actual CLR, past, present or future.)

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
        
        // Working with memory it is often desirable to forget about something on another Action,
        // e.g. only track sheeps that are in sight, `ForgetIf` is a shorthand for:
        // SubscribeAction<OutOfSightAction>()
        //     .From<ISheep>()
        //     .ForgetMemory(AgentState.Sheeps);
        // public ActionSubscription<TAction> ForgetIf<TOtherAction>(Func<TOtherAction, bool> fn = null) where TOtherAction : AssociationAction
        // {
        //     return this;
        // }
        public ActionSubscription<TAction> ForgetIf<TForgetAction>() where TForgetAction : Action, IForgettableAction
        {
            return this;
        }
    }
}