using System;
using System.Collections;

namespace PubNubAPI
{
    public abstract class PNCallback<T>
    {
        public abstract Action OnResponse(T result, PNStatus status);
    }
}

