using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

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
            baseURL = "https://demo.cs-cart.com/stores/090e9b8116f9a3d9/";
            screenshotsPasta = @"c:\users\grace.torres\source\repos\demostoreautomation\screenshot\";
        }

        public void capturaImagem()
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
            capturaImagem();
            Thread.Sleep(1000);
        }
    }
    
}

