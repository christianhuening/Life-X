using LifeX.API;

namespace LifeX.Runtime
{
    public class MoveAction : Action
    {
        public MoveAction(IVec newPosition)
        {
            Position = newPosition;
        }
    }

    public class OutOfSightAction : Action
    {
    }
}