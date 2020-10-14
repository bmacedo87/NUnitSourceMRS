using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class ShareSkillTest:Driver
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

        [Test]//Test Case 006
        [Category("")]
        public void AddShareSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if the user is able to access the "Share-Skill" function
            ProfilePages.GoToShareSkill();

            //Check if the user is able to fill the "Share-Skill" details
            ShareSkillPage.FillShareSkill(2);

            //Check if the user is able to see the Skill in the "Manage Listing" page
            ManageListingPage.CheckListing(2);

        }

        [Test]//Test Case 012
        [Category("")]
        public void EditShareSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if the user is able to access the "Share-Skill" function
            ProfilePages.GoToManageListing();

            //Check if the user is able to access the "Share-Skill" function
            ManageListingPage.EditListing();

            //Check if the user is able to fill the Edit "Share-Skill" details
            ShareSkillPage.EditShareSkill(3);

            //Check if the changes can be seen in the "Manage Listage
            //CheckListPage.CheckListing(3);
        }

        [Test]//Test Case 013
        [Category("")]
        public void EraseShareSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if the user is able to access the "ManageListing" page
            ProfilePages.GoToManageListing();

            //Check if the user is able to delete the last entry of the "ManageListing" page
            ManageListingPage.DeleteListing();

            //Check if the changes can be seen in the "Manage Listing" page
            ManageListingPage.CompareLastEntry();

        }

    }
}
