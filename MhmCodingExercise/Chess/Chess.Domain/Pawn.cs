using System;

namespace Chess.Domain
{
    public class Pawn : IChessPiece
    {
        /*
         * private ChessBoard _chessBoard;
         * The reason the chessboard is gone is becuase there is no reason for a single piece to know what the chessboard is 
         * it should only worry about its rules, position, and color. 
         */
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

        public Pawn(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        public MovementType Move(MovementType movementType, int newX, int newY)
        {
            //Movement type is sort of unnessacry because the user could enter the wrong type so I've determined to figure it out on my own
            MovementType determineMovementType = isLegalMove(newX, newY);

            if (determineMovementType != MovementType.Illegal && determineMovementType == movementType)
            {
                XCoordinate = newX;
                YCoordinate = newY;
            }

            return determineMovementType;
        }

        public MovementType Move(IChessPiece chesspiece)
        {
            //Movement type is sort of unnessacry because the user could enter the wrong type so I've determined to figure it out on my own
            return Move(MovementType.Move, chesspiece.XCoordinate, chesspiece.YCoordinate);
        }

        private MovementType isLegalMove(int newX, int newY)
        {
            int movement = (PieceColor == PieceColor.Black) ? -1 : 1;

            if (newY == YCoordinate + movement && XCoordinate == newX)
                return MovementType.Move;
            else if (newY == YCoordinate + movement && (XCoordinate + 1 == newX || XCoordinate - 1 == newX))
                return MovementType.Capture;

            return MovementType.Illegal;
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

        public bool PlacePeice(int x, int y)
        {
            switch(_pieceColor)
            {
                case PieceColor.Black:
                    return y >= 1;
                    break;
                case PieceColor.White:
                    return y <= 6;
                    break;

            }

            return false;
        }

        public bool Equals(IChessPiece obj)
        {
            return obj.PieceColor == _pieceColor && obj.XCoordinate == XCoordinate && obj.YCoordinate == YCoordinate;
        }
    }
}
