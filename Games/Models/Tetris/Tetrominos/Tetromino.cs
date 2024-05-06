using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris.Tetrominos;

public class Tetromino
{
    public Grid Grid { get; set; }
    public virtual CellCollection CoverdCells { get; set; }
    public TetrominoOrientation Orientation { get; set; } = TetrominoOrientation.LeftRight;
    public virtual TetrominoStyle Style { get; set; }
    public int CenterPieceRow { get; set; }
    public int CenterPieceColumn { get; set; }
    public virtual string CssClass { get; set; }
    public Tetromino(Grid grid)
    {
        Grid = grid;
        CenterPieceRow = grid.Height;
        CenterPieceColumn = grid.Width / 2;
    }
    public Tetromino()
    {

    }
    public void MoveLeft()
    {
        if (CanMoveLeft())
            CenterPieceColumn--;
    }
    public void MoveRight()
    {
        if (CanMoveRight())
            CenterPieceColumn++;
    }
    public int Drop()
    {
        int scoreCounter = 0;
        while (CanMoveDown())
        {
            Movedown();
            scoreCounter++;
        }
        return scoreCounter;
    }
    public bool CanMoveLeft()
    {
        foreach (var cell in CoverdCells.GetLeftMost())
        {
            if (Grid.Cells.Contains(cell.Row, cell.Column - 1))
                return false;
        }

        if (CoverdCells.HasColumn(1))
            return false;

        return true;
    }
    public bool CanMoveRight()
    {
        foreach (var cell in CoverdCells.GetRightMost())
        {
            if (Grid.Cells.Contains(cell.Row, cell.Column + 1))
                return false;
        }

        if (CoverdCells.HasColumn(Grid.Width))
            return false;

        return true;
    }
    public void Movedown()
    {
        if (CanMoveDown())
            CenterPieceRow--;
    }
    public bool CanMoveDown()
    {
        foreach (var coord in CoverdCells.GetLowest())
        {
            if (Grid.Cells.Contains(coord.Row - 1, coord.Column))
                return false;
        }

        if (CoverdCells.HasRow(1))
            return false;

        return true;
    }
    public void Rotate()
    {
        switch (Orientation)
        {
            case TetrominoOrientation.UpDown:
                Orientation = TetrominoOrientation.RightLeft;
                break;
            case TetrominoOrientation.RightLeft:
                Orientation = TetrominoOrientation.DownUp;
                break;
            case TetrominoOrientation.DownUp:
                Orientation = TetrominoOrientation.LeftRight;
                break;
            case TetrominoOrientation.LeftRight:
                Orientation = TetrominoOrientation.UpDown;
                break;
        }
        var coveredSpaces = CoverdCells;

        if (coveredSpaces.HasColumn(-1))
        {
            CenterPieceColumn += 2;
        }
        else if (coveredSpaces.HasRow(12))
        {
            CenterPieceRow -= 2;
        }
        else if (coveredSpaces.HasColumn(0))
        {
            CenterPieceColumn++;
        }
        else if (coveredSpaces.HasRow(11))
        {
            CenterPieceRow--;
        }
    }
}

