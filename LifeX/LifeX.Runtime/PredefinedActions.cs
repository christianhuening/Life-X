using LifeX.API;
using LifeX.API.Action;

namespace LifeX.Runtime
{
    public class MoveAction : Action
    {
        public MoveAction(IVector newPosition)
        {
            Position = newPosition;
        }
    }

    public class OutOfSightAction : Action
    {
    }
}