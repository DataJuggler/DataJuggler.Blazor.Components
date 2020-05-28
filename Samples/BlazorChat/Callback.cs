﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChat
{
    /// <summary>
    /// This delegate is used by the SubscriberService to send messages to any subscribers
    /// </summary>    
    /// <returns></returns>
    public delegate void Callback(SubscriberMessage message);
}
