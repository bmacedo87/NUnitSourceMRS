using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace MarsQA_1.Pages
{
    class ShareSkillPage
    {
        #region Initialize WebElements

        private static IWebElement Title => Driver.driver.FindElement(By.Name("title"));
        private static IWebElement Description => Driver.driver.FindElement(By.Name("description"));
        private static IWebElement CategoryDropDown => Driver.driver.FindElement(By.Name("categoryId"));
        private static IWebElement SubCategoryDropDown => Driver.driver.FindElement(By.Name("subcategoryId"));
        private static IWebElement Tags => Driver.driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));
        private static IWebElement ServiceTypeOptions => Driver.driver.FindElement(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']"));
        private static IWebElement LocationTypeOption => Driver.driver.FindElement(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        private static IWebElement StartDateDropDown => Driver.driver.FindElement(By.Name("startDate"));
        private static IWebElement EndDateDropDown => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input"));
        private static IList<IWebElement> Days => Driver.driver.FindElements(By.XPath("//input[@type='checkbox']"));
        private static IWebElement StartTimeDropDown => Driver.driver.FindElement(By.XPath("//div[3]/div[2]/input[1]"));
        private static IWebElement EndTimeDropDown => Driver.driver.FindElement(By.XPath("//div[3]/div[3]/input[1]"));
        private static IWebElement SkillTradeExchangeOption => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        private static IWebElement SkillExchange => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input"));
        private static IWebElement SkillTradeCreditsOption => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
        private static IWebElement CreditAmount => Driver.driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
        private static IWebElement ActiveOption => Driver.driver.FindElement(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']"));
        private static IWebElement WorkSample => Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span"));
        private static IWebElement Save => Driver.driver.FindElement(By.XPath("//input[@value='Save']"));
        #endregion

        #region Page Methods

        public static void EnterText(int DataRow)
        {
            //Check if the user is able to Enter Text in the "Title" field
            Title.Clear();
            Title.SendKeys(ExcelLibHelper.ReadData(DataRow, "Title"));

            //Check if the user is able to Enter Text in the "Description" field
            Description.Clear();
            Description.SendKeys(ExcelLibHelper.ReadData(DataRow, "Description"));

        }

        public static void EditOptions(int DataRow)
        {
            //Check if the user is able to Click on the "Skill Exchange" option
            SkillTradeExchangeOption.Click();

            //Check if the user is able to create a tag for the "Skill Exchange" field
            SkillExchange.SendKeys(ExcelLibHelper.ReadData(DataRow, "SkillExchange") + Keys.Enter);
        }

        public static void FillDetails(int DataRow)
        {
            //Check if the user is able to Enter Text in the "Title" field
            EnterText(DataRow);

            //Check if the user is able to "Click" on the "Category" dropdown list
            CategoryDropDown.Click();
            CategoryDropDown.SendKeys(Keys.ArrowDown + Keys.Enter);

            //Check if the user is able to "Click" on the "SubCategory" dropdown list
            SubCategoryDropDown.Click();
            SubCategoryDropDown.SendKeys(Keys.ArrowDown + Keys.Enter);

            //Check if the user is able to "Enter" a "Tag"
            Tags.SendKeys(ExcelLibHelper.ReadData(DataRow, "Tag") + Keys.Enter);

            //Check if the user is able to "Click" on a "Service Type" option
            ServiceTypeOptions.Click();

            //Check if the user is able to "Click" on a "Location Type" option
            LocationTypeOption.Click();
        }

        public static void FillSchedrule(int DataRow)
        {
            //Check if the user is able to click on a "Start Date" for the "Available days" field
            StartDateDropDown.Click();
            StartDateDropDown.Clear();
            StartDateDropDown.SendKeys(ExcelLibHelper.ReadData(DataRow, "StartDate"));

            //Check if the user is able to click on a "End Date" for the "Available days" field
            EndDateDropDown.Click();
            EndDateDropDown.Clear();
            EndDateDropDown.SendKeys(ExcelLibHelper.ReadData(DataRow, "EndDate"));

            //Check if the user is able to click on a "Day" checkbox for the "Available days" field
            for (var i = 1; i <= 5; i++)
            {
                Days[i].Click();
            }

            //Check if the user is able to select a "Start Time" for the "Available days" field
            StartTimeDropDown.SendKeys(ExcelLibHelper.ReadData(DataRow, "StartTime"));

            //Check if the user is able to select a "End Time" for the "Available days" field
            EndTimeDropDown.SendKeys(ExcelLibHelper.ReadData(DataRow, "EndTime"));

            //Check if the user is able to click on "Credits" as the "Skill Trade" option
            SkillTradeCreditsOption.Click();

            //Check if the user is able to enter a number for the "Credits" field
            CreditAmount.Clear();
            CreditAmount.SendKeys(ExcelLibHelper.ReadData(DataRow, "Credit"));

            //Check if the user is able to set an option for the "Active" field
            ActiveOption.Click();

        }

        public static void UploadSample(int DataRow)
        {
            //Click on Upload Sample File
            WorkSample.Click();

            //Uses AutoIt to handle the file explorer
            AutoIt.UploadFile(ExcelLibHelper.ReadData(DataRow, "FilePath"));

        }

        #endregion


        public static void FillShareSkill(int DataRow)
        {
            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Fills the form
            FillDetails(DataRow);
            FillSchedrule(DataRow);

            //Check if the user is able to load a file in the "Work Sample" field
            //UploadSample(DataRow);  //Bug found

            //Check if the user can Click on the "Save" button
            Save.Click();
        }

        public static void EditShareSkill(int DataRow)
        {
            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Edit the form
            EnterText(DataRow);

            //Edit the Trade option
            EditOptions(DataRow);

            //Check if the user can Click on the "Save" button
            Save.Click();
        }


    }
}
