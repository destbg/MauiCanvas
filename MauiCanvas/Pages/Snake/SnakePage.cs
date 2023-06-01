using CommunityToolkit.Maui.Markup;
using MauiCanvas.Helpers;
using Timer = System.Timers.Timer;

namespace MauiCanvas.Pages.Snake;

public class SnakePage : ContentPage
{
    private const int gameSpeed = 200;

    private readonly SnakeDrawable drawable;
    private readonly GraphicsView graphics;
    private readonly Timer timer;

    public SnakePage()
    {
        Shell.SetNavBarIsVisible(this, false);
        BackgroundColor = Colors.Black;

        drawable = new SnakeDrawable();

        graphics = new GraphicsView
        {
            Drawable = drawable,
        };

        Content = new Grid
        {
            graphics,
            new Grid
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                RowDefinitions =
                {
                    new RowDefinition { Height = 30 },
                    new RowDefinition { Height = 30 },
                    new RowDefinition { Height = 30 },
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = 30 },
                    new ColumnDefinition { Width = 30 },
                    new ColumnDefinition { Width = 30 },
                },
                Children =
                {
                    new ImageButton
                    {
                        Source = new FontImageSource
                        {
                            FontFamily = "FA",
                            Glyph = SolidIcons.ArrowLeft,
                        },
                        Command = new Command(() => drawable.SnakeDirection = SnakeDirectionEnum.Left)
                    }.Row(1).Column(0),
                    new ImageButton
                    {
                        Source = new FontImageSource
                        {
                            FontFamily = "FA",
                            Glyph = SolidIcons.ArrowRight,
                        },
                        Command = new Command(() => drawable.SnakeDirection = SnakeDirectionEnum.Right)
                    }.Row(1).Column(2),
                    new ImageButton
                    {
                        Source = new FontImageSource
                        {
                            FontFamily = "FA",
                            Glyph = SolidIcons.ArrowUp,
                        },
                        Command = new Command(() => drawable.SnakeDirection = SnakeDirectionEnum.Up)
                    }.Row(0).Column(1),
                    new ImageButton
                    {
                        Source = new FontImageSource
                        {
                            FontFamily = "FA",
                            Glyph = SolidIcons.ArrowDown,
                        },
                        Command = new Command(() => drawable.SnakeDirection = SnakeDirectionEnum.Down)
                    }.Row(2).Column(1)
                }
            }
        };

        timer = new Timer(gameSpeed);
        timer.Start();
        timer.Elapsed += OnTimerElapsed;
    }

    private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        graphics.Invalidate();
    }
}
