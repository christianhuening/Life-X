
  using LifeX.API.Agent;
  using LifeX.API.Environment;

namespace LifeX.API.Action
  {
      public interface IAction
      {
          IVector Position { get; set; }
          IAgent Source { get; set; }
      }
  }
