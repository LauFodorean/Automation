using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;


namespace Notepad
{
    [Binding]
    class CloseWithoutSavingSteps
    {
        public static Application app;
        public static Window window;
        public static Button closeButton;
        
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            app = Application.Launch(@"notepad.exe");
            window = app.GetWindow("Untitled - Notepad");
        }

        //[AfterTestRun]
        //public static void AfterTestRun() 
        //{
        //    window.Close();
        //}

        [Given(@"I have opened the notepad application")]
        public void GivenIHaveOpenedTheNotepadApplication()
        {
            Assert.IsNotNull(window.Title);
        }

        [Given(@"I have writen something in the editing area")]
        public void GivenIHaveWritenSomethingInTheEditingArea()
        {
            SearchCriteria searchCriteria = SearchCriteria
                .ByClassName("Edit");

            TextBox textBox = (TextBox)window.Get(searchCriteria);
            textBox.Text = "TEST DE TEST :)";
           
            Assert.AreEqual(1, 1);
        }

        [When(@"I click on close button")]
        public void WhenIClickOnCloseButton()
        {
            closeButton = window.Get<Button>("Close");
            closeButton.Click();

        }

        [Then(@"I should see a new window with a message asking me if I want to save the file and click on Don't save")]
        public void clickDonTSave()
        {
            // cautam butonul de Don't save
            SearchCriteria searchCriteria = SearchCriteria
            .ByAutomationId("CommandButton_7")
            .AndByClassName("CCPushButton");

            Button dontSave = (Button)window.Get(searchCriteria);
            dontSave.Click();
            Assert.NotNull(dontSave);
        }


    }
}
