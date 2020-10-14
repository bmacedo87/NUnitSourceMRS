using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages
{
    class SignUp
    {
        private static IWebElement JoinButton => Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/button"));
        private static IWebElement FirstName => Driver.driver.FindElement(By.XPath("//input[@name='firstName']"));
        private static IWebElement LastName => Driver.driver.FindElement(By.XPath("//input[@name='lastName']"));
        private static IWebElement Email => Driver.driver.FindElement(By.XPath("//input[@name='email']"));
        private static IWebElement Password => Driver.driver.FindElement(By.XPath("//input[@name='password']"));
        private static IWebElement ConfirmPswd => Driver.driver.FindElement(By.XPath("//input[@name='confirmPassword']"));
        private static IWebElement TermsCheckbox => Driver.driver.FindElement(By.XPath("//input[@name='terms']"));
        private static IWebElement Confirm => Driver.driver.FindElement(By.XPath("//div[@id='submit-btn']"));
        private static IWebElement FirstNameAlert => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/div"));
        private static IWebElement LastNameAlert => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[2]/div"));
        private static IWebElement EmailAlert => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div"));
        private static IWebElement PasswordAlert => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div"));
        private static IWebElement ConfirmPswdAlert => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[5]/div"));
        private static IWebElement TermsAlert => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[7]/div"));
        private static IWebElement Background => Driver.driver.FindElement(By.XPath("//*[@id='home']/div/div/div[4]/div/input"));


        public static void Register(int DataRow)
        {

            FillForm(DataRow);

            Confirm.Click();
        }

        public static void OpenForm()
        {
            //Open the SignUp form
            JoinButton.Click();
        }

        public static void CheckFormPresence()
        {
            //Wait for the form to be present
            bool CheckElement=WaitHelper.CheckClickable(FirstName);

            if (CheckElement == true)
            {
                Assert.Pass("Element present");
            }
            else
            {
                Assert.Fail("Element not present");
            }

            

        }
        
        public static void CheckHomePage()
        {
            //Driver.driver.Navigate().GoToUrl(ConstantHelpers.Url);
            WaitHelper.WaitClickble(Driver.driver, JoinButton);
        }

        public static void CreateAlerts()
        {
            //Send a letter and erases ir to create the LastName Alert
            LastName.SendKeys("X"+Keys.Backspace);

            //Unchecks the Terms Cehckbox to create the Terms Alert
            TermsCheckbox.Click();

        }

        public static void CheckFormAlert(IWebElement CheckElement, int AlertNumber)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "SignUp");

            //Check that the alert message match the expected
            if (CheckElement.Text != ExcelLibHelper.ReadData(AlertNumber, "Alerts"))
            {
                Assert.Fail(CheckElement.Text + " Doesn't match the expected alert: " + ExcelLibHelper.ReadData(AlertNumber, "Alerts"));
            }
        }

        public static void CheckAllFieldAlerts()
        {
            //Checks all alerts one by one
            CheckFormAlert(FirstNameAlert, 2);
            CheckFormAlert(LastNameAlert, 3);
            CheckFormAlert(EmailAlert, 4);
            CheckFormAlert(PasswordAlert, 5);
            CheckFormAlert(ConfirmPswdAlert, 6);
            CheckFormAlert(TermsAlert, 7);
        }

        public static void CheckRepeatedEmailAlert()
        {
            //Handicap delay (The form takes too much time to load)
            Thread.Sleep(30000);

            //Wait for the alert to appear
            WaitHelper.WaitClickble(Driver.driver,EmailAlert);

            //Check that the alert message match the expected
            CheckFormAlert(EmailAlert, 8);
        }

        public static void FillForm(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "SignUp");

            //Fills the form
            FirstName.SendKeys(ExcelLibHelper.ReadData(DataRow, "FirstName"));
            LastName.SendKeys(ExcelLibHelper.ReadData(DataRow, "LastName"));
            Email.SendKeys(ExcelLibHelper.ReadData(DataRow, "Email"));
            Password.SendKeys(ExcelLibHelper.ReadData(DataRow, "Password"));
            ConfirmPswd.SendKeys(ExcelLibHelper.ReadData(DataRow, "ConfirmPswd"));
            TermsCheckbox.Click();
        }

    }

}
