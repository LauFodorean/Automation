using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TabItems;

namespace SDLTradosTS
{
    [Binding]
    public class ChangeLanguageSteps
    {
        public static Application app;
        public static Window window;
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // deschidem aplicatia dand calea fisierului executabil
            app = Application.Launch("C:\\Program Files (x86)\\SDL\\SDL Trados Studio\\Studio5\\SDLTradosStudio.exe");
            window = app.GetWindow("Product Activation");
            
            SearchCriteria searchCriteria = SearchCriteria
            .ByAutomationId("_okCancelButton")
            .AndByClassName("WindowsForms10.BUTTON.app.0.33ec00f_r11_ad1");

            Button ok = (Button)window.Get(searchCriteria);
            ok.Click();
            window = app.GetWindow("SDL Trados Studio - Sample Project");
                        
        }

        [Given(@"I am in the main window of the application")]
        public void GivenIAmInTheMainWindowOfTheApplication()
        {
            Assert.IsNotNull(window.Title);
        }

        [When(@"I press the User Interface Language in the View tab item")]
        public void WhenIPressTheUserInterfaceLanguageInTheViewTabItem()
        {
            SearchCriteria searchCriteria1 = SearchCriteria.ByAutomationId("viewRibbon").AndByText("View");
            TabPage view = (TabPage)window.Get(searchCriteria1);
            view.Click();
            
            SearchCriteria searchCriteria2 = SearchCriteria
                .ByAutomationId("[Group : userInterfaceRibbonGroup Tools] Tool : IgCommandBarAction:UserInterfaceLanguageAction - Index : 0 ")
                .AndByText("User Interface Language");
            Button userInterfaceLanguage = (Button)window.Get(searchCriteria2);
            userInterfaceLanguage.Click();

        }

        [Then(@"The User Interface Language window appears allowing me to select anothe language")]
        public void ThenTheUserInterfaceLanguageWindowAppearsAllowingMeToSelectAnotheLanguage()
        {
            SearchCriteria searchCriteria3 = SearchCriteria.ByAutomationId("UserInterfaceLanguageDialog")
                .AndByClassName("WindowsForms10.Window.8.app.0.33ec00f_r11_ad1");
            Assert.NotNull(searchCriteria3);
        }

    }
}
