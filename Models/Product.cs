using System.ComponentModel.DataAnnotations;

namespace HydroGarden.Models
{
    public class Product
    {

        public int? id { get; set; }
        public string? name { get; set; }
        [DataType(DataType.Currency)]
        public double? price { get; set; }//set the default measurement to pounds and convert if needed everywhere else
        public bool availability { get; set; } = true;
        public string ImageURL { get; set; }

        public Product()
        {

        }
        /// <summary>
        /// Constructor to create a local product object to make changes from the database.
        /// Can be used to make changes to a product and send the updates to the database. 
        /// </summary>
        /// <param name="id"> int id</param>
        /// <param name="name">string name</param>
        /// <param name="price">double price in pounds</param>
        /// <param name="av">bool availability of the product</param>
        public Product(int id, string name, double price, bool av)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            availability = av;
        }

        /// <summary>
        /// Constructor that is used to create new products on the application that will then be shipped to
        /// the database to create an auto generated id. 
        /// </summary>
        /// <param name="name">string name</param>
        /// <param name="price">double price in pounds</param>
        /// <param name="availability">bool availability of the product</param>
        public Product(string name, double price, bool availability)
        {
            this.name = name;
            this.price = price;
            this.availability = availability;
        }
    }
}