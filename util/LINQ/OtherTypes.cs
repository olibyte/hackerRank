using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace Start_LINQ_SQL
{
    #region Objects
    [Table(Name = "Distributors")]
    public class Distributor
    {
        private string _Name;
        [Column(IsPrimaryKey = true, Storage = "_Name")]
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }

        private string _State;
        [Column(Storage = "_State")]
        public string State
        {
            get { return this._State; }
            set { this._State = value; }
        }

    }

    [Table(Name = "Customers")]
    public class Customer
    {
        private EntitySet<Purchase> _Purchases;
        public Customer()
        {
            this._Purchases = new EntitySet<Purchase>();
        }

        [Association(Storage = "_Purchases", OtherKey = "CLast")]
        public EntitySet<Purchase> Purchases
        {
            get { return this._Purchases; }
            set { this._Purchases.Assign(value); }
        }

        //Properties
        private string _Last;
        [Column(IsPrimaryKey = true, Storage = "_Last")]
        public string Last
        {
            get { return this._Last; }
            set { this._Last = value; }
        }

        private string _First;
        [Column(Storage = "_First")]
        public string First
        {
            get { return this._First; }
            set { this._First = value; }
        }

        private string _State;
        [Column(Storage = "_State")]
        public string State
        {
            get { return this._State; }
            set { this._State = value; }
        }
    }

    [Table(Name = "Purchases")]
    public class Purchase
    {

        private EntityRef<Customer> _Customer;
        public Purchase() { this._Customer = new EntityRef<Customer>(); }

        [Association(Storage = "_Customer", ThisKey = "CLast")]
        public Customer Customer
        {
            get { return this._Customer.Entity; }
            set { this._Customer.Entity = value; }
        }

        //Properties
        private string _ID;
        [Column(IsPrimaryKey = true, Storage = "_ID")]
        public string ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        private string _CLast;
        [Column(Storage = "_CLast")]
        public string CLast
        {
            get { return this._CLast; }
            set { this._CLast = value; }
        }

        private decimal _Price;
        [Column(Storage = "_Price")]
        public decimal Price
        {
            get { return this._Price; }
            set { this._Price = value; }
        }

        private string _Item;
        [Column(Storage = "_Item")]
        public string Item
        {
            get { return this._Item; }
            set { this._Item = value; }
        }
    }

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            DataContext db = new DataContext(@"C:\COURSEDB\LINQ_SQL_DB.mdf"); 

            Table<Customer> customers = db.GetTable<Customer>();
            Table<Distributor> distributors = db.GetTable<Distributor>();

            ArrayList products = new ArrayList();
            products.Add("Panel 625");
            products.Add("Panel 200");
            products.Add("Panel 180");
            products.Add("Bulb 24W");
            products.Add("12V Li");
            products.Add(123);

            var alQuery = products
                .OfType<string>()
                .OrderBy(p => p);

            
            var custQuery = customers
                .Where(c => c.State == "OR")
                .AsEnumerable()
                .SkipWhile(c=>c.Last.Contains("B")); //skipwhile not supported so cast as Enumerable
            

            foreach (var p in custQuery)
            {
                Console.WriteLine("{0}", p.Last);
            }

            

            Console.ReadKey();
        }
    }
}
