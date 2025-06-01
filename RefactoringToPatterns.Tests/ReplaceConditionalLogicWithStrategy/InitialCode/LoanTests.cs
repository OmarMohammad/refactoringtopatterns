using System;
using NUnit.Framework;
using ReplaceConditionalLogicWithStrategy.InitialCode;

namespace RefactoringToPatterns.ReplaceConditionalLogicWithStrategy.InitialCode
{
    [TestFixture()]
    public class LoanTests
    {
        private readonly int LOW_RISK_TAKING = 2;
        private readonly int HIGH_RISK_TAKING = 5;
        private readonly double LOAN_AMOUNT = 10000.00;
        private readonly double TWO_DIGIT_PRECISION = 0.001;

        [SetUp]
        public void Init() {

        }

        [Test()]
        public void test_term_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime maturity = November(20, 2006);

			Loan termLoan = Loan.NewTermLoan(LOAN_AMOUNT, start, maturity, HIGH_RISK_TAKING);
            termLoan.Payment(1000.00, November(20, 2004));
            termLoan.Payment(1000.00, November(20, 2005));
            termLoan.Payment(1000.00, November(20, 2006));

            Assert.Multiple(() => {
                Assert.That(termLoan.Duration(), Is.EqualTo(20027).Within(TWO_DIGIT_PRECISION));
                Assert.That(termLoan.Capital(), Is.EqualTo(6008100).Within(TWO_DIGIT_PRECISION));
            });
        }

        [Test()]
        public void test_revolver_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime expiry = November(20, 2007);

            Loan revolverLoan = Loan.NewRevolver(LOAN_AMOUNT, start, expiry, HIGH_RISK_TAKING);
            revolverLoan.Payment(1000.00, November(20, 2004));
            revolverLoan.Payment(1000.00, November(20, 2005));
            revolverLoan.Payment(1000.00, November(20, 2006));

            Assert.Multiple(() => {
                Assert.That(revolverLoan.Capital(), Is.EqualTo(4002700).Within(TWO_DIGIT_PRECISION));
                Assert.That(revolverLoan.Duration(), Is.EqualTo(40027).Within(TWO_DIGIT_PRECISION));
            });
        }

        [Test()]
        public void test_advised_line_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime maturity = November(20, 2006);
            DateTime expiry = November(20, 2007);

            Loan advisedLineLoan = Loan.NewAdvisedLine(LOAN_AMOUNT, start, expiry, LOW_RISK_TAKING);
            advisedLineLoan.Payment(1000.00, November(20, 2004));
            advisedLineLoan.Payment(1000.00, November(20, 2005));
            advisedLineLoan.Payment(1000.00, November(20, 2006));

            Assert.Multiple(() => {
                Assert.That(advisedLineLoan.Duration(), Is.EqualTo(40027).Within(TWO_DIGIT_PRECISION));
                Assert.That(advisedLineLoan.Capital(), Is.EqualTo(1200810).Within(TWO_DIGIT_PRECISION));
            });
        }

        private static DateTime November(int dayOfMonth, int year)
        {
            return new DateTime(year, 11, dayOfMonth);
        }
    }
}