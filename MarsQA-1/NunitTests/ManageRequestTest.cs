using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class ManageRequestTest:Start
    {
        [Test][Category("TC-013-02")]
        public static void ValidateReceivedRequest()
        {
            ManageRequestPage.GenerateNewRequest();
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.NavigateToReceivedRequest();
            ManageRequestPage.CheckReceivedRequest();
        }

        [Test]
        [Category("TC-013-07")]
        public static void ValidateAcceptRequest()
        {
            ManageRequestPage.GenerateNewRequest();
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
            ManageRequestPage.GenerateNewRequest();
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ManageRequestPage.NavigateToReceivedRequest();
            ManageRequestPage.DeclineRequest();
            ManageRequestPage.CheckNewRequestStatus("Declined");
        }

    }
}
