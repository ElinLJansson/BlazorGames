namespace Games.Models.Tetris;

public class CellCollection
{
    private readonly List<Cell> _cells = new();

    public void AddCell(int row, int column) => _cells.Add(new Cell(row, column));
    public void AddMany(List<Cell> cells, string cssClass) => cells.ForEach(cell => _cells.Add(new Cell(cell.Row, cell.Column, cssClass)));
    /*foreach (var cell in cells)
    {
        _cells.Add(new Cell(cell.Row, cell.Column, cssClass));
    }*/

    /// <summary>
    /// Returns all currently-occupied coordinates.
    /// </summary>
    /// <returns></returns>
    public List<Cell> GetAllCells() => _cells;
    public List<Cell> GetAllCellsInRow(int row) => _cells.Where(x => x.Row == row).ToList();
    public void SetCssClass(int row, string cssClass) => _cells.Where(cell => cell.Row == row).ToList().ForEach(cell => cell.CssClass = cssClass);
    public string GetCssClass(int row, int column)
    {
        var matching = _cells.FirstOrDefault(x => x.Row == row && x.Column == column);

        if (matching != null)
            return matching.CssClass;

        return "";
    }
    public bool HasRow(int row) => _cells.Any(cell => cell.Row == row);
    public bool HasColumn(int column) => _cells.Any(cell => cell.Column == column);
    public bool Contains(int row, int column) => _cells.Any(cell => cell.Row == row && cell.Column == column);
    public void CollapseRows(List<int> rows)
    {
        var selectedCells = _cells.Where(x => rows.Contains(x.Row));

        List<Cell> toRemove = new List<Cell>();

        foreach (var cell in selectedCells)
        {
            toRemove.Add(cell);
        }

        _cells.RemoveAll(x => toRemove.Contains(x));

        foreach (var cell in _cells)
        {
            int numberOfLessRows = rows.Where(x => x <= cell.Row).Count();
            cell.Row -= numberOfLessRows;
        }
    }
    public List<Cell> GetRightMost()
    {
        List<Cell> cells = new();
        foreach (var cell in _cells)
        {
            if (!Contains(cell.Row, cell.Column + 1))
            {
                cells.Add(cell);
            }
        }
        return cells;
    }
    public List<Cell> GetLeftMost()
    {
        List<Cell> cells = new();
        foreach (var cell in _cells)
        {
            if (!Contains(cell.Row, cell.Column - 1))
            {
                cells.Add(cell);
            }
        }
        return cells;
    }
    public List<Cell> GetLowest()
    {
        List<Cell> cells = new();
        foreach (var cell in _cells)
        {
            if (!Contains(cell.Row - 1, cell.Column))
            {
                cells.Add(cell);
            }
        }
        return cells;
    }
}
