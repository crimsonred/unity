using System;
using System.Collections.Generic;

namespace PubNubAPI
{
    public class SubscribeBuilder: IPubNubBuilder
    {
        public SubscribeBuilder ()
        {
        }

        public void Execute(){
        }

        public SubscribeBuilder Async<T>(){
            return this;
        }

        public SubscribeBuilder SetChannels(List<string> channels){
            return this;
        }

        public SubscribeBuilder SetChannelGroups(List<string> channelGroups){
            return this;
        }
    }
}

