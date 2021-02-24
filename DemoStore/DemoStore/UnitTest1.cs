using DemoStore.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace DemoStore
{
    
    public class Tests
    {
        public IWebDriver webDriver = new ChromeDriver(@"c:\Program Files\Google\Chrome");

        [SetUp]
        public void Setup()
        {
           
            webDriver.Navigate().GoToUrl("https://demo.cs-cart.com/");
            Thread.Sleep(2000);
        }

        [Test]
        public void searchProductsAndAddCart()
        {
            HomeSearchBatman homePage = new HomeSearchBatman(webDriver);
            homePage.writeSearch("Batman");
            Thread.Sleep(2000);

            AddProductBatmanCart addProductCart = new AddProductBatmanCart(webDriver);
            addProductCart.addProduct();
            Thread.Sleep(10000);
     
            SearchPS2 searchPS2 = new SearchPS2(webDriver);
            searchPS2.writeSearch("PS2");
            Thread.Sleep(2000);
          

        }


        [TearDown]
        public void TearDown() => webDriver.Quit();
    }
}