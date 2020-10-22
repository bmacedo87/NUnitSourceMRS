using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;

namespace MarsQA_1.NunitTests.ManageRequest
{
    [TestFixture]
    class ManageSentRequestTest:Start
    {
        [Test][Category("TC-014-01")]
        public static void ValidateSentRequest()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.NavigateToSentRequest();
            ManageRequestPage.CheckSentRequest();
        }

        [Test]
        [Category("TC-014-05")]
        public static void ValidateCompletedRequest()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.GenerateNewRequest(2);
            ManageRequestPage.AcceptRequestWithOtherUser();
            ManageRequestPage.NavigateToSentRequest();
            ManageRequestPage.CompletedRequest();
            ManageRequestPage.CheckNewSentStatus("Completed");
        }

        [Test]
        [Category("TC-014-08")]
        public static void ValidateWithdrawRequest()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.GenerateNewRequest(2);
            ManageRequestPage.NavigateToSentRequest();
            ManageRequestPage.WithdrawRequest();
            ManageRequestPage.CheckNewSentStatus("Withdrawn");
        }

    }
}
