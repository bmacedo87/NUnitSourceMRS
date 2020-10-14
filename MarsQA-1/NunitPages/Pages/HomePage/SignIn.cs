using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MarsQA_1.Pages
{
    public static class SignIn
    {
        private static IWebElement SignInBtn =>  Driver.driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']"));
        private static IWebElement Email => Driver.driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]"));
        private static IWebElement Password => Driver.driver.FindElement(By.XPath("//INPUT[@type='password']"));
        private static IWebElement LoginBtn => Driver.driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']"));
        private static IWebElement SubmitBtn => Driver.driver.FindElement(By.XPath("//*[@id='submit-btn']"));
        
        public static void OpenForm()
        {
            SignInBtn.Click();
        }

        internal static void FillCredentials(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "SignIn");

            //Fills form
            Email.SendKeys(ExcelLibHelper.ReadData(DataRow, "Username"));
            Password.SendKeys(ExcelLibHelper.ReadData(DataRow, "Password"));
            LoginBtn.Click();
        }

        internal static void CheckSubmitButton()
        {
            bool CheckResult = WaitHelper.CheckClickable(SubmitBtn);
            if (CheckResult==true)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(SubmitBtn.Text+" Button found!");
            }
        }

        public static void SigninStep()
        {
            Driver.NavigateUrl();
            OpenForm();
            FillCredentials(2);
        }
        public static void CheckLogin()
        {
            //Driver.driver.FindElement(By.Xpath)
        }

    }
}