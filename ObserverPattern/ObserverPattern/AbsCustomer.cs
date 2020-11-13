using System;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IObserver
    {
        Task Notify();
    }

    class AbsCustomer : IObserver
    {
        public string Email { get; private set; }

        public AbsCustomer(string email)
        {
            Email = email;
        }

        public async virtual Task Notify()
        {
            Console.WriteLine($"{Email}'a mail atıldı !");
        }
    }
}
