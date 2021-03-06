using System.IO;
using NUnit.Framework;
using QuizRunner.Editor;

namespace TestEditor
{
    public class Tests
    {

        [Test]
        public void SetGetName()
        {
            // arrange
            string name = "New";
            // act
            Editor a = new Editor();
            a.SetName(name);
            string actual = a.GetName();
            // assert
            Assert.AreEqual(name, actual);
        }

        [Test]
        public void SetGetDescription()
        {
            string[] desc = { "This is a new test!", "It's good." };
            Editor a = new Editor();
            a.SetDescrip(desc);
            string[] actual = a.GetDescription();
            CollectionAssert.AreEqual(desc, actual);
        }

        [Test]
        public void SetGetQuestionText()
        {
            string[] text = { "When did Bell invent the telephone?", "Enter the year." };
            int numOfQuestion = 4;
            Editor a = new Editor();
            a.SetQuestionText(text, numOfQuestion);
            string[] actual = a.GetQuestionText(numOfQuestion);
            CollectionAssert.AreEqual(text, actual);
        }


        [Test]
        public void SetGetAnwerType()
        {
            bool answtp = true;
            Editor a = new Editor();
            int numOfQuestion = 4;
            a.SetAnswType(answtp, numOfQuestion);
            bool actual = a.GetAnswerType(numOfQuestion);
            Assert.AreEqual(answtp, actual);
        }

        [Test]
        public void SetGetAnswTxt()
        {
            string answ = "1876";
            int numOfQuestion = 4;
            int numOfAnswer = 2;
            Editor a = new Editor();
            a.SetAnswText(answ, numOfQuestion, numOfAnswer);
            string actual = a.GetAnswerText(numOfQuestion, numOfAnswer);
            Assert.AreEqual(answ, actual);
        }

