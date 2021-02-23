using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoStore.PageObjects
{
    class SearchPS2
    {
        private IWebDriver Driver { get; }

        public SearchPS2(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebElement inputSearch => Driver.FindElement(By.Id("search_input"));
        IWebElement btnSearch => Driver.FindElement(By.ClassName("ty-search-magnifier"));
        //IWebElement btnSearch => Driver.FindElement(By.XPath("//button[@title='Pesquisar']"));
        IWebElement listEmpty => Driver.FindElement(By.XPath("//div[@class='ty-mainbox-body']/div/div"));
        
        public void writeSearch(string search)
        {
            inputSearch.SendKeys(search);
            btnSearch.Submit();
        }

        public void resultListEmpty(string attributeName)
        {
            listEmpty.GetAttribute(attributeName);
        }
    }

}
