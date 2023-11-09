using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace QuanLyNhaHang.Common
{
    public class SmsService
    {
        private const string AccountSid = "ACa72e16819eec6c14448b1369626b3f71";
        private const string AuthToken = "128e18444bcf13e47bb35850f24d13db";
        private const string TwilioPhoneNumber = "+12563635978";

        public void SendSms(string phoneNumber, string messageBody)
        {
            TwilioClient.Init(AccountSid, AuthToken);

            var message = MessageResource.Create(
                body: messageBody,
                from: new Twilio.Types.PhoneNumber(TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }
    }
}