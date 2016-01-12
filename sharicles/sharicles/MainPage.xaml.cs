using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
    public sealed partial class MainPage : Page
    {
        public static MainPage Current { get; set; }
       
        public MainPage()
        {
            this.InitializeComponent();
            Current = this;

            ScenarioFrame.Navigate(typeof(HomePage));

            if(MainPage.Current.Width > 640)
            {
                Splitter.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (MainPage.Current.ActualWidth > 640)
            {
                Splitter.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                MainPage.Current.HamburgerButton2.Visibility = Visibility.Collapsed;
            }
            else
            {
                Splitter.DisplayMode = SplitViewDisplayMode.Overlay;
                MainPage.Current.HamburgerButton2.Visibility = Visibility.Visible;
            }
        }
    }
}
