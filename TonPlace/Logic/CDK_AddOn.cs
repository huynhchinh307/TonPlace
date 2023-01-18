using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TonPlace.Logic
{
    public class CDK_AddOn
    {
        public CDK_AddOn(ChromeDriver driver)
        {
            this.driver = driver;
        }
        public ChromeDriver driver { get; set; }
        // User Token--start
        public string id { get; set; }
        public string token { get; set; }
        // User Token--end
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Click_Element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="IsSelector"></param>
        /// <param name="postion"></param>
        /// <returns></returns>
        public bool Click_Element(string element, bool IsSelector = true, int postion = 0)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
                List<IWebElement> lst_element = IsSelector == true ? driver.FindElements(By.CssSelector(element)).ToList() : driver.FindElements(By.XPath(element)).ToList();
                if (lst_element.Count == 0)
                {
                    return false;
                }
                else
                {
                    lst_element[postion].Click();
                    Delay(1);
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, element);
                return false;
            }
        }

        /// <summary>
        /// Get_Attribute_Element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attribute"></param>
        /// <param name="IsSelector"></param>
        /// <param name="postion"></param>
        /// <returns></returns>
        public string Get_Attribute_Element(string element, string attribute, bool IsSelector = true, int postion = 0)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
                List<IWebElement> lst_element = IsSelector == true ? driver.FindElements(By.CssSelector(element)).ToList() : driver.FindElements(By.XPath(element)).ToList();
                if (lst_element.Count == 0)
                {
                    return null;
                }
                else
                {
                    Delay(1);
                    return lst_element[postion].GetAttribute(attribute);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, element);
                return null;
            }
        }

        /// <summary>
        /// Input_Element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <param name="IsSelector"></param>
        /// <param name="postion"></param>
        /// <returns></returns>
        public bool Input_Element(string element, string text, bool IsSelector = true, int postion = 0)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
                List<IWebElement> lst_element = IsSelector == true ? driver.FindElements(By.CssSelector(element)).ToList() : driver.FindElements(By.XPath(element)).ToList();
                if (lst_element.Count == 0)
                {
                    return false;
                }
                else
                {
                    lst_element[postion].SendKeys(text);
                    Delay(1);
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, element);
                return false;
            }
        }

        #region Chức năng delay
        /// <summary>
        /// Delay
        /// </summary>
        /// <param name="delay"></param>
        public static void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
            }
        }
        #endregion

        public void Auth(string id, string token)
        {
            this.id = id;
            this.token = token;
        }
    }
}
