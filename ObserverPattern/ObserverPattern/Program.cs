using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("koray.durudogan@outlook.com");
            var customer2 = new Customer("ted.mosby@gmail.com");
            var customer3 = new Customer("marshall.eriksen@hesapkurdu.com");
            var customer4 = new Customer("lily.aldrin@hesapkurdu.com");
            var customer5 = new Customer("robin.scherbatsky@hesapkurdu.com");
            var customer6 = new Customer("barney.stinson@hesapkurdu.com");

            var phone = new Product("IPhone", 10000);
            phone.AddObserver(customer);
            phone.AddObserver(customer2);
            phone.AddObserver(customer3);
            phone.AddObserver(customer4);
            phone.AddObserver(customer5);
            phone.AddObserver(customer6);

            //Observerlari haberdar edecek fiyat dususu.
            phone.Price = 9000;

            Console.ReadKey();
        }
    }
}
