using java.time;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PicpayPoc.Biblioteca.Global.Begin;
using EsperarCondicao = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PicpayPoc.Biblioteca.Global
{
    public class BasePage
    {
        public WebDriverWait Wait { get; private set; }
        public IJavaScriptExecutor Js => (IJavaScriptExecutor)GetDriver();
        public AppiumElement ProcurarElementoPorAcessbilityID(string AcessbilityID)
        {
            return GetDriver().FindElement(MobileBy.AccessibilityId(AcessbilityID));
        }
        public AppiumElement ProcurarElementoPorAndroidUiAutomator(string AndroidUIAutomator)
        {
            return GetDriver().FindElement(MobileBy.AndroidUIAutomator(AndroidUIAutomator));
        }
        public AppiumElement ProcurarElementoPorID(string ID)
        {
            return GetDriver().FindElement(MobileBy.Id(ID));
        }
        public AppiumElement ProcurarElementoPorClassName(string Classname)
        {
            return GetDriver().FindElement(MobileBy.ClassName(Classname));
        }
        public AppiumElement ProcurarElementoPorAcessibilityID(string AccessibilityId)
        {
            return GetDriver().FindElement(MobileBy.AccessibilityId(AccessibilityId));
        }
        public AppiumElement ProcurarElementoPorAcessibilityXpath(string Xpath)
        {
            return GetDriver().FindElement(By.XPath(Xpath));
        }

        public void Esperar(string Xpath,string locator)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(10));
            switch (locator)
            {
                case "xpath":
                    wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.XPath(Xpath)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(MobileBy.XPath(Xpath)));
                    break;
                case "id":
                    wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.Id(Xpath)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(MobileBy.Id(Xpath)));
                    break;
                case "acessID":
                    wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AccessibilityId(Xpath)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(MobileBy.AccessibilityId(Xpath)));
                    break;
                case "androidUI":
                    wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.AndroidUIAutomator(Xpath)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(MobileBy.AndroidUIAutomator(Xpath)));
                    break; 
                case "ClassName":
                    wait.Until(ExpectedConditions.ElementIsVisible(MobileBy.ClassName(Xpath)));
                    wait.Until(ExpectedConditions.ElementToBeClickable(MobileBy.ClassName(Xpath)));
                    break;
            }


        }
        public bool VerificarSeElementoExiste(By Elemento) { try { GetDriver().FindElement(Elemento); return true; } catch (NoSuchElementException) { return false; } }
        public bool VerificarSeElementoEstaoculto(string Elemento)
        {
            try { GetDriver().FindElement(MobileBy.AndroidUIAutomator(Elemento)); return false; } catch (NoSuchElementException) { return true; }
        }
    }
}
