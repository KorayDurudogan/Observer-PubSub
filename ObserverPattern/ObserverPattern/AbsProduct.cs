using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObserverPattern
{
    abstract class AbsProduct
    {
        public IList<IObserver> observers = new List<IObserver>();

        public string Name { get; set; }

        private decimal _price { get; set; }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < _price)
                    NotifyObservers();
                _price = value;
            }
        }

        public AbsProduct(string name, decimal price)
        {
            Name = name;
            _price = price;
        }

        public void AddObserver(AbsCustomer customer) => observers.Add(customer);

        private void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                Task.Run(() => observer.Notify());
        }
    }
}
