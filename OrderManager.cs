using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP10FEXLab
{
    // Shared by both screens: the Kiosk places orders, the Queue Monitor listens to the events.
    public class OrderManager
    {
        private const int FirstOrderNumber = 1001;

        private readonly IDataStore store;
        private readonly List<Order> activeOrders = new List<Order>();
        private int lastOrderNumber;

        public event EventHandler<Order> OrderPlaced;
        public event EventHandler<Order> OrderStatusChanged;

        public OrderManager(IDataStore store)
        {
            if (store == null) throw new ArgumentNullException("store");
            this.store = store;
            lastOrderNumber = Math.Max(store.GetLastOrderNumber(), FirstOrderNumber - 1);
        }

        public List<MealPackage> GetMenu()
        {
            return store.LoadMeals();
        }

        public List<Order> GetPreparingOrders()
        {
            return activeOrders.Where(o => o.Status == OrderStatus.Preparing)
                               .OrderBy(o => o.OrderNumber)
                               .ToList();
        }

        public List<Order> GetServingOrders()
        {
            return activeOrders.Where(o => o.Status == OrderStatus.NowServing)
                               .OrderByDescending(o => o.ReadyAt)
                               .ToList();
        }

        public Order PlaceOrder(Cart cart, DiningOption dining, PaymentMethod payment)
        {
            if (cart == null || cart.IsEmpty)
            {
                throw new InvalidOperationException("Add at least one meal before paying.");
            }

            Order order = new Order(lastOrderNumber + 1, DateTime.Now, dining, payment, cart.Items);

            // Save first, so a failed save doesn't use up an order number.
            store.SaveTransaction(order);

            lastOrderNumber = order.OrderNumber;
            activeOrders.Add(order);
            Raise(OrderPlaced, order);
            return order;
        }

        // Preparing -> Now Serving -> Claimed (claimed orders leave the monitor).
        public void Advance(int orderNumber)
        {
            Order order = activeOrders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (order == null) return;
            
            if (order.Status == OrderStatus.Preparing)
            {
                order.Status = OrderStatus.NowServing;
                order.ReadyAt = DateTime.Now;
            }
            else if (order.Status == OrderStatus.NowServing)
            {
                order.Status = OrderStatus.Claimed;
                activeOrders.Remove(order);
            }

            Raise(OrderStatusChanged, order);
        }

        private void Raise(EventHandler<Order> handler, Order order)
        {
            if (handler != null) handler(this, order);
        }
    }
}
