using NUnit.Framework;
using EncapsulateCompositeWithBuilder.MyWork;

namespace RefactoringToPatterns.EncapsulateCompositeWithBuilder.MyWork
{
    [TestFixture]
    public class TagNodeTests
    {
        private const string SamplePrice = "2.39";

        [Test]
        public void TestSimpleTagWithOneAttributeAndValue()
        {
            var expected =
                "<price currency=" +
                "'" +
                "USD" +
                "'>" +
                SamplePrice +
                "</price>";

            TagNode priceTag = new TagNode("price");
            priceTag.AddAttribute("currency", "USD");
            priceTag.AddValue(SamplePrice);
            Assert.That(expected, Is.EqualTo(priceTag.ToString()));
        }

        [Test]
        public void TestCompositeTagoneChild()
        {
            var expected =
                "<product>" +
                    "<price>" +
                    "</price>" +
                "</product>"; 

            TagNode productTag = new TagNode("product");
            productTag.Add(new TagNode("price"));

            Assert.That(expected, Is.EqualTo(productTag.ToString()));
        }

        [Test]
        public void TestAddingChildrenAndGrandChildren()
        {
            var expected =
                "<orders>" +
                    "<order>" +
                        "<product>" +
                        "</product>" +
                    "</order>" +
                "</orders>";

            TagNode ordersTag = new TagNode("orders");
            TagNode orderTag = new TagNode("order");
            orderTag.Add(new TagNode("product"));
            ordersTag.Add(orderTag);

            Assert.That(orderTag.ToString(), Is.EqualTo(expected));
        }
    }
}
