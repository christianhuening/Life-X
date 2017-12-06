namespace LifeX.API
{
    public enum ActionState
    {
        Success,
        RuleProhibited,
        Failed
    }
    

    public interface IForgettableAction
    {
        byte[] GetMemoryKey();
    }
    
    public abstract class Action : IForgettableAction
    {
        public IVec Position;
        public IAgent Source;

        public byte[] GetMemoryKey()
        { // TODO: check if this works for derived classes properly
            return Source.GetType().GUID.ToByteArray();
        }
    }
}