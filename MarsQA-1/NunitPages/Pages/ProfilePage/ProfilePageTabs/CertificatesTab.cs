using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages.ProfilePage
{
    class CertificatesTab
    {

        #region Page Elements
        private static IWebElement tabCertificates => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private static IWebElement buttonAddCertificates => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private static IWebElement textboxCertificates => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        private static IWebElement textboxCertificator => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));
        private static IWebElement dropdownCertificateYear => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select"));
        private static IWebElement dropdownCertificateYearOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[2]"));
        private static IWebElement buttonCertificateSave => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement buttonDeleteCertificate => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
        private static IWebElement buttonEditCertificate => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));
        private static IWebElement textboxEditCertificate => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input"));
        private static IWebElement buttonEditCertificateSave => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement checkCertificate => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement LastCertificate => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

        #endregion

        public static void AddCertificate(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Fill Certifications after changing tab and waiting for elements to be interactable
            tabCertificates.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonAddCertificates);
            buttonAddCertificates.Click();
            textboxCertificates.SendKeys((ExcelLibHelper.ReadData(DataRow, "Certificate")));
            textboxCertificator.SendKeys(ExcelLibHelper.ReadData(DataRow, "CertifiedFrom"));
            dropdownCertificateYear.Click();
            dropdownCertificateYearOption.Click();
            buttonCertificateSave.Click();
        }

        public static void EditCertificate(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Edit Skills after changing tab and waiting for elements to be interactable
            tabCertificates.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonEditCertificate);
            buttonEditCertificate.Click();
            textboxEditCertificate.Clear();
            textboxEditCertificate.SendKeys(ExcelLibHelper.ReadData(DataRow, "Certificate"));
            buttonEditCertificateSave.Click();
        }

        public static void DeleteCertificate()
        {
            //Delete Certificate after changing tab and waiting for elements to be interactable
            tabCertificates.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonDeleteCertificate);
            buttonDeleteCertificate.Click();
        }

        public static void CheckCertificate(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Checks Certificates after changing tab and waiting for elements to be interactable
            tabCertificates.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonDeleteCertificate);
            Thread.Sleep(1000);
            if (checkCertificate.Text != ExcelLibHelper.ReadData(DataRow, "Certificate")) { Assert.Fail(); }
        }

        public static void CompareLastEntry()
        {
            //Creates a new Web Element for the last() listed element and compares it with the previous last element
            IWebElement NewLastEntry = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            if (LastCertificate != NewLastEntry)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

    }
}
