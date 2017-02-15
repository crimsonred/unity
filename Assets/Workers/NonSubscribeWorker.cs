using System;
using UnityEngine;

namespace PubNubAPI
{
    public class NonSubscribeWorker<T>
    {
        public NonSubscribeWorker ()
        {
        }

        private static GameObject gobj;
        Action<T, PNStatus> Callback;

        public void RunTimeRequest(PNConfiguration pnConfig, Action<T, PNStatus> callback){
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

            //save callback
            this.Callback = callback;

            Debug.Log ("RunTimeRequest gobj");
            PNUnityWebRequest webRequest = PubNub.GameObjectRef.AddComponent<PNUnityWebRequest> ();
            webRequest.NonSubCoroutineComplete += CoroutineCompleteHandler;
            Debug.Log ("RunTimeRequest coroutine");
            //PNCallback<T> timeCallback = new PNTimeCallback<T> (callback);
            webRequest.Run<T>("Https://pubsub.pubnub.com/time/0", requestState, 10, 0);
            Debug.Log ("after coroutine");

        }

        public static T ConvertValue<T,U>(U value) where U : IConvertible
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T ConvertValue<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        private void CoroutineCompleteHandler (object sender, EventArgs ea)
        {
            CustomEventArgs<T> cea = ea as CustomEventArgs<T>;

            try {
                if (cea != null) {
                    Debug.Log ("inCoroutineCompleteHandler ");
                    //PNTimeCallback<T> timeCallback = new PNTimeCallback<T> ();
                    PNTimeResult pnTimeResult = new PNTimeResult();
                    pnTimeResult.TimeToken = cea.Message;
                    PNStatus pnStatus = new PNStatus();
                    pnStatus.Error = false;
                    /*if (pnTimeResult is T) {
                        //return (T)pnTimeResult;
                        //Callback((T)pnTimeResult, pnStatus);
                    } else {*/
                        try {
                            //return (T)Convert.ChangeType(pnTimeResult, typeof(T));
                            Debug.Log ("Callback");
                            Callback((T)Convert.ChangeType(pnTimeResult, typeof(T)), pnStatus);

                            Debug.Log ("After Callback");
                        } catch (InvalidCastException ice) {
                            //return default(T);
                            Debug.Log (ice.ToString());
                            throw ice;
                        }
                    //}

                    //T pnTimeResult2 = (T)pnTimeResult as object;
                    //Callback(pnTimeResult2, pnStatus);
                    //PNTimeResult pnTimeResult2 = (T)pnTimeResult;
                    //timeCallback.OnResponse(pnTimeResult, pnStatus);

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

