namespace HydroGarden.Models

{
    using System.Collections;
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
