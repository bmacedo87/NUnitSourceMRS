using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class ProfileDetailsTest: Start
    {
        
        [Test][Category("TC-003")]
        public static void FillFluidCardDetails()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.EditName(2);
            ProfilePages.FillCardField();
            ProfilePages.CheckName(2);
        }

        [Test]
        [Category("TC-008-02")]
        public static void EditProfileDescription()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.OpenDescriptionTextfield();
            ProfilePages.FillDescription(2);
            ProfilePages.CheckProfileDescription(2);
        }

        [Test]
        [Category("TC-009-06")]
        public static void ChangePasswordWithInvalidPassword()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.OpenChangePassword();
            ChangePassword.FillForm(4);
            ChangePassword.CheckAlert(2);
        }

        [Test]
        [Category("TC-009-07")]
        public static void ChangePasswordWithValidPassword()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.OpenChangePassword();
            ChangePassword.FillForm(3);
            ChangePassword.CheckNewPassword();
        }

    }
}
