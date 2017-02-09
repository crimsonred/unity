using System;

namespace PubNubAPI
{
    internal interface IPubNubNoChannelsBuilder<U, V>
    {
        void Async(PNCallback<V> callback);
    }
}

