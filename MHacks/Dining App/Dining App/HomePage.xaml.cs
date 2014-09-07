using Dining_App;
using Dining_App.Common;
using Dining_App.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Dining_App
{
    struct passingPair
    {
        public int hall;
        public BigData allTheDiningHallMenus;
        public int day;
    };

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        BigData allDiningHallMenus = new BigData();
        private const string FirstGroupName = "DiningHallList";
        static bool visited = false;

        public MainPage()
        {
            // Grab the menus from online
            

            this.InitializeComponent();
            this.loadData();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        private async void loadData()
        {
            var test = new BigData();
            await test.GetMenus();
        }
        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            if (!visited)
            {
                visited = true;
                allDiningHallMenus.GetMenus(); //await?
            }

            ListView mainHallList = new ListView();
            mainHallList.IsItemClickEnabled = true;
            mainHallList.ItemClick += mainHallList_ItemClick;
        }

        private void mainHallList_ItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>.
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-1");
            //this.DefaultViewModel[FirstGroupName] = sampleDataGroup;

        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache. Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }
        private void appTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HyperlinkButton_Click1(object sender, RoutedEventArgs e)
        {
            //Menu bursleyMenu = allDiningHallMenus.loadMenu(0, 0); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 0;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
            this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void HyperlinkButton_Click2(object sender, RoutedEventArgs e)
        {
            //Menu EastQuadMenu = allDiningHallMenus.loadMenu(0, 1); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 1;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
           this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void HyperlinkButton_Click3(object sender, RoutedEventArgs e)
        {
            //Menu HillDiningCenter = allDiningHallMenus.loadMenu(0, 2); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 2;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
            this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void HyperlinkButton_Click4(object sender, RoutedEventArgs e)
        {
            //Menu MarkleyMenu = allDiningHallMenus.loadMenu(0, 3); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 3;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
            this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void HyperlinkButton_Click5(object sender, RoutedEventArgs e)
        {
          //  Menu NorthQuadMenu = allDiningHallMenus.loadMenu(0, 4); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 4;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
            this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void HyperlinkButton_Click6(object sender, RoutedEventArgs e)
        {
            //Menu SouthQuadMenu = allDiningHallMenus.loadMenu(0, 5); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 5;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
            this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void HyperlinkButton_Click7(object sender, RoutedEventArgs e)
        {
            //Menu TwigsMenu = allDiningHallMenus.loadMenu(0, 6); //0 is Bursley
            passingPair nameHallPair;
            nameHallPair.hall = 6;
            nameHallPair.day = 0;
            nameHallPair.allTheDiningHallMenus = allDiningHallMenus;
            this.Frame.Navigate(typeof(MenuPage), nameHallPair);
        }

        private void searchNavButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SearchResultsnn), allDiningHallMenus);
        }
        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache. Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>



    }
}
