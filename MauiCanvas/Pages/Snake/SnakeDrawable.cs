namespace MauiCanvas.Pages.Snake;

public class SnakeDrawable : IDrawable
{
    private const int boardWidth = 32;
    private const int boardHeight = 32;

    private readonly Random rng;
    private readonly SnakePositionModel[] snakePositions;

    private int snakeLength;
    private SnakePositionModel cherry;

    public SnakeDrawable()
    {
        rng = new Random();
        snakePositions = new SnakePositionModel[boardWidth * boardHeight];

        ResetGame();
    }

    public SnakeDirectionEnum SnakeDirection { get; set; }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.White;

        float boardPieceHeight = dirtyRect.Height / boardHeight;
        float boardPieceWidth = dirtyRect.Width / boardWidth;

        SnakePositionModel snakePositionModel = GetNextPosition();

        if (snakePositionModel == cherry)
        {
            snakeLength++;
            snakePositions[snakeLength - 1] = snakePositionModel;

            ChangeCherryPosition();
        }
        else
        {
            bool gameReset = false;

            for (int i = 0; i < snakeLength; i++)
            {
                if (snakePositions[i] == snakePositionModel)
                {
                    gameReset = true;
                    ResetGame();
                    break;
                }
            }

            if (!gameReset)
            {
                for (int i = 1; i < snakeLength; i++)
                {
                    snakePositions[i - 1] = snakePositions[i];
                }

                snakePositions[snakeLength - 1] = snakePositionModel;
            }
        }

        for (int i = 0; i < snakeLength; i++)
        {
            snakePositions[i].Draw(canvas, boardPieceHeight, boardPieceWidth);
        }

        canvas.FillColor = Colors.Red;

        cherry.Draw(canvas, boardPieceHeight, boardPieceWidth);
    }

    private void ChangeCherryPosition()
    {
        cherry = new(rng.Next(boardWidth), rng.Next(boardHeight));

        for (int i = 0; i < snakeLength; i++)
        {
            if (snakePositions[i] == cherry)
            {
                ChangeCherryPosition();
                break;
            }
        }
    }

    private SnakePositionModel GetNextPosition()
    {
        (int x, int y) = snakePositions[snakeLength - 1];

        return new SnakePositionModel(
            SnakeDirection switch
            {
                SnakeDirectionEnum.Right => x + 1 == boardWidth ? 0 : x + 1,
                SnakeDirectionEnum.Left => x - 1 == -1 ? boardWidth - 1 : x - 1,
                _ => x,
            },
            SnakeDirection switch
            {
                SnakeDirectionEnum.Down => y + 1 == boardHeight ? 0 : y + 1,
                SnakeDirectionEnum.Up => y - 1 == -1 ? boardHeight - 1 : y - 1,
                _ => y,
            }
        );
    }

    private void ResetGame()
    {
        const int halfBoardWidth = boardWidth / 2;
        const int halfBoardHeight = boardHeight / 2;

        for (int i = 3; i < snakeLength; i++)
        {
            snakePositions[i] = null;
        }

        snakeLength = 3;

        snakePositions[0] = new(halfBoardWidth, halfBoardHeight - 1);
        snakePositions[1] = new(halfBoardWidth, halfBoardHeight);
        snakePositions[2] = new(halfBoardWidth, halfBoardHeight + 1);

        SnakeDirection = SnakeDirectionEnum.Down;

        ChangeCherryPosition();
    }
}
