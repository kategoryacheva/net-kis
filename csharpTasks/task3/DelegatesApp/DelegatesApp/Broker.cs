using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{    
    // Класс брокера, который торгует акциями
    public class Broker : ISubscriber
    {
        private int brokerMoney;
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        private Dictionary<string, int> Shares = new Dictionary<string, int>();
        public Broker(int money = 1000)
        {
            brokerMoney = money;
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(Market sender, MarketEventArgs args)
        {
            int count;
            Shares.TryGetValue(args.CompanyName, out count);

            if (brokerMoney > 100)
                sender.Buy(args.CompanyName, ref count, ref brokerMoney);
            else
                sender.Sell(args.CompanyName, ref count, ref brokerMoney);

            Shares[args.CompanyName] = count;
        }
    }

    public class GoogleBroker : ISubscriber
    {
        private int brokerMoney;
        // устанавливаем деньги брокера        
        // Как хранить купленные акции - решайте сами
        private Dictionary<string, int> Shares = new Dictionary<string, int>();
        public GoogleBroker(int money = 1000)
        {
            brokerMoney = money;
        }

        // Тут логика такая: с биржи прилетает обновление. Брокер может либо продать акции, либо купить  
        // При покупке или продаже брокер передает ссылку на свои счета, а биржа должна сама все высавить
        public void Notified(Market sender, MarketEventArgs args)
        {
            if (args.CompanyName == "Google")
            {
                int count;
                Shares.TryGetValue(args.CompanyName, out count);

                if (brokerMoney > 100)
                    sender.Buy(args.CompanyName, ref count, ref brokerMoney);
                else
                    sender.Sell(args.CompanyName, ref count, ref brokerMoney);

                Shares[args.CompanyName] = count;
            }
        }
    }

}
