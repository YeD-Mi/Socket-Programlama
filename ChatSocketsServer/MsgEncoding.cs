using System;
using System.Collections.Generic;
using System.Text;

namespace ChatSocketsServer
{
    public class MsgEncoding
    {
        
        public static string Encode(MsgCode code, string body)
        {
            return $"{(int)code:D3}>{body}";
        }

        public static Answer Decode(string message)
        {
            return new Answer()
            {
                Body = message.Substring(4),
                Code = (MsgCode)int.Parse(message.Substring(0, 3))
            };
        } 
    }

    public struct Answer
    {
        public string Body;
        public MsgCode Code;
    }

    public enum MsgCode
    {
        Standard,
        ConnectionSuccess,
        ConnectionError,
        RequestUserList,
        RequestConnection,
        GlobalChat,
        DirectChat,
        OnlineListRequest
    }
}
