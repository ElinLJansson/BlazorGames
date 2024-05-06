using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris.Tetrominos;

public class RightZigZag : Tetromino
{
    public RightZigZag(Grid grid) : base(grid) { }
    public override TetrominoStyle Style => TetrominoStyle.RightZigZag;
    public override string CssClass => "tetris-green-cell";
    public override CellCollection CoverdCells
    {
        get
        {
            CellCollection cells = new CellCollection();
            cells.AddCell(CenterPieceRow, CenterPieceColumn);
            switch (Orientation)
            {
                case TetrominoOrientation.LeftRight:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn + 1);
                    break;
                case TetrominoOrientation.DownUp:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn + 1);
                    break;
                case TetrominoOrientation.RightLeft:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn - 1);
                    break;
                case TetrominoOrientation.UpDown:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn - 1);
                    break;
            }
            return cells;
        }
    }
}
