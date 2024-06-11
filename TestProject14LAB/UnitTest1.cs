using LibraryLab12;
using ClassLibraryBankCards;
using _14LAB2EX;

namespace TestProject14LAB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhereQuery_Returns_Cards_With_Expiry_Date_After_2025()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new BankCard { Number = "1000", Owner = "Геннадий Борисов", Date = 2026 },
                new BankCard { Number = "2000", Owner = "Сергей Борисов", Date = 2024 }
            };

            // Act
            var result = CardQueries.WhereQuery(collection);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.All(card => card.Date > 2025));
        }

        [TestMethod]
        public void WhereQuery_Returns_Empty_List_When_No_Cards_Are_After_2025()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new BankCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2024 }
            };

            // Act
            var result = CardQueries.WhereQuery(collection);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void WhereQueryUsingExtensions_Returns_Cards_With_Expiry_Date_After_2025()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new BankCard { Number = "1000", Owner = "Геннадий Борисов", Date = 2026 },
                new BankCard { Number = "2000", Owner = "Сергей Борисов", Date = 2024 }
            };

            // Act
            var result = CardQueries.WhereQueryUsingExtensions(collection);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.All(card => card.Date > 2025));
        }

        [TestMethod]
        public void WhereQueryUsingExtensions_Returns_Empty_List_When_No_Cards_Are_After_2025()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new BankCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2024 }
            };

            // Act
            var result = CardQueries.WhereQueryUsingExtensions(collection);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void CountCardsWithYear_Returns_Correct_Count()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new BankCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026 },
                new BankCard { Number = "1000", Owner = "Геннадий Борисов", Date = 2026 },
                new BankCard { Number = "2000", Owner = "Сергей Борисов", Date = 2025 }
            };

            // Act
            int count = CardQueries.CountCardsWithYear(collection);

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void CountCardsWithUsingExtensions_Returns_Correct_Count()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new BankCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026 },
                new BankCard { Number = "1000", Owner = "Геннадий Борисов", Date = 2026 },
                new BankCard { Number = "2000", Owner = "Сергей Борисов", Date = 2025 }
            };

            // Act
            int count = CardQueries.CountCardsWithUsingExtensions(collection);

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void SumOfDebitCardBalances_ReturnsCorrectSum()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new DebitCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, Balance = 100 },
                new DebitCard { Number = "1000", Owner = "Геннадий Борисов", Date = 2026, Balance = 200 },
                new DebitCard { Number = "2000", Owner = "Сергей Борисов", Date = 2025, Balance = 400 }
            };

            // Act
            var sum = CardQueries.SumOfDebitCardBalances(collection);

            // Assert
            Assert.AreEqual(700, sum); // Expected sum of balances of debit cards
        }

        [TestMethod]
        public void SumOfDebitCardBalancesUsingExtensions_ReturnsCorrectSum()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                new DebitCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, Balance = 100 },
                new DebitCard { Number = "1000", Owner = "Геннадий Борисов", Date = 2026, Balance = 200 },
                new DebitCard { Number = "2000", Owner = "Сергей Борисов", Date = 2025, Balance = 400 }
            };

            // Act
            var sum = CardQueries.SumOfDebitUsingExtensions(collection);

            // Assert
            Assert.AreEqual(700, sum); // Expected sum of balances of debit cards
        }

        [TestMethod]
        public void MaxCreditCardExpirationDate_ShouldReturnMaxTerm()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                // Add CreditCards with different RepaymentTerms
                new CreditCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, RepaymentTerm = 10 },
                new CreditCard { Number = "4200", Owner = "Геннадий Никитин", Date = 2025, RepaymentTerm = 20 },
                new CreditCard { Number = "4300", Owner = "Геннадий Иванов", Date = 2027, RepaymentTerm = 15 }
            };

            // Act
            var result = CardQueries.MaxCreditCardExpirationDate(collection);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void MaxCreditUsingExtensions_ShouldReturnMaxTerm()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                // Add CreditCards with different RepaymentTerms
                new CreditCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, RepaymentTerm = 10 },
                new CreditCard { Number = "4200", Owner = "Геннадий Никитин", Date = 2025, RepaymentTerm = 20 },
                new CreditCard { Number = "4300", Owner = "Геннадий Иванов", Date = 2027, RepaymentTerm = 15 }
            };

            // Act
            var result = CardQueries.MaxCreditUsingExtensions(collection);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void MinCashbackForYouthCards_ShouldReturnMinCashback()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                // Add YouthCards with different cashback values
                new YouthCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, Cashback = 0.5 },
                new YouthCard { Number = "4200", Owner = "Геннадий Никитин", Date = 2025, Cashback = 0.2 },
                new YouthCard { Number = "4300", Owner = "Геннадий Иванов", Date = 2027, Cashback = 0.1 }
            };

            // Act
            var result = CardQueries.MinCashbackForYouthCards(collection);

            // Assert
            Assert.AreEqual(0.1, result);
        }

        public void MinCashbackUsingExtensions_ShouldReturnMinCashback()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                // Add YouthCards with different cashback values
                new YouthCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, Cashback = 0.5 },
                new YouthCard { Number = "4200", Owner = "Геннадий Никитин", Date = 2025, Cashback = 0.2 },
                new YouthCard { Number = "4300", Owner = "Геннадий Иванов", Date = 2027, Cashback = 0.1 }
            };

            // Act
            var result = CardQueries.MinCashbackUsingExtensions(collection);

            // Assert
            Assert.AreEqual(0.1, result);
        }

        [TestMethod]
        public void AverageCreditCardLimit_ShouldReturnAverageLimit()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                // Add CreditCards with different limits
                new CreditCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, Limit = 1000 },
                new CreditCard { Number = "4200", Owner = "Геннадий Никитин", Date = 2025, Limit = 2000 },
                new CreditCard { Number = "4300", Owner = "Геннадий Иванов", Date = 2027, Limit = 3000 }
            };

            // Act
            var result = CardQueries.AverageCreditCardLimit(collection);

            // Assert
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public void AverageCreditUsingExtensions_ShouldReturnAverageLimit()
        {
            // Arrange
            var collection = new MyCollection<BankCard>
            {
                // Add CreditCards with different limits
                new CreditCard { Number = "4000", Owner = "Геннадий Харитонов", Date = 2026, Limit = 1000 },
                new CreditCard { Number = "4200", Owner = "Геннадий Никитин", Date = 2025, Limit = 2000 },
                new CreditCard { Number = "4300", Owner = "Геннадий Иванов", Date = 2027, Limit = 3000 }
            };

            // Act
            var result = CardQueries.AverageCreditUsingExtensions(collection);

            // Assert
            Assert.AreEqual(2000, result);
        }


        [TestMethod]
        public void GroupYouthCardsByCashback_ShouldReturnEmpty_WhenNoYouthCards()
        {
            // Arrange
            var cards = new MyCollection<BankCard>
        {
            new CreditCard { Number = "123", Owner = "Alice", Limit = 5000, RepaymentTerm = 2027 },
            new DebitCard { Number = "124", Owner = "Bob", Balance = 3000, Date = 2025 }
        };

            // Act
            var result = CardQueries.GroupYouthCardsByCashback(cards);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GroupYouthUsingExtensions_ShouldReturnEmpty_WhenNoYouthCards()
        {
            // Arrange
            var cards = new MyCollection<BankCard>
        {
            new CreditCard { Number = "123", Owner = "Alice", Limit = 5000, RepaymentTerm = 2027 },
            new DebitCard { Number = "124", Owner = "Bob", Balance = 3000, Date = 2025 }
        };

            // Act
            var result = CardQueries.GroupYouthUsingExtensions(cards);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GroupYouthCardsByCashback_ShouldGroupCorrectly()
        {
            // Arrange
            var cards = new MyCollection<BankCard>
        {
            new YouthCard { Number = "123", Owner = "Alice", Cashback = 60, Date = 2027 },
            new YouthCard { Number = "124", Owner = "Bob", Cashback = 30, Date = 2027 },
            new YouthCard { Number = "125", Owner = "Charlie", Cashback = 70, Date = 2027 },
            new YouthCard { Number = "126", Owner = "David", Cashback = 20, Date = 2027 },
        };

            // Act
            var result = CardQueries.GroupYouthCardsByCashback(cards).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);

            var highCashbackGroup = result.FirstOrDefault(g => g.IsHighCashback);
            Assert.IsNotNull(highCashbackGroup);
            Assert.AreEqual(2, highCashbackGroup.Count);
            Assert.IsTrue(highCashbackGroup.Cards.Any(c => c.Number == "123"));
            Assert.IsTrue(highCashbackGroup.Cards.Any(c => c.Number == "125"));

            var lowCashbackGroup = result.FirstOrDefault(g => !g.IsHighCashback);
            Assert.IsNotNull(lowCashbackGroup);
            Assert.AreEqual(2, lowCashbackGroup.Count);
            Assert.IsTrue(lowCashbackGroup.Cards.Any(c => c.Number == "124"));
            Assert.IsTrue(lowCashbackGroup.Cards.Any(c => c.Number == "126"));
        }

        [TestMethod]
        public void GroupYouthUsingExtensions_ShouldGroupCorrectly()
        {
            // Arrange
            var cards = new MyCollection<BankCard>
        {
            new YouthCard { Number = "123", Owner = "Alice", Cashback = 60, Date = 2027 },
            new YouthCard { Number = "124", Owner = "Bob", Cashback = 30, Date = 2027 },
            new YouthCard { Number = "125", Owner = "Charlie", Cashback = 70, Date = 2027 },
            new YouthCard { Number = "126", Owner = "David", Cashback = 20, Date = 2027 },
        };

            // Act
            var result = CardQueries.GroupYouthUsingExtensions(cards).ToList();

            // Assert
            Assert.AreEqual(2, result.Count);

            var highCashbackGroup = result.FirstOrDefault(g => g.IsHighCashback);
            Assert.IsNotNull(highCashbackGroup);
            Assert.AreEqual(2, highCashbackGroup.Count);
            Assert.IsTrue(highCashbackGroup.Cards.Any(c => c.Number == "123"));
            Assert.IsTrue(highCashbackGroup.Cards.Any(c => c.Number == "125"));

            var lowCashbackGroup = result.FirstOrDefault(g => !g.IsHighCashback);
            Assert.IsNotNull(lowCashbackGroup);
            Assert.AreEqual(2, lowCashbackGroup.Count);
            Assert.IsTrue(lowCashbackGroup.Cards.Any(c => c.Number == "124"));
            Assert.IsTrue(lowCashbackGroup.Cards.Any(c => c.Number == "126"));
        }
    }
}