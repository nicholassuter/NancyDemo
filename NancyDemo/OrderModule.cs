using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NancyDemo
{
    public class OrderModule : NancyModule
    {
        public OrderModule() : base("/orders")
        {
            IEnumerable<Order> allOrders = GetOrders();
            Get["/"] = _ => Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(allOrders);
            Get["/{id}"] = parameters =>
            {
                try
                {
                    var order = allOrders.First(o => o.Id == parameters.id);
                    return Negotiate.WithStatusCode(HttpStatusCode.OK).WithModel(order);
                }
                catch (Exception)
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                }
            };
            //Put["/"] = _ => { /*do stuff */ };
            //Delete["/"] = _ => { /*do stuff */ };
            //Post["/"] = _ => { /*do stuff */ };
            //Options["/"] = _ => { /*do stuff */ };
        }

        private IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Customer = new Customer {Id = 1, FirstName = "John", LastName = "Doe"},
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem
                        {
                            Product = new Product
                            {
                                Id = 1,
                                Name = "Shovel",
                                Price = 10
                            },
                            Quantity = 1
                        },
                        new OrderItem
                        {
                            Product = new Product
                            {
                                Id = 2,
                                Name = "Rope",
                                Price = 1
                            },
                            Quantity = 5
                        },
                        new OrderItem
                        {
                            Product = new Product
                            {
                                Id = 2,
                                Name = "Lock",
                                Price = 3
                            },
                            Quantity = 1
                        },
                    }
                }
            };
            return orders;
        }
    }

    public class Order
    {
        public int Id { get; set; }


        public float TotalAmount
        {
            get
            {
                return OrderItems.Sum(orderItem => orderItem.Product.Price * orderItem.Quantity);
            }
        }

        public IEnumerable<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class OrderItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
