using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace propitious_octo_moo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetMapPosition();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void SetMapPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    //BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 25.367, Longitude = 82.996 };
                    
                    // Get the current location.
                    Geolocator geolocator = new Geolocator();
                    Geoposition pos = await geolocator.GetGeopositionAsync();
                    Geopoint myLocation = pos.Coordinate.Point;
                    //Geopoint myLocation = new Geopoint(snPosition);

                    // Set the map location.
                    MapControl1.Center = myLocation;
                    MapControl1.ZoomLevel = 16;
                    MapControl1.LandmarksVisible = true;

                    MapIcon mapIcon1 = new MapIcon();
                    mapIcon1.Location = myLocation;
                    mapIcon1.Title = "Your Location";

                    MapControl1.MapElements.Add(mapIcon1);

                    MapFindProgressBar.IsActive = false;
                    MapFindTextBlock.Visibility = Visibility.Collapsed;

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
    }
}
