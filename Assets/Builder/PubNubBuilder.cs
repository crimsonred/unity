using System;
using System.Collections.Generic;
using UnityEngine;

namespace PubNubAPI
{
    public class PubNubBuilder<U>
    {
        private PNConfiguration PNConfig { get; set;}

        public PubNubBuilder(PNConfiguration pnConfig){
            PNConfig = pnConfig;    
        }

        public void Execute (){
        }

        public void Async<T>(Action<T, PNStatus> callback, PNOperationType pnOpType){
            switch(pnOpType)
            {
                case PNOperationType.PNTimeOperation:
                    Debug.Log ("In Async");
                    NonSubscribeWorker.RunTimeRequest<T> (PNConfig, callback);
                    break;
                default:
                    break;
            }
            //return U;
        }

        public void SetChannels(List<string> channels){
            //return U;
        }

        public void SetChannelGroups(List<string> channelGroups){
            //return U;
        }
    }
}

