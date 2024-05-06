namespace Games.Models.Tetris;

public class Cell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public string CssClass { get; set; }

    public Cell(int row, int column)
        => (Row, Column) = (row, column);

    public Cell(int row, int column, string css)
        => (Row, Column, CssClass) = (row, column, css);
}
