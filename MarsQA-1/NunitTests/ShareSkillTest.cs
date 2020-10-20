using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using MarsQA_1.Utils;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class ShareSkillTest: Start
    {

        [Test]
        [Category("TC-010-02")]
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

        [Test]
        [Category("TC-011-04")]
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
            ManageListingPage.CheckListing(3);
        }

        [Test]
        [Category("TC-012-01")]
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
