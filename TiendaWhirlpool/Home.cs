using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace TiendaWhirlpool
{
    public class Home
    {
        public static Boolean IsAt()
        {
            Boolean is_at = false;
            IReadOnlyCollection<IWebElement> dropdownElements =
                Driver.Instance.FindElements(By.ClassName("dropdown-toggle"));
            foreach (IWebElement dropdownElement in dropdownElements)
            {
                if (dropdownElement.Text.Contains("Sarah")) is_at=true;
                else
                {
                    is_at = false;
                }

            }
            return is_at;
        }
    }

}
