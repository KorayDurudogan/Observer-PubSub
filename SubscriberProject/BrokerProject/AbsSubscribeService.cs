using System;
using System.Collections.Generic;

namespace BrokerProject
{
    public abstract class AbsSubscribeService
    {
        private List<string> subscribedEmails = new List<string>();

        public void Subscribe(string email) => subscribedEmails.Add(email);

        public void Notify()
        {
            //subscribedEmails listindeki tum e-maillere notify atilir.
        }
    }

    public class LaptopSubscribeService : AbsSubscribeService
    {

    }

    public class PhoneSubscribeService : AbsSubscribeService
    {

    }

    public static class Factory
    {
        private static PhoneSubscribeService phoneService;

        private static LaptopSubscribeService laptopService;

        public static AbsSubscribeService Create(string device)
        {
            switch (device)
            {
                case "phone":
                    if (phoneService == null)
                        phoneService = new PhoneSubscribeService();
                    return phoneService;
                case "laptop":
                    if (laptopService == null)
                        laptopService = new LaptopSubscribeService();
                    return laptopService;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
