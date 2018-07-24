﻿using NUnit.Framework;
using Unicorn.UnitTests.BO;
using Unicorn.Core.Testing.Verification;
using static Unicorn.Core.Testing.Verification.Matchers.Is;

namespace Unicorn.UnitTests.Tests
{
    [TestFixture]
    public class AssertionsTest
    {
        [Test, Author("Vitaliy Dobriyan")]
        public void TestSoftAssertion()
        {
            NUnit.Framework.Assert.Throws<AssertionError>(delegate 
            {
                Verify assert = new Verify();
                assert.VerifyThat("asd", EqualTo("asd"))
                    .VerifyThat(2, EqualTo(2))
                    .VerifyThat(new SampleObject(), EqualTo(new SampleObject("ds", 234)))
                    .VerifyThat(new SampleObject(), EqualTo(new SampleObject()));

                assert.AssertAll();
            });
        }

        [Test, Author("Vitaliy Dobriyan")]
        public void TestAssertion()
        {
            NUnit.Framework.Assert.Throws<AssertionError>(delegate
            {
                Core.Testing.Verification.Assert.That("as2d", EqualTo("asd"));
            });
        }
    }
}
