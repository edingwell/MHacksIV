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
        BigData allDiningMenuItems;
        int currentHall;
        int currentDay;
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
                mainScroll.Height = 0.80 * screenHeight;
                //string dinHallName = (passingPair)e.Parameter.name;
                passingPair menuItems = (passingPair)e.Parameter;
                allDiningMenuItems = menuItems.allTheDiningHallMenus;
                currentHall = menuItems.hall;
                currentDay = menuItems.day;
                nameBlock.Text = allDiningMenuItems.getHallNames(currentHall);
                DateTime datetimething = DateTime.Today.Date.AddDays(currentDay);
                menuDate.Text = datetimething.DayOfWeek + " " + datetimething.ToString("MM/dd");
                nameBlock.FontSize = 30;
                allDiningMenuItems.ChangeDate(); //Keeping this ahead

                Menu todaysMenuItems = allDiningMenuItems.loadMenu(currentDay, currentHall);
                // We're going to load the whole menu here!
                List<FoodItem> breakfast = todaysMenuItems.loadMeal(0);
                List<FoodItem> lunch = todaysMenuItems.loadMeal(1);
                List<FoodItem> dinner = todaysMenuItems.loadMeal(2);

                //double marginAboveSoFar = 10;
                Run breakfastHeader = new Run();
                breakfastHeader.Text = "Breakfast\n\n";
                breakfastHeader.FontSize = 50;
                innerGrid.Inlines.Add(breakfastHeader);
                foreach (FoodItem f in breakfast)
                {
                    if (f.name().Contains("serving") || f.name().Contains("Serving"))
                    {
                        Run r2 = new Run();
                        r2.Text = "Not Open\n";
                        r2.FontSize = 20;
                        innerGrid.Inlines.Add(r2);
                        break;
                    }
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
                    if (f.name().Contains("serving") || f.name().Contains("Serving"))
                    {
                        Run r2 = new Run();
                        r2.Text = "Not Open\n";
                        r2.FontSize = 20;
                        innerGrid.Inlines.Add(r2);
                        break;
                    }
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
                    if (f.name().Contains("serving") || f.name().Contains("Serving"))
                    {
                        Run r2 = new Run();
                        r2.Text = "Not Open\n";
                        r2.FontSize = 20;
                        innerGrid.Inlines.Add(r2);
                        break;
                    }
                    Run r = new Run();
                    r.Text = f.name() + "\n";
                    r.FontSize = 20;
                    innerGrid.Inlines.Add(r);
                }
        }
            
            
        


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void future_Click(object sender, RoutedEventArgs e)
        {
            passingPair pair = new passingPair();
            pair.hall = currentHall;
            pair.day = currentDay+1;
            pair.allTheDiningHallMenus = allDiningMenuItems;
            this.Frame.Navigate(typeof(MenuPage), pair);
        }

    }
}
