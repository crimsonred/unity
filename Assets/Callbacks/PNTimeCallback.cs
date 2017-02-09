using System;

namespace PubNubAPI
{
    public class PNTimeCallback<T>: PNCallback<T>
    {
        #region implemented abstract members of PNCallback

        public override Action OnResponse (T result, PNStatus status)
        {
            throw new NotImplementedException ();
        }

        #endregion
    }
}

