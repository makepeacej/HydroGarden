namespace HydroGarden.Models
{
    public class Order
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string datePlace { get; set; }
        public string dateScheduled { get; set; }
        public bool isCompleted { get; set; } = false;
        public IDictionary<Product, int> orderList { get; set; }

        /// <summary>
        /// Constructor for the orders that customers will place for products. This constructor is used for 
        /// changes from the database. 
        /// </summary>
        /// <param name="id">int id</param>
        /// <param name="customerName">string customer's name</param>
        /// <param name="phone">string customer's phone</param>
        /// <param name="email">string customer's email</param>
        /// <param name="datePlace">string the date placed</param>
        /// <param name="dateScheduled">string the date scheduled for completion</param>
        /// <param name="orList">dictionary containing amount of each product desired</param>
        public Order(int id, string customerName, string phone, string email, string datePlace, string dateScheduled, IDictionary<Product, int> orList)
        {
            this.id = id;
            this.customerName = customerName;
            this.phone = phone;
            this.email = email;
            this.datePlace = datePlace;
            this.dateScheduled = dateScheduled;
            this.orderList = orList;
        }

        /// <summary>
        /// Constructor for the orders that customers will place for products. This constructor is used for 
        /// the creation of new orders to be submitted to the database where an id will be generated. 
        /// </summary>
        /// <param name="customerName">string customer's name</param>
        /// <param name="phone">string customer's phone</param>
        /// <param name="email">string customer's email</param>
        /// <param name="datePlace">string the date placed</param>
        /// <param name="dateScheduled">string the date scheduled for completion</param>
        /// <param name="orList">dictionary containing amount of each product desired</param>
        public Order(string customerName, string phone, string email, string datePlace, string dateScheduled, IDictionary<Product, int> orList)
        {
            this.customerName = customerName;
            this.phone = phone;
            this.email = email;
            this.datePlace = datePlace;
            this.dateScheduled = dateScheduled;
            this.orderList = orList;
        }
    }
}