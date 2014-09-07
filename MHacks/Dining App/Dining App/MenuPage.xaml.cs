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
        bool visited = false;
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
            //innerGrid.Inlines.Remove(InlineCollection.Firstline);
            // Need to remove previous nodes before entering
            if (visited) { }
            else
            {
                //innerGrid.Inlines.Clear();
                visited = true;
                double screenHeight = Window.Current.Bounds.Height;
                mainScroll.Height = 0.80 * screenHeight;
                //string dinHallName = (passingPair)e.Parameter.name;
                passingPair menuItems = (passingPair)e.Parameter;
                nameBlock.Text = menuItems.name;
                nameBlock.FontSize = 30;

                // We're going to load the whole menu here!
                List<FoodItem> breakfast = menuItems.hallMenu.loadMeal(0);
                List<FoodItem> lunch = menuItems.hallMenu.loadMeal(1);
                List<FoodItem> dinner = menuItems.hallMenu.loadMeal(2);

                //double marginAboveSoFar = 10;
                Run breakfastHeader = new Run();
                breakfastHeader.Text = "Breakfast\n\n";
                breakfastHeader.FontSize = 50;
                innerGrid.Inlines.Add(breakfastHeader);
                foreach (FoodItem f in breakfast)
                {
                    Run r = new Run();
                    r.Text = f.name() + "\n";
                    r.FontSize = 20;
                    innerGrid.Inlines.Add(r);
                }
                Run lunchHeader = new Run();
                lunchHeader.Text = "\nLunch\n\n";
                lunchHeader.FontSize = 50;
                innerGrid.Inlines.Add(lunchHeader);
                foreach (FoodItem f in lunch)
                {
                    Run r = new Run();
                    r.Text = f.name() + "\n";
                    r.FontSize = 20;
                    innerGrid.Inlines.Add(r);
                }
                Run dinnerHeader = new Run();
                dinnerHeader.Text = "\nDinner\n\n";
                dinnerHeader.FontSize = 50;
                innerGrid.Inlines.Add(dinnerHeader);
                foreach (FoodItem f in dinner)
                {
                    Run r = new Run();
                    r.Text = f.name() + "\n";
                    r.FontSize = 20;
                    innerGrid.Inlines.Add(r);
                }
            }
        }
            
            
        


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}
