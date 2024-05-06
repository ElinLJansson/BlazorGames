using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris.Tetrominos;

public class LeftZigZag : Tetromino
{
    public LeftZigZag(Grid grid) : base(grid) { }
    public override TetrominoStyle Style => TetrominoStyle.LeftZigZag;
    public override string CssClass => "tetris-red-cell";
    public override CellCollection CoverdCells
    {
        get
        {
            CellCollection cells = new CellCollection();
            cells.AddCell(CenterPieceRow, CenterPieceColumn);
            switch (Orientation)
            {
                case TetrominoOrientation.LeftRight:
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn - 1);
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                    break;
                case TetrominoOrientation.DownUp:
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn + 1);
                    break;
                case TetrominoOrientation.RightLeft:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn + 1);
                    break;
                case TetrominoOrientation.UpDown:
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn - 1);
                    break;
            }
            return cells;
        }
    }
}
