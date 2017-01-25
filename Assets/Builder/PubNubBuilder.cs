using System;
using System.Collections.Generic;

namespace PubNubAPI
{
    public abstract class PubNubBuilder
    {
        public PubNubBuilder ()
        {
        }

        public abstract void Execute();
        public abstract PubNubBuilder Async<T>();

        public abstract PubNubBuilder SetChannels(List<string> channels);

        public abstract PubNubBuilder SetChannelGroups(List<string> channelGroups);
    }
}

