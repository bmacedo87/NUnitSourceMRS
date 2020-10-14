using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Pages.ProfilePage;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class SkillTabTest:Driver
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
        [Category("TC-005-02")]
        public static void AddSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            SkillsTab.AddSkill(2);
            SkillsTab.CheckSkill(2);
        }

        [Test]
        [Category("TC-005-04")]
        public static void EditSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            SkillsTab.EditSkill(3);
            SkillsTab.CheckSkill(3);
        }

        [Test]
        [Category("TC-005-06")]
        public static void EraseSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            SkillsTab.DeleteSkill();
            SkillsTab.CompareLastEntry();
        }
    }
}
