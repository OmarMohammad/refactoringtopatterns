using MoveAccumulationToCollectingParameter.InitialCode;
using NUnit.Framework;

namespace RefactoringToPatterns.MoveAccumulationToCollectingParameter.InitialCode
{
    [TestFixture]
    public class TagNodeTests
    {
        private TagNode _tagNode;

        [SetUp]
        public void Context()
        {
            _tagNode = new TagNode("parent", "gender='female'", "Jennifer");
        }
        
        [Test]
        public void Should_Give_A_String_Representation()
        {
            var expected = "<parent gender='female'>Jennifer</parent>";
            
            Assert.That(_tagNode.ToString(), Is.EqualTo(expected));
        }
        
        [Test]
        public void Adding_A_Child_Node_Should_Get_Included_In_Its_String_Representation()
        {
            var expected = "<parent gender='female'>Jennifer" + 
                                    "<child gender='male'>John</child>" + 
                                  "</parent>";
            _tagNode.Add(new TagNode("child", "gender='male'", "John"));
            
            Assert.That(_tagNode.ToString(), Is.EqualTo(expected));
        }
    }
}