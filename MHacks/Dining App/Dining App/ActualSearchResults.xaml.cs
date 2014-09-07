using Dining_App.Data;
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
    public sealed partial class ActualSearchResults : Page
    {
        public ActualSearchResults()
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
            System.Collections.Generic.List<SearchHit> searchResults = (List<SearchHit>)e.Parameter;

            foreach (SearchHit result in searchResults)
            {
                Run r = new Run();
                r.Text = result.getDiningHall() + " " + result.getDay().ToString() + "\n";
                r.FontSize = 20;
                resultsBox.Inlines.Add(r);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
