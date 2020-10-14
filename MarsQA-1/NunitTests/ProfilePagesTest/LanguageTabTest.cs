using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Pages.ProfilePage;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{

    [TestFixture]
    class LanguageTabTest:Driver
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

        [Test][Category("TC-004-02")]
        public static void AddLanguage()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            LanguageTab.AddLanguage(2);
            LanguageTab.CheckLanguage(2);
        }

        [Test]
        [Category("TC-004-04")]
        public static void EditLanguage()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            LanguageTab.EditLanguage(3);
            LanguageTab.CheckLanguage(3);
        }

        [Test]
        [Category("TC-004-06")]
        public static void EraseLanguage()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            LanguageTab.DeleteLanguage();
            LanguageTab.CompareLastEntry();
        }

    }
}
