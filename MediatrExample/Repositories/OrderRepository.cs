namespace Example.Ordering.Api.Repositories
{
    using System;
    using System.Collections.Generic;
    using Example.Ordering.Domain.Orders;

    public interface IOrderRepository{
        Order Get(Guid id);
        IEnumerable<Order> Get();
    }

    public class OrderRepository : IOrderRepository
    {
        public OrderRepository()
        {
            
        }

        public Order Get(Guid id)
        {
            return new Order() {
                name = "Henkie"
            };
        }

        public IEnumerable<Order> Get()
        {
            return new [] {
                new Order() {
                    name = "Henkie"
                },
                new Order() {
                    name = "Klaas"
                },
                new Order() {
                    name = "Pietje"
                }
            };
        }
    }
}