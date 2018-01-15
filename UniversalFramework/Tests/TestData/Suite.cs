﻿using Unicorn.Core.Testing.Tests;
using Unicorn.Core.Testing.Tests.Attributes;

namespace Tests.TestData
{
    [TestSuite("Suite")]
    [Feature("sample")]
    public class Suite : TestSuite
    {
        public static string Output { get; set; }

        [BeforeSuite]
        public void BeforeSuite()
        {
            Output += "BeforeSuite>";
        }

        [BeforeTest]
        public void BeforeTest()
        {
            Output += "BeforeTest>";
        }

        [Test]
        public void Test2()
        {
            Output += "Test1>";
        }

        [Test]
        [Skip]
        public void TestToSkip()
        {
            Output += "TestToSkip>";
        }

        [Test]
        public void Test1()
        {
            Output += "Test2>";
            throw new System.Exception("FAILED");
        }

        [AfterTest]
        public void AfterTest()
        {
            Output += "AfterTest>";
        }

        [AfterSuite]
        public void AfterSuite()
        {
            Output += "AfterSuite";
        }
    }
}
