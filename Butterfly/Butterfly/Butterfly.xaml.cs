using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Butterfly
{
    public sealed partial class Butterfly : UserControl
    {

        // Animate butterfly timer
        private DispatcherTimer timer;

        // Offset to show sprite
        private int currentframe = 0;
        private int direction = 1;
        private int frameheight = 132;

        // Speed, acceleration, ANGLE
        private readonly double MaxSpeed = 10.0;
        private readonly double Accelerate = 0.5;
        private readonly double AngleStep = 5;
        private double Angle = 0;
        private double Speed = 0;



        // Location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public Butterfly()
        {
            this.InitializeComponent();

            // Animate
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 135);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, object e)
        {
            // frame
            if (direction == 1) currentframe++;
            else if (direction == -1) currentframe--;
            // border value
            if (currentframe == 0 || currentframe == 4)
            {
                direction = -1 * direction; // 1 or -1

            }
            // set offset
            SpriteSheetOffset.Y = currentframe * -frameheight;

        }

        // Show butterly
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
        // Move
        public void Move()
        {
            // More speed
            Speed += Accelerate;
            if (Speed > MaxSpeed) Speed = MaxSpeed;

            // update location values (angle and speed)
            LocationX -= (Math.Cos(Math.PI / 180 * (Angle + 90))) * Speed;
            LocationY -= (Math.Sin(Math.PI / 180 * (Angle + 90))) * Speed;

            // Update in canvas
            //SetLocation();

        }

        // Rotate
        public void Rotate(int direction)
        {
            Angle += direction * AngleStep; // -1 or 1 => -5 or 5
            ButterflyRotateAngle.Angle = Angle;

        }

    }
}