        [Test]
        public void SetGetAnswArgument()
        {
            string[] arg = { "[abc]", "+100" };
            string[] expected = { "[abc]", "+100" };
            int numOfQuestion = 1;
            int numOfAnswer = 1;
            Editor a = new Editor();
            a.SetAnswArgument(arg, numOfQuestion, numOfAnswer);
            string[] actual = a.GetAnswerArgument(numOfQuestion, numOfAnswer);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SetGetStatistPrefix()
        {
            string prfx = "[abc]";
            int numOfStatL = 3;
            Editor a = new Editor();
            a.SetStatPrefix(prfx, numOfStatL);
            string actual = a.GetStatPrefix(numOfStatL);
            Assert.AreEqual(prfx, actual);
        }

        [Test]
        public void SetGetStatistCalculate()
        {
            string calclt = "/100";
            int numOfStatL = 3;
            Editor a = new Editor();
            a.SetStatCalculate(calclt, numOfStatL);
            string actual = a.GetStatCalculate(numOfStatL);
            Assert.AreEqual(calclt, actual);
        }

        [Test]
        public void SetGetStatistPostfix()
        {
            string post = "%";
            int numOfStatL = 3;
            Editor a = new Editor();
            a.SetStatPostfix(post, numOfStatL);
            string actual = a.GetStatPostfix(numOfStatL);
            Assert.AreEqual(post, actual);
        }

        [Test]
        public void SaveOpen()
        {
            // arrange
            string name = "New";
            string[] desc = { "This is a new test!", "It's good." };
            string[] text = { "When did Bell invent the telephone?", "Enter the year." };
            string answ = "1876";
            string answ1 = "1877";
            //string answ2 = "1878";
            bool answtp = true;
            string[] arg = { "[abc]", "+100" };
            string[] arg1 = { "" };
            string prfx = "[abc]";
            string calclt = "/100";
            string post = "%";
            Directory.CreateDirectory("temp");
            string path = @"temp\1.txt";
            // act
            Editor a = new Editor();
            a.SetName(name);
            a.SetDescrip(desc);
            a.SetQuestionText(text, 0);
            a.SetAnswType(answtp, 0);
            a.SetAnswText(answ, 0, 0);
            a.SetAnswText(answ1, 0, 1);
            a.SetAnswArgument(arg, 0, 0);
            a.SetAnswArgument(arg1, 0, 1);
            a.ListOfVariables.Add("new", 152);
            a.SetStatPrefix(prfx, 0);
            a.SetStatCalculate(calclt, 0);
            a.SetStatPostfix(post, 0);
            a.Save(path);
            Editor actual = new Editor();
            //actual = a;
            actual.Open(path);
            // assert
            Assert.AreEqual(a.GetName(), actual.GetName());
            CollectionAssert.AreEqual(a.GetDescription(), actual.GetDescription());
            CollectionAssert.AreEqual(a.GetQuestionText(0), actual.GetQuestionText(0));
            Assert.AreEqual(a.GetAnswerType(0), actual.GetAnswerType(0));
            Assert.AreEqual(a.GetAnswerText(0, 0), actual.GetAnswerText(0, 0));
            Assert.AreEqual(a.GetAnswerText(0, 1), actual.GetAnswerText(0, 1));
            CollectionAssert.AreEqual(a.GetAnswerArgument(0, 0), actual.GetAnswerArgument(0, 0));
            CollectionAssert.AreEqual(a.GetAnswerArgument(0, 1), actual.GetAnswerArgument(0, 1));
            Assert.AreEqual(a.ListOfVariables["new"], actual.ListOfVariables["new"]);
            Assert.AreEqual(a.GetStatPrefix(0), actual.GetStatPrefix(0));
            Assert.AreEqual(a.GetStatCalculate(0), actual.GetStatCalculate(0));
            Assert.AreEqual(a.GetStatCalculate(0), actual.GetStatCalculate(0));
            Directory.Delete("temp", true);
        }

        [Test]
        public void GetNumberOfQuestions()
        {
            int num = 2;
            string[] text = { "When did Bell invent the telephone?", "Enter the year." };
            string[] text1 = { "Why did Bell invent the telephone?", "Enter the year." };
            Editor a = new Editor();
            a.SetQuestionText(text, 0);
            a.SetQuestionText(text1, 1);
            int actual = a.GetNumberOfQuestion();
            Assert.AreEqual(num, actual);
        }

        [Test]
        public void GetNumberOfAnswers()
        {
            int num = 2;
            string answ = "1876";
            string answ1 = "1877";
            Editor a = new Editor();
            a.SetAnswText(answ, 0, 0);
            a.SetAnswText(answ1, 0, 1);
            int actual =a.GetNumberOfAnswers(0);
            Assert.AreEqual(num, actual);
        }

        [Test]
        public void GetNumberOfStatLine()
        {
            int num = 2;
            string prfx = "[abc]";
            string calclt = "/100";
            string post = "%";
            string prfx1 = "[cde]";
            string calclt1 = "/100";
            string post1 = "%";
            Editor a = new Editor();
            a.SetStatPrefix(prfx, 0);
            a.SetStatCalculate(calclt, 0);
            a.SetStatPostfix(post, 0);
            a.SetStatPrefix(prfx1, 1);
            a.SetStatCalculate(calclt1, 1);
            a.SetStatPostfix(post1, 1);
            int actual = a.GetNumberOfStatLine();
            Assert.AreEqual(num, actual);
        }

        [Test]
        public void GetNumberOfArgument()
        {
            int num = 2;
            string[] arg = { "[abc]", "+100" };
            Editor a = new Editor();
            a.SetAnswArgument(arg, 0, 0);
            int actual = a.GetNumberOfArgument(0, 0);
            Assert.AreEqual(num, actual);
        }

        [Test]
        public void Correctness()
        {
            string input = "-100+2009+[abc]=(100)+[abc]";

            // First symbol
            string input_wrong = "*(-[abc]) = [abc]           +((-100)       ) + 60*20";

            // Operation signs
            string input_wrong1 = "(-[abc]) = [abc]           ++((-100)       ) + 60*20";

            // Paired brackets
            string input_wrong2 = "[abc]=[])";

            // Last symbol
            string input_wrong3 = "[abc]=[abc]+100-";

            // Extraneous characters outside of square brackets
            string input_wrong4 = "[abc]=[abc]+100�";

            // Amount of equal signs
            string input_wrong5 = "[abc]==[abc�]+100=";

            // The equal sign with no operand
            string input_wrong6 = "100+67=";

            // Inside square brackets
            string input_wrong7 = "[abc]=[abc!]";

            bool expected = true;
            Editor a = new Editor();
            bool actual = a.CheckIsCorrect(input);
            bool actual1 = a.CheckIsCorrect(input_wrong);
            bool actual2 = a.CheckIsCorrect(input_wrong1);
            bool actual3 = a.CheckIsCorrect(input_wrong2);
            bool actual4 = a.CheckIsCorrect(input_wrong3);
            bool actual5 = a.CheckIsCorrect(input_wrong4);
            bool actual6 = a.CheckIsCorrect(input_wrong5);
            bool actual7 = a.CheckIsCorrect(input_wrong6);
            bool actual8 = a.CheckIsCorrect(input_wrong7);
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(expected, actual1);
            Assert.AreNotEqual(expected, actual2);
            Assert.AreNotEqual(expected, actual3);
            Assert.AreNotEqual(expected, actual4);
            Assert.AreNotEqual(expected, actual5);
            Assert.AreNotEqual(expected, actual6);
            Assert.AreNotEqual(expected, actual7);
            Assert.AreNotEqual(expected, actual8);
        }
    }
}