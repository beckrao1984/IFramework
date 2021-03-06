﻿using IFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Event
{
    public interface IEventAsyncSubscriber<in TEvent> :
            IMessageAsyncHandler<TEvent> where TEvent : class, IEvent
    {
    }
}
