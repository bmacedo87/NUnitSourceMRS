using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages
{
    class ManageRequestPage
    {
        #region Initialize WebElements
        private static IWebElement ManageRequestDropdown => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
        private static IWebElement ReceivedRequestOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
        private static IWebElement AcceptButton => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]"));
        private static IWebElement DeclineButton => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]"));
        private static IWebElement CompleteButton => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button"));
        private static IWebElement RequestTitle => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[2]/a"));
        private static IWebElement RequestStatus => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        private static IWebElement RequestButton => Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]"));
        private static IWebElement RequestAcceptButton => Driver.driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[1]"));
        private static IWebElement LogOutButton => Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[1]/div[2]/div/a[2]/button"));
        private static IWebElement Alert => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div"));
        #endregion

        public static void GenerateNewRequest()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(5);
            ProfilePages.CheckProfilePage();
            Driver.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home/ServiceDetail?id=5f678a0708945f000120afb3");
            Thread.Sleep(2000);
            RequestButton.Click();
            Thread.Sleep(1000);
            RequestAcceptButton.Click();
            Thread.Sleep(2000);
            LogOutButton.Click();
            Thread.Sleep(500);
        }

        public static void NavigateToReceivedRequest()
        {
            ManageRequestDropdown.Click();
            WaitHelper.WaitClickble(Driver.driver, ReceivedRequestOption);
            ReceivedRequestOption.Click();
        }

        public static void AcceptRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, AcceptButton);
            AcceptButton.Click();
        }

        public static void DeclineRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, DeclineButton);
            DeclineButton.Click();
        }

        public static void CheckReceivedRequest()
        {
            //Waits for the elements to load
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, RequestTitle);

            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Compares the request title with the "Add Skill Share" or "Edit Skill Share" test cases
            if (RequestTitle.Text == ExcelLibHelper.ReadData(2, "Title") || RequestTitle.Text == ExcelLibHelper.ReadData(3, "Title") || RequestTitle.Text == "TitleText")
            {
                Assert.Pass("Request Title Found!");
            }
            else
            {
                Assert.Fail(RequestTitle.Text + "::doesn't match::" + ExcelLibHelper.ReadData(2, "Title") + "::nor::" + ExcelLibHelper.ReadData(3, "Title"));
            }

        }

        public static void CheckNewRequestStatus(string SpectedStatus)
        {
            Thread.Sleep(1000);
            //Refresh the page to update the listing
            Driver.driver.Navigate().Refresh();
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, RequestTitle);

            //Check if the newest request status matches the expected status
            if (RequestStatus.Text == SpectedStatus)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(RequestStatus.Text + "::Doesn't match::" + SpectedStatus);
            }
        }

        public static void CheckAlert()
        {
            Thread.Sleep(1000);
            if (Alert.Text == "Service has been updated")
            {
                Assert.Pass("Alert Found!");
            }
            else
            {
                Assert.Fail(Alert.Text + "::Alert doesn't match::Service has been updated");
            }
        }
    }
}
