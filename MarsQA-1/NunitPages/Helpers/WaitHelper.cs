using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_1.Helpers
{
    class WaitHelper
    {
        public static void WaitClickble(IWebDriver driver, IWebElement element)
        {
            Thread.Sleep(1000);
            try
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch(Exception error)
            {
                Assert.Fail("Time out to find element: "+error);
            }


        }

        public static bool CheckClickable(IWebElement element)
        {
            try
            {
                element.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
