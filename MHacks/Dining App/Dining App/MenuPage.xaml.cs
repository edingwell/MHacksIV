using System;
using Dining_App.Data;
using Dining_App.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
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
            double screenHeight = Window.Current.Bounds.Height;
            mainScroll.Height = 0.80*screenHeight;
            //string dinHallName = (passingPair)e.Parameter.name;
            passingPair menuItems = (passingPair)e.Parameter;
            nameBlock.Text = menuItems.name;
            nameBlock.FontSize = 30;

            List<FoodItem> breakfast = new List<FoodItem>();
            List<FoodItem> lunch = new List<FoodItem>();
            List<FoodItem> dinner = new List<FoodItem>();

            // We're going to load the whole menu here!
            List<string> words = new List<string>();
            words.Add("One\n");
            words.Add("Two\n");
            words.Add("Three\n");
            words.Add("Four\n");
            words.Add("Five\n");
            words.Add("Six\n");
            words.Add("Seven\n");
            words.Add("Eight\n");
            words.Add("Nine\n");
            words.Add("Ten\n");
            words.Add("Eleven\n");
            words.Add("Twelve\n");
            words.Add("Thirteen\n");
            words.Add("Fourteen\n");
            words.Add("Fifteen\n");
            words.Add("Sixteen\n");

            //double marginAboveSoFar = 10;
            foreach (string s in words)
            {
                Run r = new Run();
                r.Text = s;
                r.FontSize = 40;
                innerGrid.Inlines.Add(r); 
            }
        }
            
            
        


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}
