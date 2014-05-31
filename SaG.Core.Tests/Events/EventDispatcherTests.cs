using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using SaG.Core.Events;

namespace SaG.Core.Tests.Events
{
    [TestFixture]
    public class EventDispatcherTests
    {
        [Test]
        public void TestConstructor()
        {
            var container = new Mock<IContainer>();
            var target = new EventDispatcher(container.Object);
            Assert.That(target, Is.Not.Null);
        }

        [Test]
        public void TestConstructorNullContainer()
        {
            Assert.Throws<ArgumentNullException>(() => new EventDispatcher(null));
        }

        [Test]
        public void TestEventSubscriberEventInvocation()
        {
            var container = new Mock<IContainer>();
            var subscribers = Utils.GenerateEventSubscribers(3).ToList();
            const string eventName = "Test.Event1";

            container.Setup(c => c.GetAllInstances<IEventSubscriber>())
                .Returns(subscribers.Select(s => s.Object).ToList());
            subscribers.ForEach(subscriber => subscriber.Setup(handler =>
                    handler.Invoke(eventName, this, EventArgs.Empty)
                ).Verifiable());
            
            var target = new EventDispatcher(container.Object);
            target.RaiseEvent(eventName, this, EventArgs.Empty);    

            subscribers.ForEach(s => s.Verify(v => v.Invoke(eventName, this, EventArgs.Empty)));
        }

        [Test]
        public void TestEventSubscriberEventInvocationTwoTimes()
        {   
            var container = new Mock<IContainer>();
            var subscribers = Utils.GenerateEventSubscribers(3).ToList();
            const string eventName = "Test.Event1";

            container.Setup(c => c.GetAllInstances<IEventSubscriber>())
                .Returns(subscribers.Select(s => s.Object).ToList());
            subscribers.ForEach(subscriber => subscriber.Setup(handler =>
                    handler.Invoke(eventName, this, EventArgs.Empty)
                ).Verifiable());

            var target = new EventDispatcher(container.Object);
            target.RaiseEvent(eventName, this, EventArgs.Empty);
            target.RaiseEvent(eventName, this, EventArgs.Empty);  

            subscribers.ForEach(s => s.Verify(v => v.Invoke(eventName, this, EventArgs.Empty), Times.Exactly(2)));
        }
    }
}
