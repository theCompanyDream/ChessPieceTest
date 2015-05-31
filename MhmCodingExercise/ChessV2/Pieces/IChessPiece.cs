using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessV2.Pieces
{
    public interface IChessPiece
    {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }

        PieceColor PieceColor { get; }

        MovementType Move(int newX, int newY);
    }
}
