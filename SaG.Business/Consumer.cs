using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaG.Business
{
    public class Consumer : IConsumer
    {
        public string ApplicatioName { get; private set; }

        public string ConsumerId { get; private set; }

        public Consumer(string appName, string id)
        {
            ApplicatioName = appName;
            ConsumerId = id;
        }
    }
}
