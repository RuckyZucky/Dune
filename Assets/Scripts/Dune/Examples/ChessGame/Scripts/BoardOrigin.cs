#nullable enable
using Dune.Framework;

namespace Dune.Examples.ChessGame.Scripts
{
    public class BoardOrigin : DuneOrigin<Board>
    {
        protected override Board GetInstance()
        {
            return new Board();
        }
    }
}