using ExtractComposite.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.ExtractComposite.MyWork
{
    [TestFixture]
    public class FormTagTests
    {
        private FormTag _formTag;
        
        [SetUp]
        public void Init()
        {
            _formTag = new FormTag();
        }
        
        [Test]
        public void it_should_output_a_non_html_formatted_text_representation()
        {
            _formTag.AddChild(new LabelTag(new StringNode("Hi, I'm A Label.")));
            _formTag.AddChild(new LabelTag(new StringNode("You're not the only one, I'm a Label too!")));
            
            Assert.That(_formTag.ToPlainTextString(), Is.EqualTo("Hi, I'm A Label.You're not the only one, I'm a Label too!"));
        }
    }
}