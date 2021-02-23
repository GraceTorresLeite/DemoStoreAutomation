using DemoStore.PageObjects;
using DemoStore.ScreenshotImage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace DemoStore
{
    public class Tests
    {
        IWebDriver webDriver = new ChromeDriver(@"c:\Program Files\Google\Chrome");
        //public string screenshotsPasta;
        [SetUp]
        public void Setup()
        {
           // screenshotsPasta = @"c:\users\grace.torres\source\repos\demostoreautomation\screenshot\";
            webDriver.Navigate().GoToUrl("https://demo.cs-cart.com/stores/090e9b8116f9a3d9/");
            Thread.Sleep(2000);
        }

        [Test]
        public void searchProductsAndAddCart()
        {
            HomeSearchBatman homePage = new HomeSearchBatman(webDriver);
            homePage.writeSearch("Batman");
            Thread.Sleep(2000);

            //TakeScreenshot imageCapture = new TakeScreenshot();
            //imageCapture.Screenshot(webDriver, screenshotsPasta);
            //imageCapture.TakeScreenshots();
            //Thread.Sleep(2000);

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