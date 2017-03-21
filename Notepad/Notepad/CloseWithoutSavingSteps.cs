using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace Notepad
{
    [Binding]
    class CloseWithoutSavingSteps
    {
        public static Application app;
        public static Window window;
        public static Window windowWithMessage;
        public static Button closeButton;
        public static TextBox textMessage;
        public static TextBox text;
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            app = Application.Launch(@"C:\Windows\System32\notepad.exe");
            window = app.GetWindow("Untitled - Notepad");
        }

        [AfterTestRun]
        public static void AfterTestRun() 
        {
            window.Close();
        }

        [Given(@"I have opened the notepad application")]
        public void GivenIHaveOpenedTheNotepadApplication()
        {
            Console.Write("Target application name " + window.Title);
            Assert.IsNotNull(window.Title);
        }

        [Given(@"I have writen something in the editing area")]
        public void GivenIHaveWritenSomethingInTheEditingArea()
        {
            Console.Write("I write something in the editing area");
           
            System.IO.StreamWriter file = new System.IO.StreamWriter("d:\\test\\test.txt");
            file.WriteLine("test");

        }

        [When(@"I click on close button")]
        public void WhenIClickOnCloseButton()
        {
            Console.Write("I will click on the notepad's window close button");
            closeButton = window.Get<Button>("Close");
            closeButton.Focus();

        }

        [Then(@"I should see a new window with a message asking me if I want to save the file")]
        public void ThenIShouldSeeANewWindowWithAMessageAskingMeIfIWantToSaveTheFile()
        {
            Console.Write("The message asking us if we want to save should appear");
            textMessage = (TextBox)window.Get<TextBox>("Main Instruction");
            Assert.AreEqual("Do you want to save changes to d:\\test\\.txt?", textMessage);

        }

    }
}
