using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.Pages.ProfilePage;
using MarsQA_1.Utils;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class SkillTabTest: Start
    {
        
        [Test]
        [Category("TC-005-02")]
        public static void AddSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            SkillsTab.AddSkill(2);
            SkillsTab.CheckSkill(2);
        }

        [Test]
        [Category("TC-005-04")]
        public static void EditSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            SkillsTab.EditSkill(3);
            SkillsTab.CheckSkill(3);
        }

        [Test]
        [Category("TC-005-06")]
        public static void EraseSkill()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            SkillsTab.DeleteSkill();
            SkillsTab.CompareLastEntry();
        }
    }
}
