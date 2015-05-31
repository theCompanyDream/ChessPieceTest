using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess.Domain
{
    public interface IChessPiece
    {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }

        PieceColor PieceColor { get; }

        MovementType Move(MovementType movementType, int newX, int newY);

        bool PlacePeice(int x, int y);
    }
}
