using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProgrammingUtility;

namespace ProgramminUtilityTests
{
    public class NullGuardTests
    {
        public static IEnumerable<object[]> NullGuardFailingTestData
        {
            get
            {
                yield return new object[] { new object[] { null }};
                yield return new object[] { new object[] { null, null, null } };
            }
        }

        public static IEnumerable<object[]> NullGuardSucceedingTestData
        {
            get
            {
                yield return new object[] { new object[] { new object() } };
                yield return new object[] { new object[] { new object(), new object(), new object() }};
            }
        }

        [Theory]
        [MemberData("NullGuardFailingTestData")]
        public void ThrowIfNullFailingTest(object[] arguments)
        {
            Assert.Throws(typeof(ArgumentNullException),() => NullGuard.ThrowIfNull(arguments));
        }

        [Theory]
        [MemberData("NullGuardSucceedingTestData")]
        public void ThrowIfNullSucceedingTest(object[] arguments)
        {
            //I admit, not quite sure if this is the right way to test if exception wasn't been thrown
            ArgumentNullException ex = null;

            try
            {
                NullGuard.ThrowIfNull(arguments);
            }
            catch (ArgumentNullException e)
            {
                ex = e;
            }

            Assert.Null(ex);
        }

        [Theory]
        [MemberData("NullGuardFailingTestData")]
        public void FalseIfNullFailingTest(object[] arguments)
        {
            Assert.False(NullGuard.FalseIfNull(arguments));
        }

        [Theory]
        [MemberData("NullGuardSucceedingTestData")]
        public void TrueIfNullSucceedingingTest(object[] arguments)
        {
            Assert.True(NullGuard.FalseIfNull(arguments));
        }
    }
}
