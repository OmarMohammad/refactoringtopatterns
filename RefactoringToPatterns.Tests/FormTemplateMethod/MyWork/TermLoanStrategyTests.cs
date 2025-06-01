using NUnit.Framework;
using System;
using FormTemplateMethod.MyWork;

namespace RefactoringToPatterns.FormTemplateMethod.MyWork
{
    [TestFixture()]
    public class TermLoanStrategy
    {
        private readonly int HIGH_RISK_TAKING = 5;
        private readonly double LOAN_AMOUNT = 10000.00;
        private readonly double TWO_DIGIT_PRECISION = 0.001;

        [Test()]
        public void test_term_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime maturity = November(20, 2006);

            Loan termLoan = Loan.NewTermLoan(LOAN_AMOUNT, start, maturity, HIGH_RISK_TAKING);
            termLoan.Payment(1000.00, November(20, 2004));
            termLoan.Payment(1000.00, November(20, 2005));
            termLoan.Payment(1000.00, November(20, 2006));

            var termStrategy = new CapitalStrategyTermLoan();

            Assert.Multiple(() => {
                Assert.That(termStrategy.Duration(termLoan), Is.EqualTo(20027).Within(TWO_DIGIT_PRECISION));
                Assert.That(termStrategy.Capital(termLoan), Is.EqualTo(6008100).Within(TWO_DIGIT_PRECISION));
            });
        }

        private static DateTime November(int dayOfMonth, int year)
        {
            return new DateTime(year, 11, dayOfMonth);
        }
    }
}