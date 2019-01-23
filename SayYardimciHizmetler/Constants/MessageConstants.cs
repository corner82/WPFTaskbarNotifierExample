using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayYardimciHizmetler.Constants
{
    public class MessageConstants
    {
        private MessageConstants(string value) { Value = value; }

        public string Value { get; set; }

        public static MessageConstants SuccessMessage { get { return new MessageConstants("İşleminiz Başarılı"); } }
        public static MessageConstants FailureMessage { get { return new MessageConstants("İşlem Başarısız"); } }
        public static MessageConstants SuccessToken { get { return new MessageConstants("Success"); } }
        public static MessageConstants FailureToken { get { return new MessageConstants("Failure"); } }
        public static MessageConstants NotifyMessengerBroker { get { return new MessageConstants("NotifyMessenger"); } }
        //public static MessageConstants Error { get { return new MessageConstants("Error"); } }
    }
}
