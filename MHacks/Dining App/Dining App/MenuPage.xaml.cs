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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Dining_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
        }

        

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // We're going to load the whole menu here!
            List<string> words = new List<string>();
            words.Add("One");
            words.Add("Two");
            words.Add("Three");
            words.Add("Four");
            words.Add("Five");
            words.Add("Six");
            words.Add("Seven");
            words.Add("Eight");
            words.Add("Nine");
            words.Add("Ten");
            words.Add("Eleven");
            words.Add("Twelve");
            words.Add("Thirteen");
            words.Add("Fourteen");
            words.Add("Fifteen");
            words.Add("Sixteen");

            double marginAboveSoFar = 10;
            foreach (string s in words)
            {
                TextBlock t = new TextBlock();
                t.Text = s;
                t.FontSize = 50;
                t.Margin = new Thickness(70, marginAboveSoFar, 0, 0);
                marginAboveSoFar += 50;
                innerGrid.Children.Add(t);
                
            }
            //mainScroll.ActualHeight = 2000;
        }
            
            
        


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}
