using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Pages.ProfilePage;
using NUnit.Framework;
using System;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class EducationTabTest:Driver
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

        [Test]
        [Category("TC-006-02")]
        public static void AddEducation()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            EducationTab.AddEducation(2);
            EducationTab.CheckEducation(2);
        }

        [Test]
        [Category("TC-006-04")]
        public static void EditEducation()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            EducationTab.EditEducation(3);
            EducationTab.CheckEducation(3);
        }

        [Test]
        [Category("TC-006-06")]
        public static void EraseEducation()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            EducationTab.DeleteEducation();
            EducationTab.CompareLastEntry();
        }
    }
}
