using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagParser.Lib.Model;

namespace TagParser.Tests
{
    /// <summary>
    /// Summary description for TagTest
    /// </summary>
    [TestClass]
    public class TagTest
    {
        public TagTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void EA_TEXT_StringShouldBeConvertedTo_TagObject()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'>#FFFFFF</EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.IsNotNull(tag);
        }

        [TestMethod]
        public void EA_TEXT_NameAttributeShouldBe_Module1Orange()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'>#FFFFFF</EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.AreEqual("Module 1 Orange", tag.Name);
        }

        [TestMethod]
        public void EA_TEXT_NameAttributeShouldBe_BlankWhenAttributeNotPresent()
        {
            string tagContent = @"<EA_TXT>#FFFFFF</EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.AreEqual(null, tag.Name);
        }

        [TestMethod]
        public void EA_TEXT_DefaultValueShouldBe_FFFFFF()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'>#FFFFFF</EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.AreEqual("#FFFFFF", tag.DefaultValue);
        }

        [TestMethod]
        public void EA_TEXT_DefaultValueShouldBeBlank_WhenEmptyValue()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'></EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.AreEqual(string.Empty, tag.DefaultValue);
        }

        [TestMethod]
        public void EA_TEXT_ShouldShowParseError()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.IsTrue(tag.ParseErrors.Count > 0);
        }

        [TestMethod]
        public void EA_TEXT_TagTypeShouldBe_EATXT()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'></EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.AreEqual(tag.Type,"EA_TXT");
        }

        [TestMethod]
        public void EA_TEXT_ShouldnotBeAnyChildren()
        {
            string tagContent = @"<EA_TXT name='Module 1 Orange'></EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.IsNull(tag.Childern);
        }

        [TestMethod]
        public void EA_TEXT_IdParsedSuccessully_123()
        {
            string tagContent = @"<EA_TXT id='123' name='Module 1 Orange'></EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.AreEqual(tag.Id,"123");
        }

        [TestMethod]
        public void EA_TEXT_ShouldBeGenerateNewIdWhenIdnotSpecified()
        {
            string tagContent = @"<EA_TXT  name='Module 1 Orange'></EA_TXT>";
            Tag tag = new EaTextTag(new HtmlTagContent(tagContent), 0, tagContent.Length);
            Assert.IsTrue(tag.Id.Length > 10);
        }
    }
}
