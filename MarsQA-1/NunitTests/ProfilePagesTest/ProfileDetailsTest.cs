using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class ProfileDetailsTest:Driver
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

        [Test][Category("TC-003")]
        public static void FillFluidCardDetails()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.EditName(2);
            ProfilePages.FillCardField();
            ProfilePages.CheckName(2);
        }
    }
}
