using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TonPlace.Models;

namespace TonPlace.Logic
{
    class Support
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private static object locks = new object();

        public bool TonCookie(string id)
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.StackTrace, "Nạp cookie bị Error");
                return false;
            }
        }

        public static bool Create_Ton(Setting setting)
        {

            var driverService = ChromeDriverService.CreateDefaultService();
            //driverService.HideCommandPromptWindow = true;
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("window-size=393,851");
            option.AddExcludedArgument("enable-automation");
            option.AddAdditionalOption("useAutomationExtension", false);
            option.AddArgument("--autoplay-policy=no-user-gesture-required");
            option.AddArgument("--mute-audio");
            option.AddArgument("no-sandbox");
            option.AddArgument("--disable-infobars");
            option.AddArgument("--disable-default-apps");
            option.AddArgument("--disable-gpu");
            option.AddArgument("--FontRenderHinting[none]");
            option.AddArgument("--disable-blink-features=AutomationControlled");
            option.AddExtension("Services/captcha.crx");
            option.AddArgument("--app=https://ton.place/id409828?ref=640e4");
            string path = setting.path;
            option.AddArgument("user-data-dir=" + path + "\\VmsRuning");
            ChromeDriver ton_browser = new ChromeDriver(driverService, option);
            Setting_Captcha(ton_browser);

            CDK_AddOn addOn = new CDK_AddOn(ton_browser);

            ton_browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            addOn.Click_Element(Element.Create.Sign_up_or_Log_in);
            SDK.RapidAPI_Mail = setting.API.api_mail;
            SDK.RapidAPI_Twitter = setting.API.api_post;
            Mails mails = SDK.Call_Create_Mai();
            addOn.Input_Element(Element.Create.Input_Email, mails.email);
            addOn.Click_Element(Element.Create.Continue);
            List<Inbox> inboxes = SDK.Call_Read_Inbox(mails.email);
            while (inboxes == null || inboxes.Count == 0)
            {
                Delay(10);
                inboxes = SDK.Call_Read_Inbox(mails.email);
            }
            string code_mail = inboxes.First().body_text.Substring(inboxes.First().body_text.Length - 6);
            addOn.Input_Element(Element.Create.Input_Code, code_mail);
            addOn.Click_Element(Element.Create.Continue_Code);

            IJavaScriptExecutor js = (IJavaScriptExecutor)ton_browser;
            string value = (string)js.ExecuteScript("return localStorage.getItem('accounts')");


            return true;
        }

        public static void Set_Info(ChromeDriver driver, Tweet_Profile profile)
        {
            CDK_AddOn addOn = new CDK_AddOn(driver);

        }

        public static void Setting_Captcha(ChromeDriver driver, bool auto = true)
        {
            try
            {
                string urlCurrent = driver.Url;
                if (urlCurrent.Contains("chrome-extension"))
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    IWebElement api_key = driver.FindElement(By.CssSelector(Element.Captcha.Input_API));
                    if (auto == true)
                    {
                        string js = "let config_captcha = {}; config_captcha['autoSubmitForms'] = true; config_captcha['autoSolveRecaptchaV2'] = true; config_captcha['autoSolveInvisibleRecaptchaV2'] = false; config_captcha['autoSolveRecaptchaV3'] = false; Config.set(config_captcha);";
                        string config = (string)driver.ExecuteScript(js);
                        api_key.Clear();
                        api_key.SendKeys(frmDash.setting.API.api_captcha);

                        driver.FindElement(By.CssSelector(Element.Captcha.Input)).Click();
                        Delay(5);
                        var alert = driver.SwitchTo().Alert();
                        alert.Accept();
                    }
                    else
                    {
                        string js = "let config_captcha = {}; config_captcha['autoSubmitForms'] = true; config_captcha['autoSolveRecaptchaV2'] = false; config_captcha['autoSolveInvisibleRecaptchaV2'] = false; config_captcha['autoSolveRecaptchaV3'] = false; Config.set(config_captcha);";
                        string config = (string)driver.ExecuteScript(js);
                        api_key.Clear();
                        Monitor.Enter(locks);
                        try
                        {
                            api_key.SendKeys(frmDash.setting.API.api_captcha);
                        }
                        finally
                        {
                            Monitor.Exit(locks);
                        }

                        driver.FindElement(By.CssSelector(Element.Captcha.Input)).Click();
                        Delay(5);
                        var alert = driver.SwitchTo().Alert();
                        alert.Accept();
                    }

                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                    //log.Info("Đã cấu hình captcha: " + frmTaki.setting.api_captcha);
                }
                else
                {
                    string current = driver.CurrentWindowHandle;
                    List<string> pages = driver.WindowHandles.ToList();
                    pages.Remove(current);
                    driver.SwitchTo().Window(pages[0]);
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                    IWebElement api_key = driver.FindElement(By.CssSelector(Element.Captcha.Input_API));
                    string js = "let config_captcha = {}; config_captcha['autoSubmitForms'] = true; config_captcha['autoSolveRecaptchaV2'] = true; config_captcha['autoSolveInvisibleRecaptchaV2'] = false; config_captcha['autoSolveRecaptchaV3'] = false; Config.set(config_captcha);";
                    string config = (string)driver.ExecuteScript(js);
                    api_key.Clear();
                    Monitor.Enter(locks);
                    try
                    {
                        api_key.SendKeys(frmDash.setting.API.api_captcha);
                    }
                    finally
                    {
                        Monitor.Exit(locks);
                    }

                    driver.FindElement(By.CssSelector(Element.Captcha.Input)).Click();
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
                    wait.Until(drv => IsAlertShown(drv));
                    var alert = driver.SwitchTo().Alert();
                    alert.Accept();
                    driver.Close();
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.StackTrace, "Setting_Captcha Error");
            }
        }


        public static bool IsAlertShown(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Alert();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #region Chức năng delay
        public static void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
            }
        }
        #endregion

    }
}
