using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Text;

namespace Dining_App.Data
{
    enum Halls {BURSLEY, EQUAD, HILL, MARKLEY, NQUAD, SQUAD, TWIGS};
    enum Meals {BREAKFAST, LUNCH, DINNER};

    class BigData
    {
        static string[] hallNames = { "Bursley", "East Quad", "Hill Dining Center", "Markley", "North Quad", "South Quad", "Twigs at Oxford" };
        private List<DiningHall> _diningHallList;
        private List<SearchResult> _searchResults;
        
        public BigData()
        {
            this._diningHallList = new List<DiningHall>();
            this._searchResults = new List<SearchResult>();

            foreach (string name in BigData.hallNames)
            {
                this._diningHallList.Add(new DiningHall(name));
                

            }
            
                       
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

        private string _createURL(int Day, int Name)
        {
            string location;
            string date;
            string url;
            switch (Name)
            {
                case (int)Halls.BURSLEY:
                    location = "BURSLEY%20%DINING%20HALL";
                    break;
                case (int)Halls.EQUAD:
                    location = "EAST%20QUAD%DINING%20HALL";
                    break;
                case (int)Halls.HILL:
                    location = "HILL%20DINING%20CENTER";
                    break;
                case (int)Halls.MARKLEY:
                    location = "MARKLEY%20DINING%20HALL";
                    break;
                case (int)Halls.NQUAD:
                    location = "NORTH%20QUAD%20DINING%20HALL";
                    break;
                case (int)Halls.SQUAD:
                    location = "SOUTH%20QUAD%20DINING%20HALL";
                    break;
                case (int)Halls.TWIGS:
                    location = "TWIGS%20AT%20OXFORD";
                    break;
                default: //should never hit this 
                    location = "";
                    break;
            }
            if (Day == 0)
            {
                date = "today";
            }
            else
            {
                date = "today";
                //TODO: add parsing for other days
            }

            url = "http://www.housing.umich.edu/files/helper_files/js/menu2xml.php?location=" + location + "&date=" + date;
            return url;
        }
    }

    class DiningHall
    {
        private string _name;
        private List<Menu> _menu; //indexed by days from today

        public DiningHall()
        {
            this._name = "";
            this._menu = new List<Menu>();
        }
        public DiningHall(string Name)
        {
            this._name = Name;
            this._menu = new List<Menu>();
        }

        public void addMenu(int Day, Menu NewMenu) //add menu to days menu only if it is the next day, if its not then we've done somethign wrong
        {
            if (Day == this._menu.Count())
            {
                this._menu.Add(NewMenu);
            }
        }

        public void setName(string Name) //shouldn't ever need to use this, should be setting name with the constructor
        {
            this._name = Name;
        }

        public string name(){
            return this._name;
        }

        public Menu getMenu(int Day)
        {
            return this._menu[Day];
        }

    }

    class Menu
    {
        private List<FoodItem> _breakfast;
        private List<FoodItem> _lunch;
        private List<FoodItem> _dinner;

        public Menu()
        {
            this._breakfast = new List<FoodItem>();
            this._lunch = new List<FoodItem>();
            this._dinner = new List<FoodItem>();
        }

        public void addFood(FoodItem OmNomNom, int Meal)
        {
            if (Meal == (int)Meals.BREAKFAST)
            {
                this._breakfast.Add(OmNomNom);
            }
            else if(Meal == (int)Meals.LUNCH)
            {
                this._lunch.Add(OmNomNom);
            }
            else if(Meal == (int)Meals.DINNER)
            {
                this._dinner.Add(OmNomNom);
            }
        }

        public bool find(string FoodName) //returns true if food name containing string is found
        {
            bool found = false;

            foreach (FoodItem food in this._breakfast)
            {
                if (food.name().Contains(FoodName))
                {
                    found = true;
                    return found;
                }

            }
            foreach (FoodItem food in this._lunch)
            {
                if (food.name().Contains(FoodName))
                {
                    found = true;
                    return found;
                }

            }
            foreach (FoodItem food in this._dinner)
            {
                if (food.name().Contains(FoodName))
                {
                    found = true;
                    return found;
                }

            }
            return found;
        }

    }

    class FoodItem
    {
        private string _name;
        private bool _mHealthy;
        private bool _vegan;
        private bool _vegetarian;
        private bool _halal;
        private bool _glutenFree;
        private bool _spicy;

        public FoodItem(string Name)
        {
            this._name = Name;
            this._mHealthy = false;
            this._vegan = false;
            this._vegetarian = false;
            this._halal = false;
            this._glutenFree = false;
            this._spicy = false;
        }

        public string name()
        {
            return this._name;
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