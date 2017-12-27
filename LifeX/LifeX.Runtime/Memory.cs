using LifeX.API;
using LifeX.API.Action;

namespace LifeX.Runtime
{
    public class Memory<TAction> : IMemory<TAction> where TAction : Action
    {
        public Memory(int maxMemoryCapacity)
        {
            
        }   
    }
}