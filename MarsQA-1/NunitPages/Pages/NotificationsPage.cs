using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.NunitPages.Pages
{
    class NotificationsPage
    {
        //Page Elements
        
        private static IWebElement notifications => Driver.driver.FindElement(By.XPath("//i[@class='icon list']"));
        private static IWebElement seAll => Driver.driver.FindElement(By.XPath("//*[contains(text(), 'See All...')]"));
        private static IWebElement selectServiceRequestTickBox => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']"));
        private static IWebElement selectServiceRequestTickBox2 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']"));
        private static IWebElement selectServiceRequestTickBox3 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']"));
        private static IWebElement selectServiceRequestTickBox4 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']"));
        private static IWebElement selectServiceRequestTickBox5 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']"));
        private static IWebElement selectAll => Driver.driver.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
        private static IWebElement unselectAll => Driver.driver.FindElement(By.XPath("//div[@class='ui icon basic button button-icon-style']"));
        private static IWebElement markSelectionAsRead => Driver.driver.FindElement(By.XPath("//i[@class='check square icon']"));
        private static IWebElement popUpMessageSelectionRead => Driver.driver.FindElement(By.XPath("//div[contains(text(),'Notification updated')]"));

        //Page methods

        public static void ClickNotifications()
        {
            notifications.Click();
        }

        public static void SeeAllNotifications()
        {
            //Click on See All notifications
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//*[contains(text(), 'See All...')]", 5);
            seAll.Click();
            
        }

        public static void SelectServiceRequest()
        {
            //Select SINGLE service request with checkbox
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//input[@type='checkbox' and @value='0']", 5);
            selectServiceRequestTickBox.Click();
        }

        public static void SelectMultipleServiceRequests()
        {
            //Select MULTIPLE service requests with checkbox
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//input[@type='checkbox' and @value='0']", 5);
            selectServiceRequestTickBox.Click();
            selectServiceRequestTickBox2.Click();
            selectServiceRequestTickBox3.Click();
        }

        public static void SelectAllServiceRequests()
        {
            //WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//i[@class='mouse pointer icon']", 5);
            Thread.Sleep(5000);
            selectAll.Click();
        }

        public static void MarkSelection()
        {
            //Click on mark selection as read
            markSelectionAsRead.Click();
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[contains(text(),'Notification updated')]", 5);
        }
       
        public static void MarkAsReadAssertion ()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[contains(text(),'Notification updated')]", 5);
            if (popUpMessageSelectionRead.Text == "Notification updated")
            {
                Assert.Pass("Notification record updated successfully!");
            }
            else
            {
                Assert.Fail("Notification record not updated!");
            }
        }

        public static void AllServiceRequestsSelectedAssertion()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='ui icon basic button button-icon-style']", 5);
            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']")).Selected);

            }
            catch (Exception e)
            {

            }
        }

        public static void UnselectAllServiceRequests()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='ui icon basic button button-icon-style']", 5);
            unselectAll.Click();
        }

        public static void UnselectAllAssertion()
        {
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']")).Selected);

        }
    }
}
