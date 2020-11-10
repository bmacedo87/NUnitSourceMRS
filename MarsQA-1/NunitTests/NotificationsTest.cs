using MarsQA_1.Helpers;
using MarsQA_1.NunitPages.Pages;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
   
    class NotificationsTest : Start
    {
        [Test]
        [Category("TC_020_02")]
        public void MarkSingleNotificationAsRead()
        {
           
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            NotificationsPage.ClickNotifications();
            NotificationsPage.SeeAllNotifications();
            
            //Select a single notification
            NotificationsPage.SelectServiceRequest();
            
            NotificationsPage.MarkSelection();

            //Assertion
            NotificationsPage.MarkAsReadAssertion();

        }

        [Test]
        [Category("TC_020_03")]
        public void MarkMultipleNotificationAsRead()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            NotificationsPage.ClickNotifications();
            NotificationsPage.SeeAllNotifications();

            //Select Multiple notifications
            NotificationsPage.SelectMultipleServiceRequests();

            NotificationsPage.MarkSelection();

            //Assertion
            NotificationsPage.MarkAsReadAssertion();

        }

        [Test]
        [Category("TC_021_01")]
        public void SelectAllNotifications()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            NotificationsPage.ClickNotifications();
            NotificationsPage.SeeAllNotifications();

            //Click on select all notifications
            NotificationsPage.SelectAllServiceRequests();

            //Assertion
            NotificationsPage.AllServiceRequestsSelectedAssertion();

        }

        [Test]
        [Category("TC_021_03")]
        public void UnselectAllNotifications()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            NotificationsPage.ClickNotifications();
            NotificationsPage.SeeAllNotifications();

            //Click on select all notifications
            NotificationsPage.SelectAllServiceRequests();

            //Click on unselect all notifications
            NotificationsPage.UnselectAllServiceRequests();

            //Assertion
            NotificationsPage.UnselectAllAssertion();


        }


    }
}
