using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages.ProfilePage
{
    class EducationTab
    {
        #region Page Elements
        private static IWebElement tabEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private static IWebElement buttonAddEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private static IWebElement textboxCollege => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        private static IWebElement dropdownCollege => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        private static IWebElement dropdownCollegeOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[92]"));
        private static IWebElement dropdownTitle => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        private static IWebElement dropdownTitleOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[3]"));
        private static IWebElement textboxDegree => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        private static IWebElement dropdownGraduation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        private static IWebElement dropdownGraduationOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[3]"));
        private static IWebElement buttonAddEducationSave => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        private static IWebElement buttonEditEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        private static IWebElement textboxEditEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
        private static IWebElement buttonEditEducationSave => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));
        private static IWebElement buttonDeleteEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
        private static IWebElement checkEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
        private static IWebElement LastEducation => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

        #endregion
        public static void AddEducation(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Fill Education after changing tab and waiting for elements to be interactable
            tabEducation.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonAddEducation);
            buttonAddEducation.Click();
            textboxCollege.SendKeys("CETI");
            dropdownCollege.Click();
            dropdownCollegeOption.Click();
            dropdownTitle.Click();
            dropdownTitleOption.Click();
            textboxDegree.SendKeys((ExcelLibHelper.ReadData(DataRow, "University")));
            dropdownGraduation.Click();
            dropdownGraduationOption.Click();
            buttonAddEducationSave.Click();
        }

        public static void EditEducation(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Edit Skills after changing tab and waiting for elements to be interactable
            tabEducation.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonEditEducation);
            buttonEditEducation.Click();
            textboxEditEducation.Clear();
            textboxEditEducation.SendKeys(ExcelLibHelper.ReadData(DataRow, "University"));
            buttonEditEducationSave.Click();
        }

        public static void DeleteEducation()
        {
            //Delete Education after changing tab and waiting for elements to be interactable
            tabEducation.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonDeleteEducation);
            buttonDeleteEducation.Click();
        }

        public static void CheckEducation(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Checks Education after changing tab and waiting for elements to be interactable
            tabEducation.Click();
            WaitHelper.WaitClickble(Driver.driver, buttonDeleteEducation);
            Thread.Sleep(1000);
            if (checkEducation.Text != ExcelLibHelper.ReadData(DataRow, "University")) { Assert.Fail(); }
        }

        public static void CompareLastEntry()
        {
            //Creates a new Web Element for the last() listed element and compares it with the previous last element
            IWebElement NewLastEntry = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
            if (LastEducation != NewLastEntry)
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
