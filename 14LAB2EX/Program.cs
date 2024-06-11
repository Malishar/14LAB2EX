using LibraryLab12;
using ClassLibraryBankCards;
namespace _14LAB2EX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<BankCard> myCollection = new MyCollection<BankCard>(12);
            for (int i = 0; i < 3; i++)
            {
                BankCard card = new BankCard();
                card.RandomInit();
                myCollection.Add(card);
            }

            for (int i = 0; i < 3; i++)
            {
                CreditCard card = new CreditCard();
                card.RandomInit();
                myCollection.Add(card);
            }

            //for (int i = 0; i < 3; i++)
            //{
            //    DebitCard card = new DebitCard();
            //    card.RandomInit();
            //    myCollection.Add(card);
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    //YouthCard card = new YouthCard();
            //    //card.RandomInit();
            //    //myCollection.Add(card);
            //}

            int answer = 1;
            while (answer != 9)
            {
                try
                {
                    //Console.WriteLine("\nМеню:\n");
                    //Console.WriteLine("1. Распечатать коллекцию:");
                    //Console.WriteLine("2. Карты, со сроком действия больше 2025 (выборка данных Where)");
                    //Console.WriteLine("3. Количество карт со сроком до 2026 года (Count)");
                    //Console.WriteLine("4. Сумма баланса по дебетовым картам (Sum)");
                    //Console.WriteLine("5. Максимальный срок погашения кредитной карты (Max)");
                    //Console.WriteLine("6. Минимальный кэшбек по молодёжным картам (Min)");
                    //Console.WriteLine("7. Средний лимит по кредитным картам (Average)");
                    //Console.WriteLine("8. Группировка молодёжных карт по кэшбеку > или < 50 (Group by)");
                    //Console.WriteLine("9. Выход");

                    //Console.Write("Выберите вариант: \n");
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            //Console.WriteLine("Ваша коллекция:\n");
                            //CardQueries.PrintResult(myCollection);
                            break;
                        case 2:
                            CardQueries.WhereQuery(myCollection);
                            CardQueries.WhereQueryUsingExtensions(myCollection);
                            break;
                        case 3:
                            //CardQueries.CountCardsWithYear(myCollection);
                            //CardQueries.CountCardsWithUsingExtensions(myCollection);
                            break;
                        case 4:
                            CardQueries.SumOfDebitCardBalances(myCollection);
                            CardQueries.SumOfDebitUsingExtensions(myCollection);
                            break;
                        case 5:
                            CardQueries.MaxCreditCardExpirationDate(myCollection);
                            CardQueries.MaxCreditUsingExtensions(myCollection);
                            break;
                        case 6:
                            //CardQueries.MinCashbackForYouthCards(myCollection);
                            //CardQueries.MinCashbackUsingExtensions(myCollection);
                            break;
                        case 7:
                            CardQueries.AverageCreditCardLimit(myCollection);
                            CardQueries.AverageCreditUsingExtensions(myCollection);
                            break;
                        case 8:
                            //CardQueries.GroupYouthCardsByCashback(myCollection);
                            //CardQueries.GroupYouthUsingExtensions(myCollection);
                            break;
                        case 9:
                            Console.WriteLine("Программа завершена");
                            break;
                        default:
                            //Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
    }
}