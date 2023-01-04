using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.rabbit
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage<T>(T message);

    }
}
