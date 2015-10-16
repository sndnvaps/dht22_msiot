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
using Windows.Devices.Gpio;


//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace DHT22_GpioOneWire
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void InitGPIO()
        {
            var gpio = GpioController.GetDefault(); 
            //show an error if there is no GPIO Controller
            if (gpio == null)
            {
                dht22pin = null;
                GpioStatus.Text = "There is no GPIO Controller on this devicd.";
                return;
            }

            dht22pin = gpio.OpenPin(DHT22_PIN);

            dht22pin.SetDriveMode(GpioPinDriveMode.Input);
        }

        private GpioPin dht22pin;
        private const int DHT22_PIN = 24; //定义为24 
    }
    
}
