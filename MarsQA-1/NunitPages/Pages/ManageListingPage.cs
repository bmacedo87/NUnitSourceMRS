using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Pages
{
    class ManageListingPage
    {
        #region Initialize WebElements
        private static IWebElement manageListingsLink => Driver.driver.FindElement(By.LinkText("Manage Listings"));
        private static IWebElement view => Driver.driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));
        private static IWebElement delete => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]"));
        private static IWebElement edit => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]"));
        private static IWebElement clickActionsButton => Driver.driver.FindElement(By.XPath("//div[@class='actions']"));
        private static IWebElement YesBtn => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        private static IWebElement NoBtn => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        private static IWebElement SkillTitle => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        private static IWebElement SkillDescription => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        private static IWebElement LastSkillListing => Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[last()]"));

        #endregion

        public static void EditListing()
        {
            edit.Click();
        }

        public static void DeleteListing()
        {
            delete.Click();
            YesBtn.Click();
        }

        public static void CheckListing(int DataRow)
        {
            //Creates a bool to determine the check result
            bool CheckResult = true;

            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Compares the listing data
            if (SkillDescription.Text != ExcelLibHelper.ReadData(DataRow, "Description")) { CheckResult = false; }

            //Asserts the test base on the Check Result
            if (CheckResult == true)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }

        public static void CompareLastEntry()
        {
            //Creates a new Web Element for the last() listed element and compares it with the previous last element
            IWebElement NewLastEntry = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[last()]"));
            if (LastSkillListing != NewLastEntry)
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
