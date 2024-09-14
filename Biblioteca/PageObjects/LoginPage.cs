using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;
using PicpayPoc.Biblioteca.Global;

namespace PicpayPoc.Biblioteca.PageObjects
{
    public class LoginPage : BasePage
    {
        public AppiumElement BotaoAceitarCompartilhamento()
        {
            return ProcurarElementoPorID("com.android.permissioncontroller:id/permission_allow_button");
        }
        public AppiumElement CampoInformeCPF()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/editTextUsername");
        }
        public AppiumElement CampoSenha()
        {
            return ProcurarElementoPorID("com.picpay.debug:id/editTextPassword");
        }
        public AppiumElement BotaoEntrar()
        {
            return ProcurarElementoPorAndroidUiAutomator("new UiSelector().text(\"Entrar\")");
        }
    }
}
