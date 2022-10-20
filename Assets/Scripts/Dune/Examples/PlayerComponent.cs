using Dune.Framework;

namespace Dune.Examples
{
    public class PlayerComponent : DuneOrigin<Player>
    {
        protected override Player GetInstance()
        {
            return new Player();
        }
    }
}