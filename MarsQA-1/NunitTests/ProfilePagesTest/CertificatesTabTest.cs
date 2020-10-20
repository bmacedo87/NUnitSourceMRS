using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Pages.ProfilePage;
using MarsQA_1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class CertificatesTabTest: Start
    {
        
        [Test]
        [Category("TC-006-02")]
        public static void AddCertificate()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            CertificatesTab.AddCertificate(2);
            CertificatesTab.CheckCertificate(2);
        }

        [Test]
        [Category("TC-006-04")]
        public static void EditCertificate()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            CertificatesTab.EditCertificate(3);
            CertificatesTab.CheckCertificate(3);
        }

        [Test]
        [Category("TC-006-06")]
        public static void EraseCertificate()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            CertificatesTab.DeleteCertificate();
            CertificatesTab.CompareLastEntry();
        }
    }
}
