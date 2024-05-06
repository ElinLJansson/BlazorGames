using Games.Models.Tetris.Enums;
using Games.Models.Tetris.Tetrominos;

namespace Games.Models.Tetris;

public class TetrominoGenerator
{
    public TetrominoStyle Next(params TetrominoStyle[] unusabletyles)
    {
        Random random = new Random(DateTime.Now.Millisecond);
        var style = (TetrominoStyle)random.Next(1,8);
        while (unusabletyles.Contains(style))
        {
            style = (TetrominoStyle)random.Next(1, 8);
        }
        return style;
    }
    public Tetromino CreateFromStyle(TetrominoStyle style, Grid grid)
    {
        return style switch
        {
            TetrominoStyle.Block => new Block(grid),
            TetrominoStyle.Straight => new Straight(grid),
            TetrominoStyle.TShaped => new TShaped(grid),
            TetrominoStyle.LeftZigZag => new LeftZigZag(grid),
            TetrominoStyle.RightZigZag => new RightZigZag(grid),
            TetrominoStyle.LShaped => new LShaped(grid),
            TetrominoStyle.ReverseLShaped => new ReverseLShaped(grid),
            _ => new Block(grid),
        };
    }
}
