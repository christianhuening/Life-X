
namespace LifeX.API.Action
{
    public interface IForgettableAction : IAction
    {
        byte[] GetMemoryKey();
    }
}
    