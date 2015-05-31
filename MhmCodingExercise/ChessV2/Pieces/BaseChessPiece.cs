using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessV2;

namespace ChessV2.Pieces
{
    public abstract class BaseChessPiece : IChessPiece
    {
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return _pieceColor; }
            private set { _pieceColor = value; }
        }

        protected BaseChessPiece(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public abstract MovementType Move( int newX, int newY);

    }
}
