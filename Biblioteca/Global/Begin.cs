using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicpayPoc.Biblioteca.Global
{
    public class Begin
    {
        private static AndroidDriver Driver;
        public static string PastaDosTeste = "";
        public static int NumeroDaExecucao;
        static Random NumAleatorio => new Random();
        public static int ValorAleatorio => NumAleatorio.Next(1,10000);

        [OneTimeTearDown]
        public static AndroidDriver GetDriver()
        {
            if (Driver == null)
            {
                NumeroDaExecucao = ValorAleatorio;

                var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/");
                var driverOptions = new AppiumOptions()
                {
                    AutomationName = AutomationName.AndroidUIAutomator2,
                    PlatformName = "Android",
                    DeviceName = "Emulator",
                };

                driverOptions.AddAdditionalAppiumOption("appPackage", "com.picpay.debug");
                driverOptions.AddAdditionalAppiumOption("appActivity", "com.picpay.AppLinkActivity");
                driverOptions.AddAdditionalAppiumOption("newCommandTimeout", 120000);
                // NoReset assumes the app com.google.android is preinstalled on the emulator
                driverOptions.AddAdditionalAppiumOption("noReset", true);
                Driver = new AndroidDriver(new Uri("http://127.0.0.1:4723"), driverOptions, TimeSpan.FromSeconds(180));
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            }
            return Driver;
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }
    }
}
