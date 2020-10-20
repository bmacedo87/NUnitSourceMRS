using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class SignUpTest: Start
    {
        
        [Test][Category("TC-001-03")]
        public static void SignUpWithInvalidData()
        {
            SignUp.CheckHomePage(); 
            SignUp.OpenForm();
            SignUp.Register(3);
            SignUp.CreateAlerts();
            SignUp.CheckAllFieldAlerts();
        }

        [Test][Category("TC-001-05")]
        public static void SignUpWithUsedEmail()
        {
            SignUp.CheckHomePage();
            SignUp.OpenForm();
            SignUp.Register(2);
            SignUp.CheckRepeatedEmailAlert();
        }
    }
}
