using System;
using System.Collections;

namespace PubNubAPI
{
    internal class PNCallback<T>
    {
        //public abstract void OnResponse(T result, PNStatus status);
        Action<T, PNStatus> callbackAction = null;
        string message;

        //public PNTimeCallback(Action<T, PNStatus> callback)
        //internal PNCallback(CustomEventArgs<T> cea)
        internal PNCallback()
        {
            //this.callbackAction = callback;
            //this.message = cea.Message;
            //this.callbackAction = cea.Callback;
        }

        #region implemented abstract members of PNCallback

        public void OnResponse (T result, PNStatus status)
        {
            if(callbackAction != null)
                callbackAction.Invoke(result, status);
        }

        #endregion
    }
}

