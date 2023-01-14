using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonPlace.Logic
{
    public class CDK_AddOn
    {
        public CDK_AddOn(ChromeDriver driver)
        {
            this.driver = driver;
        }
        public ChromeDriver driver { get; set; }
        private Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Hỗ trợ click element không gây ra lỗi
        /// </summary>
        /// <param name="element">Chuỗi Element</param>
        /// <param name="IsSelector">Loại truy vấn</param>
        /// <param name="postion">Vị trí element</param>
        /// <returns>Bool</returns>
        public bool Click_Element(string element, bool IsSelector = true, int postion = 0)
        {
            try
            {
                List<IWebElement> lst_element = IsSelector == true ? driver.FindElements(By.CssSelector(element)).ToList() : driver.FindElements(By.XPath(element)).ToList();
                if (lst_element.Count == 0)
                {
                    return false;
                }
                else
                {
                    lst_element[postion].Click();
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
        /// Hỗ trợ Get Attribute của element không gây ra lỗi
        /// </summary>
        /// <param name="element">Chuỗi Element</param>
        /// <param name="attribute">Thuộc tính Attribute</param>
        /// <param name="IsSelector">Loại truy vấn</param>
        /// <param name="postion">Vị trí element</param>
        /// <returns></returns>
        public string Get_Attribute_Element(string element, string attribute, bool IsSelector = true, int postion = 0)
        {
            try
            {
                List<IWebElement> lst_element = IsSelector == true ? driver.FindElements(By.CssSelector(element)).ToList() : driver.FindElements(By.XPath(element)).ToList();
                if (lst_element.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lst_element[postion].GetAttribute(attribute);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, element);
                return null;
            }
        }

        public bool Input_Element(string element, string text, bool IsSelector = true, int postion = 0)
        {
            try
            {
                List<IWebElement> lst_element = IsSelector == true ? driver.FindElements(By.CssSelector(element)).ToList() : driver.FindElements(By.XPath(element)).ToList();
                if (lst_element.Count == 0)
                {
                    return false;
                }
                else
                {
                    lst_element[postion].SendKeys(text);
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, element);
                return false;
            }
        }
    }
}
