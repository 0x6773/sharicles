using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace sharicles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public static HomePage Current;
        public HomePage()
        {
            this.InitializeComponent();
            Current = this;
            
            SetMapPosition();
        }

        private void FromData_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FromData.Text == "From")
                FromData.Text = "";
        }

        private void FromData_LostFocus(object sender, RoutedEventArgs e)
        {
            if (FromData.Text == "")
                FromData.Text = "From";
        }

        private void ToData_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ToData.Text == "To")
                ToData.Text = "";
        }

        private void ToData_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ToData.Text == "")
                ToData.Text = "To";
        }

        private async void SetMapPosition()
        {
            UIElement findLocation = MainStackPanel.Children[0];
            MainStackPanel.Children.RemoveAt(0);

            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    // Show "Finding your Location"
                    MainStackPanel.Children.Insert(0, findLocation);

                    BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 25.367, Longitude = 82.996 };                    
                    // Get the current location.
                    Geolocator geolocator = new Geolocator();
                    //Geoposition pos = await geolocator.GetGeopositionAsync();
                    //Geopoint myLocation = pos.Coordinate.Point;
                    Geopoint myLocation = new Geopoint(snPosition);

                    // Set the map location.
                    MapControl.Center = myLocation;
                    MapControl.ZoomLevel = 16;
                    MapControl.LandmarksVisible = true;

                    MapIcon mapIcon1 = new MapIcon();
                    mapIcon1.Location = myLocation;
                    mapIcon1.Title = "Your Location";

                    MapControl.MapElements.Add(mapIcon1);

                    // Show "Finding your Location"
                    MainStackPanel.Children.RemoveAt(0);

                    break;

                case GeolocationAccessStatus.Denied:
                    // Handle the case  if access to location is denied.
                    await new MessageDialog("Seems like you didn't allowed us for using Locations Services or your Location " +
                        "Setting is turned off. This App will not work without Locations Services. Thanks!!").ShowAsync();
                    Application.Current.Exit();
                    break;

                case GeolocationAccessStatus.Unspecified:
                    // Handle the case if  an unspecified error occurs.
                    await new MessageDialog("Seems like you didn't allowed us for using Locations Services or your Location " +
                        "Setting is turned off. This App will not work without Locations Services. Thanks!!").ShowAsync();
                    Application.Current.Exit();
                    break;
            }

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(HomePage.Current.ActualWidth > 450)
            {
                MainStackPanel.Width = 450;
            }
        }
    }
}
