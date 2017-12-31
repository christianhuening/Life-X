using LifeX.API.Action;
using LifeX.API.Agent;
using LifeX.API.Environment;

public class OutOfSightAction : IForgettableAction
{
  public IVector Position { get; set; }
  public IAgent Source { get; set; }
  public byte[] GetMemoryKey()
  {
    throw new System.NotImplementedException();
  }
}