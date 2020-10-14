using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class SignInTest : Driver
    {
        #region Start
        [SetUp]
        public void Setup()
        {
            //launch the browser
            Initialize();
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "TestData");

        }

        [TearDown]
        public void TearDown()
        {
            //Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");

            //Close the browser
            Close();

        }
        #endregion

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
