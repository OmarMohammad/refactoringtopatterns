using NUnit.Framework;
using EncapsulateClassesWithFactory.MyWork.Descriptors;
using EncapsulateClassesWithFactory.MyWork.Mappers;
using System.Collections.Generic;

namespace RefactoringToPatterns.EncapsulateClassesWithFactory.MyWork.Mappers
{
    [TestFixture]
    public class DescriptorMapperTests
    {
        TestingDescriptorMapper testDescriptorMapper;

		[SetUp]
        public void Init()
        {
            testDescriptorMapper = new TestingDescriptorMapper();
        }

        [Test]
        public void it_maps_remoteId_descriptor_as_DefaultDescriptor()
        {
            var remoteIdDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("remoteId");
            
            Assert.That(remoteIdDescriptor, Is.InstanceOf<DefaultDescriptor>());
        }

        [Test]
		public void it_maps_createdDate_descriptor_as_DefaultDescriptor()
		{
			var createdDateDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("createdDate");
            
		    Assert.That(createdDateDescriptor, Is.InstanceOf<DefaultDescriptor>());
        }

		[Test]
		public void it_maps_lastChangedDate_descriptor_as_DefaultDescriptor()
		{
			var lastChangedDateDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("lastChangedDate");
            
		    Assert.That(lastChangedDateDescriptor, Is.InstanceOf<DefaultDescriptor>());
        }

		[Test]
		public void it_maps_createdBy_descriptor_as_ReferenceDescriptor()
		{
            var createdByDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("createdBy");
            
		    Assert.That(createdByDescriptor, Is.InstanceOf<ReferenceDescriptor>());
        }

		[Test]
		public void it_maps_lastChangedBy_descriptor_ReferenceDescriptor()
		{
			var lastChangedByDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("lastChangedBy");
            
		    Assert.That(lastChangedByDescriptor, Is.InstanceOf<ReferenceDescriptor>());
        }

		[Test]
		public void it_maps_optimisticLockVersion_descriptor_as_DefaultDescriptor()
		{
			var optimisticLockVersionDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("optimisticLockVersion");
            
			Assert.That(optimisticLockVersionDescriptor, Is.InstanceOf<DefaultDescriptor>());
        }

		[Test]
		public void it_does_not_map_unknown_descriptors()
		{
            var unknownDescriptor = 
                testDescriptorMapper.GetMappedDescriptorFor("unknown");
            
            Assert.That(unknownDescriptor, Is.Null);
		}
    }

    internal class TestingDescriptorMapper : DescriptorMapper {
        List<AttributeDescriptor> descriptors;

        public TestingDescriptorMapper() {
            descriptors = CreateAttributeDescriptors();
        }

		public AttributeDescriptor GetMappedDescriptorFor(string descriptorName)
		{
			return descriptors.Find(descriptor => descriptor.DescriptorName == descriptorName);
		}
    }
}

