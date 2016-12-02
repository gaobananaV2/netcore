using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    // MVP
    public interface ILogInPresenter
    {
        void OnUserLogin(string name, string pass);
        void OnUserAttemptedRetry();
    }

    public interface IView
    {
        void ShowError(bool visiable,string code);
        void ShowProcess(bool visiable);
        void ShowSuccess();
    }
}
