﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Devices.Sensors;
using System.Windows.Threading;
using Microsoft.Xna.Framework;

namespace Rovisio
{
    public partial class MotionCamera : PhoneApplicationPage
    {
        Accelerometer accelerometer;
        AsynchronousClient client = new AsynchronousClient("192.168.11.164", 8000);
        
        double x_acc = 0;
        double y_acc = 0;
        double z_acc = 0;

        DispatcherTimer timer;
        Vector3 acceleration;
        bool isDataValid;

        public MotionCamera()
        {
            InitializeComponent();

            if (!Accelerometer.IsSupported)
            {
                // The device on which the application is running does not support
                // the accelerometer sensor. Alert the user and hide the
                // application bar.
                statusTextBlock.Text = "Accelerometer is not supported on this device.";
                ApplicationBar.IsVisible = false;
            }
            else
            {
                // Initialize the timer and add Tick event handler, but don't start it yet.
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(30);
                timer.Tick += new EventHandler(timer_Tick);
            }
        }

        void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            // Note that this event handler is called from a background thread
            // and therefore does not have access to the UI thread. To update 
            // the UI from this handler, use Dispatcher.BeginInvoke() as shown.
            Dispatcher.BeginInvoke(() => { statusTextBlock.Text = "in CurrentValueChanged"; });


            isDataValid = accelerometer.IsDataValid;

            acceleration = e.SensorReading.Acceleration;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (isDataValid)
            {
                x_acc = acceleration.X;
                y_acc = acceleration.Y;
                z_acc = acceleration.Z;
                
                // Show the numeric values
                xTextBlock.Text = "X: " + acceleration.X.ToString("0.00");
                yTextBlock.Text = "Y: " + acceleration.Y.ToString("0.00");
                zTextBlock.Text = "Z: " + acceleration.Z.ToString("0.00");

                xTextBlock.Text = "X: " + x_acc.ToString("0.00");
                yTextBlock.Text = "Y: " + y_acc.ToString("0.00");
                zTextBlock.Text = "Z: " + z_acc.ToString("0.00");

                if (z_acc > 0.71)
                {
                    cmdDataBlock.Text = "String: w";
                    client.SendData("w");
                }
                else if (z_acc < -0.71)
                {
                    cmdDataBlock.Text = "String: x";
                    client.SendData("x");
                }
                else if (x_acc < -0.71)
                {
                    cmdDataBlock.Text = "String: a";
                    client.SendData("a");
                }
                else if (x_acc > 0.71)
                {
                    cmdDataBlock.Text = "String: d";
                    client.SendData("d");
                }
                else
                {
                    cmdDataBlock.Text = "String: -";
                }
                
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (accelerometer != null && accelerometer.IsDataValid)
            {
                // Stop data acquisition from the accelerometer.
                accelerometer.Stop();
                timer.Stop();
                statusTextBlock.Text = "accelerometer stopped.";

            }
            else
            {
                if (accelerometer == null)
                {
                    // Instantiate the accelerometer.
                    accelerometer = new Accelerometer();


                    // Specify the desired time between updates. The sensor accepts
                    // intervals in multiples of 20 ms.
                    accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(300);

                    // The sensor may not support the requested time between updates.
                    // The TimeBetweenUpdates property reflects the actual rate.
                    timeBetweenUpdatesTextBlock.Text = accelerometer.TimeBetweenUpdates.TotalMilliseconds + " ms";


                    accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);
                }

                try
                {
                    statusTextBlock.Text = "starting accelerometer.";
                    accelerometer.Start();
                    timer.Start();
                }
                catch (InvalidOperationException)
                {
                    statusTextBlock.Text = "unable to start accelerometer.";
                }

            }

        }
    }


}