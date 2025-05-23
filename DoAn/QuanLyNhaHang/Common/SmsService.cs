using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace QuanLyNhaHang.Common
{
    public class SmsService
    {
        // Test local
        //private const string AccountSid = "ACa72e16819eec6c14448b1369626b3f71";
        //private const string AuthToken = "128e18444bcf13e47bb35850f24d13db";
        //private const string TwilioPhoneNumber = "+12563635978";

        // https://console.twilio.com/
        // use:thanhduy15032001 @gmail.com
        // pass:ThanhDuy15032001 @gmail.com
        // Recovery code: P177DKNKRR1M4DJJ4SL7Y1WB
        private const string AccountSid = "AC3800db8cf57f75a4e0bf9a7104e17194";
        private const string AuthToken = "0ca6000eb9b93bc9c267504b254ea2d0";
        private const string TwilioPhoneNumber = "+12512442750";

        public void SendSms(string phoneNumber, string messageBody)
        {
            // Conver số 0 đầu thành +84
            phoneNumber = $"+84{phoneNumber.Substring(1)}";

            TwilioClient.Init(AccountSid, AuthToken);

            var message = MessageResource.Create(
                body: messageBody,
                from: new Twilio.Types.PhoneNumber(TwilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(phoneNumber)
            );
        }
    }
}