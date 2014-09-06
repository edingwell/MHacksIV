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
using System.Net.Http;
using Windows.Data.Xml.Dom;

namespace Dining_App.Data
{
    enum Halls {BURSLEY, EQUAD, HILL, MARKLEY, NQUAD, SQUAD, TWIGS};
    enum Meals {BREAKFAST, LUNCH, DINNER};


    class BigData
    {
        static string[] hallNames = { "Bursley", 
                                        "East Quad", 
                                        "Hill Dining Center", 
                                        "Markley", 
                                        "North Quad", 
                                        "South Quad", 
                                        "Twigs at Oxford" };
        private List<DiningHall> _diningHallList;
        private List<SearchResult> _searchResults;
        private int _curDate;

        // This function gets the menu from the url
        public async Task GetMenus()
        {
            for(int i=0; i<this._diningHallList.Count(); ++i)
            {
                string url = this._createURL(this._curDate, i);
                string menuFromOnline = await new HttpClient().GetStringAsync(url);
                this._diningHallList[i].addMenu(this._curDate);
                this.parseMenu(this._diningHallList[i], menuFromOnline);
            }
        }   

        private void parseMenu(DiningHall diningHall, string xmlMenu)
        {
            
            XmlDocument XML = new XmlDocument();
            XML.LoadXml(xmlMenu);
            XmlNodeList Meals = XML.GetElementsByTagName("meal");
            
            //find breakfast, lunch, and dinner
            for(int i=0; i<Meals.Count(); ++i)
            {
                IXmlNode curNode = Meals[i];
                if (curNode.FirstChild.FirstChild.NodeValue.Equals("BREAKFAST"))
                {
                    IXmlNode sibling = curNode.FirstChild.NextSibling;
                    for (int j=1; j<curNode.ChildNodes.Count(); ++j)
                    {
                        if (sibling.LocalName.Equals("course"))
                        {
                            //another for loop?
                            diningHall.addtoMenu(0, sibling.FirstChild.FirstChild.NodeValue.ToString());
                        }
                        sibling = sibling.NextSibling;
                    }
                }
                else if (Meals[i].FirstChild.FirstChild.NodeValue.Equals("LUNCH"))
                {

                }
                else if (Meals[i].FirstChild.FirstChild.NodeValue.Equals("DINNER"))
                {

                }
            }

 
        }

        public BigData()
        {
            this._diningHallList = new List<DiningHall>();
            this._searchResults = new List<SearchResult>();
            foreach (string name in BigData.hallNames)
            {
                var newDiningHall = new DiningHall(name);
                string url = _createURL(0, this._diningHallList.Count());
                this._diningHallList.Add(newDiningHall);
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
                    location = "BURSLEY%20DINING%20HALL";
                    break;
                case (int)Halls.EQUAD:
                    location = "EAST%20QUAD%20DINING%20HALL";
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
                   http://www.housing.umich.edu/files/helper_files/js/menu2xml.php?location=TWIGS%20AT%20OXFORD&date=today
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

        public void addMenu(int Day) //add menu to days menu only if it is the next day, if its not then we've done somethign wrong
        {
            if (Day == this._menu.Count())
            {
                this._menu.Add(new Menu());
            }
        }

        public void addtoMenu(int meal, string foodName)
        {

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