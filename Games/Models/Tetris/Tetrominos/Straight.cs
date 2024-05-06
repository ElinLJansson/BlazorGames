using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris.Tetrominos;

public class Straight : Tetromino
{
    public Straight(Grid grid) : base(grid) { }
    public override TetrominoStyle Style => TetrominoStyle.Straight;
    public override string CssClass => "tetris-lightblue-cell";
    public override CellCollection CoverdCells
    {
        get
        {
            CellCollection cells = new CellCollection();
            cells.AddCell(CenterPieceRow, CenterPieceColumn);
            if (Orientation == TetrominoOrientation.LeftRight)
            {
                cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                cells.AddCell(CenterPieceRow, CenterPieceColumn - 2);
                cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
            }
            else if (Orientation == TetrominoOrientation.DownUp)
            {
                cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
                cells.AddCell(CenterPieceRow + 2, CenterPieceColumn);
            }
            else if (Orientation == TetrominoOrientation.RightLeft)
            {
                cells.AddCell(CenterPieceRow, CenterPieceColumn - 1);
                cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
                cells.AddCell(CenterPieceRow, CenterPieceColumn + 2);
            }
            else
            {
                cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
                cells.AddCell(CenterPieceRow - 2, CenterPieceColumn);
                cells.AddCell(CenterPieceRow + 1, CenterPieceColumn);
            }
            return cells;
        }
    }

}
