using System;


    
    public class SocketMessageReceivedFromServer : EventArgs
    {
        public byte[] Message
        {
            get;
            private set;
        }

        public int BytesTransferred
        {
            get;
            set;
        }

        public SocketMessageReceivedFromServer(byte[] data, int dataSize)
        {
            // byte[] tmp = new byte[dataSize];
            // Array.Copy( data, 0, tmp, 0, dataSize );
            //this.Message = tmp;
            this.Message = data;
            this.BytesTransferred = dataSize;
        }
    }

