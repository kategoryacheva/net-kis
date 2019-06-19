using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{
    // Интерфейс подписчика на изменения цен в акциях
    public interface ISubscriber
    {
        void Notified(Market sender, MarketEventArgs args);
    }

    public class MarketEventArgs
    {
        /*Здесь можно добавить что угодно, цену, название компании и т.п.*/
        public string CompanyName { get; }
        public int Price { get; }

        public MarketEventArgs(string name = "None", int price = 0)
        {
            CompanyName = name;
            Price = price;
        }

    }

    // Биржа, торгующая акциями
    public class Market
    {
        public delegate void MarketDelegate(Market sender, MarketEventArgs args);
        public event MarketDelegate Notify;

        public Dictionary<string, int> Shares { get; }
        // Устанавливаем цены акций, хз как правильно они называются
        // В параметр передаем список имен акций
        public Market(string[] shares)
        {
            Shares = new Dictionary<string, int>();
            Random rnd = new Random();
            foreach (var share in shares)
            {
                Shares.Add(share, rnd.Next(100, 1000));
            }
        }
        // Добавляет подписчика
        public void AddSubscriber(ISubscriber sub)
        {
            Notify += sub.Notified;
        }

        /// <summary>
        /// Gets random key name from dictionary
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public string GetRandomShareName(Dictionary<string, int> dict)
        {
            Random r = new Random();
            List<string> list = new List<string>(dict.Keys);
            return list[r.Next(dict.Count)];
        }

        // Запускает ход торгов (устанавливает цену акциям) и уведомляет подписчиков
        public void Trade()
        {
            // При реализации можно взять рандомную акцию, выставить у неё цену (тоже рандомно в некоторых пределах)
            // и проинформировать подписчиков
            Random r = new Random();
            string shareName = GetRandomShareName(Shares);
            Shares[shareName] = r.Next(100, 1000);

            MarketEventArgs arg = new MarketEventArgs(shareName, Shares[shareName]);
            Notify(this, arg);
        }
        
        /// <summary>
        /// Покупка акций
        /// </summary>
        /// <param name="shareName">Имя акции</param>
        /// <param name="count">Ссылка на акции брокера</param>
        /// <param name="account">Ссылка на счет брокера</param>
        public void Buy(string shareName, ref int count, ref int account)
        {
            // Покупка акций 
            // Биржа сама должна из одного мметса вычесть, в другое прибавить
            if (account >= Shares[shareName])
            {
                count++;
                account -= Shares[shareName];
            }
        }


        public void Sell(string shareName, ref int count, ref int account)
        {
            // Продажа 
            if (count > 0)
            {
                count--;
                account += Shares[shareName];
            }
        }
    }
}
