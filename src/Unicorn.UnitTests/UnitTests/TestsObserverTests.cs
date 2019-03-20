﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Unicorn.Taf.Core.Engine;

namespace Unicorn.UnitTests.Tests
{
    [TestFixture]
    public class TestsObserverTests
    {
        [Test, Author("Vitaliy Dobriyan")]
        public void TestTestsObserverSearchTestSuites()
        {
            IEnumerable<Type> foundSuites = TestsObserver.ObserveTestSuites(Assembly.GetExecutingAssembly());
            Assert.AreEqual(5, foundSuites.Count());
        }

        [Test, Author("Vitaliy Dobriyan")]
        public void TestTestsObserverSearchTests()
        {
            IEnumerable<MethodInfo> foundTests = TestsObserver.ObserveTests(Assembly.GetExecutingAssembly());
            Assert.AreEqual(22, foundTests.Count());
        }
    }
}
