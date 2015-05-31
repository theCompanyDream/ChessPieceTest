using System;
using ChessV2.Pieces;

namespace ChessV2
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private IChessPiece[,] pieces;

        public ChessBoard ()
        {
            pieces = new IChessPiece[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(IChessPiece ichesspiece, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            bool inRange = IsLegalBoardPosition(xCoordinate, yCoordinate);
            
            if(inRange)
            {
                ichesspiece.XCoordinate = xCoordinate;
                ichesspiece.YCoordinate = yCoordinate;

                ichesspiece.Move( xCoordinate, yCoordinate);
            }

        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            bool xval = CheckMinMaxPositions(xCoordinate);
            bool yval = CheckMinMaxPositions(yCoordinate);

            return xval && yval;
        }


        public static bool CheckMinMaxPositions(int position)
        {
            if (position > MaxBoardWidth || position < 0)
                return false;

            return true;
        }


    }
}
