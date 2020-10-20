using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class SignInTest : Start
    {
        
        [Test][Category("TC-002-03")]
        public static void SignInWithInvalidData()
        {
            SignUp.CheckHomePage();
            SignIn.OpenForm();
            SignIn.FillCredentials(3);
        }

        [Test][Category("TC-002-04")]
        public static void SignInWithValidData()
        {
            SignUp.CheckHomePage();
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.CheckProfilePage();
        }

    }
}
