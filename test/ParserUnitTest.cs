using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using static test.Parser;

[TestFixture]
    class ParserUnitTest
    {
        [TestCase("aaaa sdasd ddd ",1)]
        [TestCase("sadsad ddg aas ",0)]
        public void Should_Return_Vowels_Characters_Only_Count(string testText,int z)
        {
            test.Parser parse = new test.Parser("path");
            var result = parse.Parse(testText);
            Assert.AreEqual(testText,z);
        }

    }