﻿using NUnit.Framework;
using System;
using ReplaceConditionalLogicWithStrategy.InitialCode;

namespace RefactoringToPatterns.ReplaceConditionalLogicWithStrategy.InitialCode
{
    [TestFixture()]
    public class PaymentTests
    {
        private Payment _payment;
        private DateTime _christmasDay;

        [SetUp]
        public void Init()
        {
            _christmasDay = new DateTime(2010, 12, 25);
            _payment = new Payment(1000.0, _christmasDay);
        }

        [Test()]
        public void payment_is_constructed_correctly()
        {
            
            Assert.Multiple(() => {
                Assert.That(_payment.Amount, Is.EqualTo(1000));
                Assert.That(_payment.Date, Is.EqualTo(_christmasDay));
            });

        }
    }
}
