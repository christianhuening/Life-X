using LifeX.API;
using LifeX.API.Action;

namespace LifeX.Runtime
{
    public class Memory<TAction> : IMemory<TAction> where TAction : IAction
    {
        public Memory(int maxMemoryCapacity, MemoryStrategy memoryStrategy = MemoryStrategy.ALWAYS_REMEMBER)
        {
            
        }   
    }
}