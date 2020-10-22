using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;

namespace MarsQA_1.NunitTests.ManageRequest
{
    [TestFixture]
    class ManageReceivedRequestTest:Start
    {
        [Test][Category("TC-013-02")]
        public static void ValidateReceivedRequest()
        {
            ManageRequestPage.GenerateNewRequest(5);
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.NavigateToReceivedRequest();
            ManageRequestPage.CheckReceivedRequest();
        }

        [Test]
        [Category("TC-013-07")]
        public static void ValidateAcceptRequest()
        {
            ManageRequestPage.GenerateNewRequest(5);
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.NavigateToReceivedRequest();
            ManageRequestPage.AcceptRequest();
            ManageRequestPage.CheckNewRequestStatus("Accepted");
        }

        [Test]
        [Category("TC-013-08")]
        public static void ValidateDeclineRequest()
        {
            ManageRequestPage.GenerateNewRequest(5);
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.NavigateToReceivedRequest();
            ManageRequestPage.DeclineRequest();
            ManageRequestPage.CheckNewRequestStatus("Declined");
        }

    }
}
