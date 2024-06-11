using ClassLibraryBankCards;
using LibraryLab12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14LAB2EX
{
    public class CardQueries
    {
        // Карты, со сроком действия больше 2025 LINQ (Where)
        public static IEnumerable<BankCard> WhereQuery(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            Console.WriteLine("Карты, срок действия которых больше 2025 года:");
            var result = from item in collection
                         where item.Date > 2025
                         select item;
            PrintResult(result);
            return result;
        }


        // Карты, со сроком действия больше 2025 с использованием методов расширения (Where)
        public static IEnumerable<BankCard> WhereQueryUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            Console.WriteLine("Карты, срок действия которых больше 2025 года:");
            var result = collection.Where(item => item.Date > 2025);
            PrintResult(result);
            return result;
        }

        //Количество карт со сроком до 2026 года LINQ (Count)
        public static int CountCardsWithYear(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            var count = (from card in collection
                         where card is BankCard && card.Date == 2026
                         select card).Count();
            Console.WriteLine($"Количество карт со сроком 2026: {count}");
            return count;
        }

        //Количество карт со сроком до 2026 года LINQ (Count)
        public static int CountCardsWithUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            var count = collection
                .Count(card => card is BankCard && card.Date == 2026);
            Console.WriteLine($"Количество карт со сроком 2026: {count}");
            return count;
        }


        //Сумма баланса по дебетовым картам метод расширения (Sum)
        public static double SumOfDebitCardBalances(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            var result = (from card in collection
                          where card is DebitCard
                          select ((DebitCard)card).Balance).Sum();
            Console.WriteLine($"Сумма баланса по дебетовым картам: {result}");
            return result;
        }

        //Сумма баланса по дебетовым картам метод расширения (Sum)
        public static double SumOfDebitUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            var result = collection.Where(card => card is DebitCard).Sum(card => ((DebitCard)card).Balance);
            Console.WriteLine($"Сумма баланса по дебетовым картам: {result}");
            return result;
        }


        //Максимальный срок погашения кредитной карты LINQ(Max)
        public static int MaxCreditCardExpirationDate(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            var result = (from card in collection
                          where card is CreditCard
                          select ((CreditCard)card).RepaymentTerm).Max();
            Console.WriteLine($"Максимальный срок погашения кредитной карты: {result}");
            return result;
        }

        //Максимальный срок погашения кредитной карты метод расширения(Max)
        public static int MaxCreditUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            var result = collection.Where(card => card is CreditCard).Max(card => ((CreditCard)card).RepaymentTerm);
            Console.WriteLine($"Максимальный срок погашения кредитной карты: {result}");
            return result;
        }

        //Минимальный кэшбек по молодёжным картам LINQ (Min)
        public static double MinCashbackForYouthCards(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            var result = (from card in collection
                          where card is YouthCard
                          select ((YouthCard)card).Cashback).Min();
            Console.WriteLine($"Минимальный кэшбэк по молодёжным картам: {result}");
            return result;
        }

        // Минимальный кэшбек по молодёжным картам метод расширения (Min)
        public static double MinCashbackUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            var result = collection.Where(card => card is YouthCard).Min(card => ((YouthCard)card).Cashback);
            Console.WriteLine($"Минимальный кэшбэк по молодёжным картам: {result}");
            return result;
        }

        // Средний лимит по кредитным картам LINQ (Average)
        public static double AverageCreditCardLimit(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            var result = (from card in collection
                          where card is CreditCard
                          select ((CreditCard)card).Limit).Average();
            Console.WriteLine($"Средний лимит по кредитным картам: {result}");
            return result;
        }

        //Средний лимит по кредитным картам метод расширения (Average)
        public static double AverageCreditUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            var result = collection
                         .Where(card => card is CreditCard)
                         .Average(card => ((CreditCard)card).Limit);
            Console.WriteLine($"Средний лимит по кредитным картам: {result}");
            return result;
        }

        //Группировка молодёжных карт по кэшбеку > или < 50 LINQ (Group by)
        public static IEnumerable<YouthCardGroup> GroupYouthCardsByCashback(MyCollection<BankCard> collection)
        {
            Console.WriteLine("LINQ-запрос");
            var result = from card in collection
                         where card is YouthCard
                         group card by ((YouthCard)card).Cashback > 50 into cashbackGroup
                         select new YouthCardGroup
                         {
                             IsHighCashback = cashbackGroup.Key,
                             Cards = cashbackGroup.ToList(),
                             Count = cashbackGroup.Count()
                         };
            PrintYouthCardGroups(result);
            return result;
        }

        //Группировка молодёжных карт по кэшбеку > или < 50 метод расширения (Group by)
        public static IEnumerable<YouthCardGroup> GroupYouthUsingExtensions(MyCollection<BankCard> collection)
        {
            Console.WriteLine("Метод расширения");
            var result = collection
                         .Where(card => card is YouthCard)
                         .GroupBy(card => ((YouthCard)card).Cashback > 50)
                         .Select(group => new YouthCardGroup
                         {
                             IsHighCashback = group.Key,
                             Cards = group.ToList(),
                             Count = group.Count()
                         });
            PrintYouthCardGroups(result);
            return result;
        }


        //Вспомогательный метод
        public static void PrintYouthCardGroups(IEnumerable<dynamic> result)
        {
            foreach (var group in result)
            {
                Console.WriteLine(group.IsHighCashback ? "Молодёжные карты с кэшбэком больше 50%:" : "Молодёжные карты с кэшбэком 50% и менее:");
                Console.WriteLine($"Количество карт: {group.Count}");
                foreach (var card in group.Cards)
                {
                    Console.WriteLine($"Карта: {card.Owner}, Кэшбэк: {card.Cashback}%");
                }
            }
        }

        // Вспомогательный метод для вывода результатов запросов
        public static void PrintResult(IEnumerable<BankCard> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
