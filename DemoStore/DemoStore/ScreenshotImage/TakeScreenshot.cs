using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DemoStore.PageObjects;
using System;
using System.Threading;


namespace DemoStore.ScreenshotImage
{
    [TestFixture]
    public class TakeScreenshot
    {

        public IWebDriver driver;
        private string baseURL;
        public string screenshotsPasta;
        int count = 1;


        //Método para capturar screenshot da tela
        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            // OpenQA.Selenium.Screenshot foto = camera.GetScreenshot();
            var picture = camera.GetScreenshot();
            picture.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }

        [SetUp]
        public void setuptest()
        {
            driver = new ChromeDriver(@"c:\program files\google\chrome");
            driver.Manage().Window.Maximize();
            baseURL = "https://demo.cs-cart.com/";
            screenshotsPasta = @"c:\users\grace.torres\source\repos\demostoreautomation\screenshot\";
        }

        public void captureImage()
        {
            Screenshot(driver, screenshotsPasta + "Imagem_" + count++ + ".png");
            Thread.Sleep(1000);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [Test]

        public void TakeScreenshots()
        {
            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            captureImage();
            Thread.Sleep(1000);

            HomeSearchBatman homePage = new HomeSearchBatman(driver);
            homePage.writeSearch("Batman");
            Thread.Sleep(2000);
            captureImage();
            Thread.Sleep(1000);

            AddProductBatmanCart addProductCart = new AddProductBatmanCart(driver);
            addProductCart.addProduct();
            Thread.Sleep(10000);
            captureImage();
            Thread.Sleep(1000);

            SearchPS2 searchPS2 = new SearchPS2(driver);
            searchPS2.writeSearch("PS2");
            Thread.Sleep(2000);
            captureImage();
            Thread.Sleep(1000);
        }
    }
    
}

