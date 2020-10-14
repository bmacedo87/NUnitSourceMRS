using AutoItX3Lib;

namespace MarsQA_1.Helpers
{
    class AutoIt
    {
        public static void UploadFile(string FilePath)
        {
            AutoItX3 AutoIT = new AutoItX3();
            AutoIT.WinWaitActive("Open", "", 1500);
            AutoIT.ControlFocus("Open", "", "Edit1");
            AutoIT.ControlSetText("Open", "", "Edit1", FilePath);
            AutoIT.ControlClick("Open", "", "Button1");
        }
    }
}
