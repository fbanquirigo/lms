using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using StructureMapContainer = StructureMap.IContainer;

namespace SaG.Core.StructureMap.Tests
{
    [TestFixture]
    public class ContainerTests
    {  
        [Test]
        public void TestConstructor()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            var target = new Container(structureMapContainer.Object);
            Assert.That(target, Is.Not.Null);
        }

        [Test]
        public void TestConstructorNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new Container(null));
        }

        [Test]
        public void TestGetAllInstancesGeneric()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            var expected = new[] { 1, 2, 3 };
            structureMapContainer.Setup(s => s.GetAllInstances<int>()).Returns(expected);
            var target = new Container(structureMapContainer.Object);
            var actual = target.GetAllInstances<int>();
            CollectionAssert.AreEqual(actual, expected);   
        }

        [Test]
        public void TestGetAllInstances()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            var expected = new[] { 1, 2, 3 };
            structureMapContainer.Setup(s => s.GetAllInstances(typeof(int))).Returns(expected);
            var target = new Container(structureMapContainer.Object);
            IEnumerable<object> actual = target.GetAllInstances(typeof(int));
            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void TestGetAllInstancesNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    var structureMapContainer = new Mock<StructureMapContainer>();
                    var target = new Container(structureMapContainer.Object);
                    target.GetAllInstances(null);
                });
        }

        [Test]
        public void TestGetInstanceGeneric()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            const int expected = 2;
            structureMapContainer.Setup(s => s.GetInstance<int>()).Returns(expected);
            var target = new Container(structureMapContainer.Object);
            int actual = target.GetInstance<int>();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestGetInstance()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            const int expected = 2;
            structureMapContainer.Setup(s => s.GetInstance(typeof(int))).Returns(expected);
            var target = new Container(structureMapContainer.Object);
            object actual = target.GetInstance(typeof(int));
            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [Test]
        public void TestGetInstanceNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    var structureMapContainer = new Mock<StructureMapContainer>();
                    var target = new Container(structureMapContainer.Object);
                    target.GetInstance(null);
                });
        }

        [Test]
        public void TestTryGetInstanceGeneric()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            const int expected = 3;
            structureMapContainer.Setup(s => s.TryGetInstance<int>()).Returns(expected);
            var target = new Container(structureMapContainer.Object);
            int actual = target.TryGetInstance<int>();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestTryGetInstance()
        {
            var structureMapContainer = new Mock<StructureMapContainer>();
            const int expected = 3;
            structureMapContainer.Setup(s => s.TryGetInstance(typeof(int))).Returns(expected);
            var target = new Container(structureMapContainer.Object);
            object actual = target.TryGetInstance(typeof(int));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestTryGetInstanceNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    var structureMapContainer = new Mock<StructureMapContainer>();
                    var target = new Container(structureMapContainer.Object);
                    target.TryGetInstance(null);
                });
        }
    }   
}
