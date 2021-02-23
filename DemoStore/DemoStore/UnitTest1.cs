using DemoStore.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace DemoStore
{
    public class Tests
    {
        IWebDriver webDriver = new ChromeDriver(@"c:\Program Files\Google\Chrome");
        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://demo.cs-cart.com/stores/090e9b8116f9a3d9/");
            Thread.Sleep(2000);
        }

        [Test]
        public void searchProductBatman()
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
            //searchPS2.resultListEmpty("ty-no-items cm-pagination-container  ");

        }

        
        [TearDown]
        public void TearDown() => webDriver.Quit();
    }
}