namespace HydroGarden.Models

{
    using System.Collections;
    /// <summary>
    /// The admin class will contain the main methods behind the logic of the web 
    /// application. 
    /// </summary>
    public class Admin
    {
        private static ArrayList listOfProducts = new ArrayList();
        private static ArrayList listOfOrders = new ArrayList();
        private string measurement = "lbs"; //oz or lbs

        /// <summary>
        /// Add a product to the arraylist of products
        /// </summary>
        /// <param name="p">
        /// A product object
        /// </param>
        public static void addProduct(Product p)
        {
            listOfProducts.Add(p);
        }

        /// <summary>
        /// Add an order to the arraylist of products
        /// </summary>
        /// <param name="o">
        /// An order object
        /// </param>
        public static void addOrder(Order o)
        {
            listOfOrders.Add(o);
        }

        /// <summary>
        /// Delete a product object from the list of products
        /// </summary>
        /// <param name="id">
        /// The int id of the product
        /// </param>
        public static void deleteProduct(int id)
        {
            for (int i = 0; i < listOfProducts.Count; i++)
            {
                Product p = (Product)listOfProducts[i];
                if (p.id == id)
                {
                    listOfProducts.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Delete an order using the id from the list of orders 
        /// </summary>
        /// <param name="id">
        /// int id of the order
        /// </param>
        public static void deleteOrder(int id)
        {
            for (int i = 0; i < listOfOrders.Count; i++)
            {
                Order o = (Order)listOfOrders[i];
                if (o.id == id)
                {
                    listOfProducts.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Search the list of products to find the product with
        /// the given id. 
        /// </summary>
        /// <param name="id">int id of a product</param>
        /// <returns>product object</returns>
        public static Product searchProduct(int id)
        {
            foreach (Product p in listOfProducts)
            {
                if (p.id == id)
                {
                    return p;
                }
            }
            return null; //id does not exist
        }

        /// <summary>
        /// Search the list of products to find the product with
        /// the given name. 
        /// </summary>
        /// <param name="name">string name of the product</param>
        /// <returns>product object</returns>
        public static Product searchProduct(String name)
        {
            foreach (Product p in listOfProducts)
            {
                if (name.Equals(p.name))
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Search the list of orders to find the order with 
        /// the given id
        /// </summary>
        /// <param name="id"> int id of the order</param>
        /// <returns>order object</returns>
        public static Order searchOrder(int id)
        {
            foreach (Order o in listOfOrders)
            {
                if (o.id == id)
                {
                    return o;
                }
            }
            return null; //id does not exist
        }

        /// <summary>
        /// Search the list of orders to find the order with 
        /// the given customer name
        /// </summary>
        /// <param name="custName">the customer that placed the order</param>
        /// <returns>order object</returns>
        public static Order searchOrder(String custName)
        {
            foreach (Order o in listOfOrders)
            {
                if (custName.Equals(o.customerName))
                {
                    return o;
                }
            }
            return null; //Customer does not have an order
        }

        /// <summary>
        /// Change the measurement from ounces to pounds 
        /// and vice versa. 
        /// </summary>
        public void changeMeasurement()
        {
            if (measurement.Equals("lbs"))
            {
                measurement = "Ozs";
            }
            else
            {
                measurement = "lbs";
            }
        }



    }
}
