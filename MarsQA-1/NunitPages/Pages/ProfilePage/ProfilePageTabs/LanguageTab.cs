using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages.ProfilePage
{
    class LanguageTab
    {
        #region Page Elements
        private static IWebElement tabLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
        private static IWebElement buttonAddLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement textboxAddLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        private static IWebElement dropdownLanguageLV => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select"));
        private static IWebElement dropdownLanguageOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[3]"));
        private static IWebElement buttonLanguageSave => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement buttonEditLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]"));
        private static IWebElement textboxEditLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));
        private static IWebElement dropdownEditLanguageLV => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select"));
        private static IWebElement dropdownEditLanguageOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[2]"));
        private static IWebElement buttonEditLanguageSave => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement buttonDeleteLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
        private static IWebElement checkLanguage => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement LastLanguageListing => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        
        #endregion

        public static void AddLanguage(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Fill Language after changing tab and waiting for elements to be interactable
            tabLanguage.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonAddLanguage);
            buttonAddLanguage.Click();
            textboxAddLanguage.SendKeys(ExcelLibHelper.ReadData(DataRow, "Language"));
            dropdownLanguageLV.Click();
            dropdownLanguageOption.Click();
            buttonLanguageSave.Click();
        }

        public static void EditLanguage(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Edit Language after changing tab and waiting for elements to be interactable
            tabLanguage.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonEditLanguage);
            buttonEditLanguage.Click();
            textboxEditLanguage.Clear();
            textboxEditLanguage.SendKeys(ExcelLibHelper.ReadData(DataRow, "Language"));
            dropdownEditLanguageLV.Click();
            dropdownEditLanguageOption.Click();
            buttonEditLanguageSave.Click();

        }

        public static void DeleteLanguage()
        {
            //Delete Language after changing tab and waiting for elements to be interactable
            tabLanguage.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonDeleteLanguage);
            buttonDeleteLanguage.Click();
        }

        public static void CheckLanguage(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Checks Language after changing tab and waiting for elements to be interactable
            tabLanguage.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonDeleteLanguage);
            Thread.Sleep(1000);
            if (checkLanguage.Text != ExcelLibHelper.ReadData(DataRow, "Language")) { Assert.Fail(); }
        }

        public static void CompareLastEntry()
        {
            //Creates a new Web Element for the last() listed element and compares it with the previous last element
            IWebElement NewLastEntry = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
            if (LastLanguageListing != NewLastEntry)
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
