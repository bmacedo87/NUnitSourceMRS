using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ChangePassword
    {
        #region Initialize Web Elements
        //Main Profile Elements
        private static IWebElement oldPassword => Driver.driver.FindElement(By.XPath("//input[@name='oldPassword']"));
        private static IWebElement newPassword => Driver.driver.FindElement(By.XPath("//input[@name='newPassword']"));
        private static IWebElement confirmPassword => Driver.driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
        private static IWebElement save => Driver.driver.FindElement(By.XPath("/html/body/div[4]/div/div[2]/form/div[4]/button"));
        private static IWebElement alert => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div"));

        #endregion

        public static void FillForm(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ChangePassword");

            oldPassword.SendKeys(ExcelLibHelper.ReadData(DataRow, "OldPassword"));
            newPassword.SendKeys(ExcelLibHelper.ReadData(DataRow, "NewPassword"));
            confirmPassword.SendKeys(ExcelLibHelper.ReadData(DataRow, "ConfirmationPassword"));

            save.Click();
        }

        public static void CheckAlert(int AlertID)
        {
            string CheckAlert = alert.Text;

            if (CheckAlert== ExcelLibHelper.ReadData(AlertID, "Alerts"))
            {
                Assert.Pass("Found: " + CheckAlert);
            }
            else
            {
                Assert.Fail(CheckAlert+" :Alert doesn't match: " + ExcelLibHelper.ReadData(AlertID, "Alerts"));
            }
        }

        public static void CheckNewPassword()
        {
            //Logs out to try the new password
            Thread.Sleep(3000);
            ProfilePages.LogOut();
            SignIn.OpenForm();
            Thread.Sleep(1000);
            SignIn.FillCredentials(4);

            //Checks that the user is able to logIn and changes the password back again
            ProfilePages.CheckProfilePage();
            ProfilePages.OpenChangePassword();
            FillForm(2);

        }

    }
}
