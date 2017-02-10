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

        public static void RunTimeRequest<T>(PNConfiguration pnConfig, Action<T, PNStatus> callback){
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
            PNUnityWebRequest webRequest = gobj.AddComponent<PNUnityWebRequest> ();
            webRequest.NonSubCoroutineComplete += CoroutineCompleteHandler<T>;
            Debug.Log ("RunTimeRequest coroutine");
            //PNCallback<T> timeCallback = new PNTimeCallback<T> (callback);
            webRequest.Run<T>("Https://pubsub.pubnub.com/time/0", requestState, 10, 0, callback);
            Debug.Log ("after coroutine");

        }
        private static void CoroutineCompleteHandler<T> (object sender, EventArgs ea)
        {
            CustomEventArgs<T> cea = ea as CustomEventArgs<T>;

            try {
                if (cea != null) {
                    PNCallback<T> timeCallback = new PNCallback<T> ();
                    PNTimeResult pnTimeResult = new PNTimeResult();
                    pnTimeResult.TimeToken = cea.Message;
                    PNStatus pnStatus = new PNStatus();
                    pnStatus.Error = false;

                    timeCallback.OnResponse(pnTimeResult, pnStatus);

                    /*if (cea.PubnubRequestState != null) {
                        ProcessCoroutineCompleteResponse<T> (cea);
                    }*/
                    #if (ENABLE_PUBNUB_LOGGING)
                    else {
                    LoggingMethod.WriteToLog (string.Format ("DateTime {0}, CoroutineCompleteHandler: PubnubRequestState null", DateTime.Now.ToString ()), LoggingMethod.LevelError);
                    }
                    #endif
                }
                #if (ENABLE_PUBNUB_LOGGING)
                else {
                LoggingMethod.WriteToLog (string.Format ("DateTime {0}, CoroutineCompleteHandler: cea null", DateTime.Now.ToString ()), LoggingMethod.LevelError);
                }
                #endif
            } catch (Exception ex) {
                #if (ENABLE_PUBNUB_LOGGING)
                LoggingMethod.WriteToLog (string.Format ("DateTime {0}, CoroutineCompleteHandler: Exception={1}", DateTime.Now.ToString (), ex.ToString ()), LoggingMethod.LevelError);
                #endif

                //ExceptionHandlers.UrlRequestCommonExceptionHandler<T> (ex.Message, cea.PubnubRequestState,
                  //  false, false, PubnubErrorLevel);
            }
        }
    }
}

