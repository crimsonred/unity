using System;

using System.Collections.Generic;
using UnityEngine;

namespace PubNubAPI
{
    public class TimeBuilder: IPubNubNoChannelsBuilder<TimeBuilder, PNTimeResult>
    {
        private PubNubBuilder<TimeBuilder> pubNubBuilder;

        public TimeBuilder(PNConfiguration pnConfig){
            Debug.Log ("TimeBuilder Construct");
            pubNubBuilder = new PubNubBuilder<TimeBuilder> (pnConfig);
        }

        #region IPubNubBuilder implementation

        public void Async (PNCallback<PNTimeResult> callback)
        {
            Debug.Log ("TimeBuilder Async");
            pubNubBuilder.Async<PNTimeResult>(callback, PNOperationType.PNTimeOperation);
        }
        #endregion
    }
}

