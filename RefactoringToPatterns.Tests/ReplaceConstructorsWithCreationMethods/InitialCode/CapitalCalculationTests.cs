﻿﻿using NUnit.Framework;
using System;
using ReplaceConstructorsWithCreationMethods.InitialCode;

namespace RefactoringToPatterns.ReplaceConstructorsWithCreationMethods.InitialCode
{
    [TestFixture]
    public class CapitalCalculationTests
    {
        private readonly DateTime? _maturity = new DateTime(2020, 10, 2);
        private readonly DateTime? _expiry = new DateTime(2021, 10, 2);

        private const double Commitment = 3.0;
        private const double Outstanding = 12.9;
        private RiskAdjustedCapitalStrategy _riskAdjustedCapitalStrategy = 
            new RiskAdjustedCapitalStrategy();
        const int RiskRating = 5;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void test_term_loan_no_payments()
        {
            Loan loan = new Loan(Commitment, RiskRating, _maturity);
            Assert.That(loan.CapitalStrategy, Is.InstanceOf<CapitalStrategyTermLoan>());
        }

        [Test]
        public void test_term_loan_one_payment()
        {
            Loan loan = new Loan(Commitment, RiskRating, _maturity);
            Assert.That(loan.CapitalStrategy, Is.InstanceOf<CapitalStrategyTermLoan>());
        }

        [Test]
        public void test_revolver_loan_no_payments()
        {
            Loan loan = new Loan(Commitment, RiskRating, null, _expiry);
            Assert.That(loan.CapitalStrategy, Is.InstanceOf<CapitalStrategyRevolver>());
        }

        [Test]
        public void test_RCTL_loan_one_payment()
        {
            Loan loan = new Loan(Commitment, Outstanding, RiskRating, _maturity, _expiry);
            Assert.That(loan.CapitalStrategy, Is.InstanceOf<CapitalStrategyRCTL>());
        }

        [Test]
        public void test_term_loan_with_risk_adjusted_capital_strategy() {
            Loan loan = new Loan(_riskAdjustedCapitalStrategy, 
                                 Commitment, Outstanding, RiskRating, 
                                 _maturity, null);
            
            Assert.That(loan.CapitalStrategy, Is.InstanceOf<RiskAdjustedCapitalStrategy>());
        }
    }
}