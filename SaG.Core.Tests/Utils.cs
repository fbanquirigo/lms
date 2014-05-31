using System.Collections.Generic;
using Moq;
using SaG.Core.Events;

namespace SaG.Core.Tests
{
    public class Utils
    {
        public static IEnumerable<Mock<IEventSubscriber>> GenerateEventSubscribers(int count, MockBehavior behavior = MockBehavior.Default)
        {
            for (var i = 0; i < count; i++)
            {
                var subscriber = new Mock<IEventSubscriber>(behavior);
                yield return subscriber;
            }
        }
    }
}
