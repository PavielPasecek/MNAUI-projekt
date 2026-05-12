using Microsoft.Maui.Devices;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    double x = 0;
    public MainPage()
    {
        InitializeComponent();
        Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
        Accelerometer.Default.Start(SensorSpeed.Game);

        var dispatcher = Dispatcher.CreateTimer();
        dispatcher.Tick += Update;
        dispatcher.Interval = TimeSpan.FromMilliseconds(16);
        dispatcher.Start();
    }


    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        x += e.Reading.Acceleration.X * -10;
    }

    void MovePlayer()
    {
        x = Math.Clamp(x, -180, 180);
        Player.TranslationX = x;
        Player.TranslationY = Math.Sin(Environment.TickCount64 * 0.005) * 10 - 40;
    }

    void MovePtak()
    {
        Ptak.TranslationX = -160;   
    }
    private void Update(object sender, EventArgs e)
    {
        MovePlayer();
        MovePtak();
    }
}
