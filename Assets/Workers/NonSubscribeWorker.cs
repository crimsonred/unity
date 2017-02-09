using System;
using UnityEngine;

namespace PubNubAPI
{
    public class NonSubscribeWorker
    {
        public NonSubscribeWorker ()
        {
        }

        private static GameObject gobj;

        public static void RunTimeRequest<T>(PNConfiguration pnConfig, PNCallback<T> callback){
            //Uri request = BuildRequests.BuildTimeRequest (this.SessionUUID, this.ssl, this.Origin);

            RequestState<T> requestState = new RequestState<T> ();
            //requestState.ChannelEntities = channelEntities;
            requestState.RespType = PNOperationType.PNTimeOperation;
            /*requestState.Reconnect = reconnect;
            requestState.SuccessCallback = userCallback;
            requestState.ErrorCallback = errorCallback;
            requestState.ID = id;
            requestState.Timeout = timeout;
            requestState.Timetoken = timetoken;
            requestState.TypeParameterType = typeParam;
            requestState.UUID = uuid;
            return requestState;*/
            Debug.Log ("RunTimeRequest");
            gobj = new GameObject ("PubnubGameObject");
            Debug.Log ("RunTimeRequest gobj");
            PNUnityWebRequest coroutine = gobj.AddComponent<PNUnityWebRequest> ();
            Debug.Log ("RunTimeRequest coroutine");
            coroutine.Run<T>("Https://pubsub.pubnub.com/time/0", requestState, 10, 0);
            Debug.Log ("after coroutine");
        }
    }
}

