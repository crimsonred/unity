using System;
using System.Collections.Generic;

namespace PubNubAPI
{
    public class SubscribeBuilder: IPubNubSubcribeBuilder<SubscribeBuilder>
    {
        private PubNubBuilder<SubscribeBuilder> pubNubBuilder;

        #region IPubNubBuilder implementation

        public void Execute(){
            pubNubBuilder.Execute ();
        }

        public SubscribeBuilder SetChannels(List<string> channels){
            pubNubBuilder.SetChannels (channels);
            return this;
        }

        public SubscribeBuilder SetChannelGroups(List<string> channelGroups){
            pubNubBuilder.SetChannelGroups(channelGroups);
            return this;
        }

        #endregion
    }
}

