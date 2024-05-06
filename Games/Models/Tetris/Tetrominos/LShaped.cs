using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris.Tetrominos;

public class LShaped : Tetromino
{
    public LShaped(Grid grid) : base(grid) { }
    public override TetrominoStyle Style => TetrominoStyle.LShaped;
    public override string CssClass => "tetris-orange-cell";
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
                    cells.AddCell(CenterPieceRow, CenterPieceColumn - 2);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                    break;
                case TetrominoOrientation.DownUp:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                    cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow + 2, CenterPieceColumn);
                    break;
                case TetrominoOrientation.RightLeft:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                    cells.AddCell(CenterPieceRow, CenterPieceColumn + 2);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                    break;
                case TetrominoOrientation.UpDown:
                    cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                    cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                    cells.AddCell(CenterPieceRow - 2, CenterPieceColumn);
                    break;
            }
            return cells;
        }
    }
}
