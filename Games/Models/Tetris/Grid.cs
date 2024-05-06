using Games.Models.Tetris.Enums;

namespace Games.Models.Tetris;

public class Grid
{
    public int Height { get; set; } = 20;
    public int Width { get; set; } = 10;
    public CellCollection Cells { get; set; } = new();
    public GameState State { get; set; } = GameState.NotStarted;
    public bool IsStarted
    {
        get
        {
            return State == GameState.Playing || State == GameState.GameOver;
        }
    }

}
