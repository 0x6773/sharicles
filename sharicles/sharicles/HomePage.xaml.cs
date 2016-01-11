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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace sharicles
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
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
    }
}
