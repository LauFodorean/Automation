using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;

namespace SDLTradosTS
{
    [Binding]
    class OpeningTrialSDL
    {
        public static Application app;
        public static Window window;
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // deschidem aplicatia dand calea fisierului executabil
            app = Application.Launch("C:\\Program Files (x86)\\SDL\\SDL Trados Studio\\Studio5\\SDLTradosStudio.exe");
            window = app.GetWindow("Product Activation");
        }
        
        [Given(@"I have accesed my application from the computer")]
        public void GivenIHaveAccesedMyApplicationFromTheComputer()
        {
            Assert.IsNotNull(window.Title);
        }

        [When(@"I press ok button")]
        public void WhenIPressOkButton()
        {
            // cautam butonul "OK"
            SearchCriteria searchCriteria = SearchCriteria
            .ByAutomationId("_okCancelButton")
            .AndByClassName("WindowsForms10.BUTTON.app.0.33ec00f_r11_ad1");

            Button ok = (Button)window.Get(searchCriteria);
            ok.Click();
            //Assert.NotNull(ok); 
        }

        [Then(@"the applications main window should appear on screen")]
        public void ThenTheApplicationsMainWindowShouldAppearOnScreen()
        {
            
            Window mainWindow = app.GetWindow("SDL Trados Studio - Sample Project");
            Assert.NotNull(mainWindow);
        }

    }
}
