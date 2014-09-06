using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Text;

namespace Dining_App.Data
{
    enum Halls {BURSLEY, EQUAD, HILL, MARKLEY, NQUAD, SQUAD, TWIGS};

    class BigData
    {
        static string[] hallNames = { "Bursley", "East Quad", "Hill Dining Center", "Markley", "North Quad", "South Quad", "Twigs at Oxford" };
        private List<DiningHall> _diningHallList;
        private List<SearchResult> _searchResults;
        
        public BigData()
        {
            this._diningHallList = new List<DiningHall>();
            this._searchResults = new List<SearchResult>();

            //TODO: Load Dining Halls and menues on initial load

            
        }

        public List<string> getDiningHallNames()
        {
            List<string> names = new List<string>();

            foreach(DiningHall hall in this._diningHallList)
            {
                names.Add(hall.name());
            }

            return names;
        }

    }

    class DiningHall
    {
        private string _name;
        private Menu[] _menu;

        public string name(){
            return this._name;
        }

    }

    class Menu
    {
        private FoodItem[] breakfast;
        private FoodItem[] lunch;
        private FoodItem[] dinner;

    }

    class FoodItem
    {
        private string name;
        private bool mHealthy;
        private bool vegan;
        private bool vegetarian;
        private bool halal;
        private bool glutenFree;
        private bool spicy;

        public FoodItem(string name)
        {
            this.name = name;
        }
    }


    class SearchResult
    {
        List<SearchHit> _hits;

        public SearchResult()
        {
            this._hits = new List<SearchHit>();
        }
    }

    class SearchHit
    {
        private int _diningHall;
        private int _day;

        public SearchHit() //default constructor with no hits
        {
            this._diningHall = -1;
            this._day = -1; //no hit
        }

        public SearchHit(int Hall, int Day) //constructor for positive result
        {
            this._diningHall = Hall;
            this._day = Day;
        }
    }

}