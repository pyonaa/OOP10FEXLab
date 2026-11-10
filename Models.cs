using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP10FEXLab
{
    public enum DiningOption { DineIn, TakeOut }

    public enum PaymentMethod { CashAtCounter, Card, EWallet }

    public enum OrderStatus { Preparing, NowServing, Claimed }

    public static class EnumText
    {
        public static string ToDisplay(this DiningOption dining)
        {
            return dining == DiningOption.TakeOut ? "Take Out" : "Dine In";
        }

        public static string ToDisplay(this PaymentMethod payment)
        {
            switch (payment)
            {
                case PaymentMethod.Card: return "Card";
                case PaymentMethod.EWallet: return "E-wallet";
                default: return "Cash";
            }
        }
    }

 
    public class MealPackage
    {
        public string Code { get; private set; }
        public string Category { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public MealPackage(string code, string category, string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentException("Meal code is required.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Meal name is required.");
            if (price < 0) throw new ArgumentException("Price cannot be negative.");

            Code = code.Trim();
            Category = string.IsNullOrWhiteSpace(category) ? "Others" : category.Trim();
            Name = name.Trim();
            Description = description == null ? "" : description.Trim();
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }

 
    public class CartItem
    {
        public MealPackage Meal { get; private set; }
        public int Quantity { get; private set; }
        public decimal Subtotal { get { return Meal.Price * Quantity; } }

        public CartItem(MealPackage meal, int quantity)
        {
            if (meal == null) throw new ArgumentNullException("meal");
            if (quantity < 1) throw new ArgumentException("Quantity must be at least 1.");
            Meal = meal;
            Quantity = quantity;
        }

        internal void ChangeQuantity(int amount)
        {
            Quantity += amount;
        }
    }

 
    public class Cart
    {
        private readonly List<CartItem> items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items { get { return items.AsReadOnly(); } }
        public decimal Total { get { return items.Sum(i => i.Subtotal); } }
        public int ItemCount { get { return items.Sum(i => i.Quantity); } }
        public bool IsEmpty { get { return items.Count == 0; } }

        public void Add(MealPackage meal)
        {
            CartItem existing = Find(meal);
            if (existing != null) existing.ChangeQuantity(1);
            else items.Add(new CartItem(meal, 1));
        }

        public void Decrease(MealPackage meal)
        {
            CartItem existing = Find(meal);
            if (existing == null) return;
            if (existing.Quantity > 1) existing.ChangeQuantity(-1);
            else items.Remove(existing);
        }

        public void Remove(MealPackage meal)
        {
            CartItem existing = Find(meal);
            if (existing != null) items.Remove(existing);
        }

        public void Clear()
        {
            items.Clear();
        }

        private CartItem Find(MealPackage meal)
        {
            return items.FirstOrDefault(i => i.Meal.Code == meal.Code);
        }
    }

  
    public class Order
    {
        private readonly List<CartItem> items;

        public int OrderNumber { get; private set; }
        public DateTime OrderedAt { get; private set; }
        public DiningOption Dining { get; private set; }
        public PaymentMethod Payment { get; private set; }
        public OrderStatus Status { get; internal set; }
        public DateTime? ReadyAt { get; internal set; }

        public IReadOnlyList<CartItem> Items { get { return items.AsReadOnly(); } }
        public decimal Total { get { return items.Sum(i => i.Subtotal); } }

        public Order(int orderNumber, DateTime orderedAt, DiningOption dining, PaymentMethod payment, IEnumerable<CartItem> cartItems)
        {
            OrderNumber = orderNumber;
            OrderedAt = orderedAt;
            Dining = dining;
            Payment = payment;
            Status = OrderStatus.Preparing;
            items = cartItems.Select(i => new CartItem(i.Meal, i.Quantity)).ToList();
        }
    }
}


