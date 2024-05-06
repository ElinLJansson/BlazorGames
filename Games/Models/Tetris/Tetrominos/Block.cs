using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris.Tetrominos;

public class Block : Tetromino
{
    public Block(Grid grid) : base(grid) { }
    public override TetrominoStyle Style => TetrominoStyle.Block;
    public override string CssClass => "tetris-yellow-cell";
    public override CellCollection CoverdCells
    {
        get
        {
            CellCollection cells = new();
            cells.AddCell(CenterPieceRow, CenterPieceColumn);
            cells.AddCell(CenterPieceRow - 1, CenterPieceColumn);
            cells.AddCell(CenterPieceRow, CenterPieceColumn + 1);
            cells.AddCell(CenterPieceRow - 1, CenterPieceColumn + 1);
            return cells;
        }
    }
}
