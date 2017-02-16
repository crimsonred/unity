using System;
using UnityEngine;

namespace PubNubAPI
{
    public class QueueManager: MonoBehaviour
    {
        bool NoRunningReuqets = true;
        void Update(){
            if ((RequestQueue.Instance.HasItems) && (NoRunningReuqets)) {
                QueueStorage qs =  RequestQueue.Instance.Dequeue ();
                PNOperationType operationType = qs.OperationType;
                if (operationType.Equals (PNOperationType.PNTimeOperation)) {
                    Action<PNTimeResult, PNStatus> callback = qs.Callback as Action<PNTimeResult, PNStatus>;
                    NonSubscribeWorker<PNTimeResult> nsw = new NonSubscribeWorker<PNTimeResult> ();
                    nsw.RunTimeRequest (null, callback);
                }    
                    
                //NonSubscribeWorker<T> nsw = new NonSubscribeWorker<T> ();
                //nsw.RunTimeRequest (PNConfig, callback);
            }
        }
    }
}

