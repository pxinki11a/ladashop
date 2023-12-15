using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ladashopq;
using System.Net;

namespace AutoshopTests1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void TestMethod1()
        {
            string Password = "qweqwe";
            string Login = "test";
            bool assert = tests.ValidatedUser(Login, Password);
            Assert.IsFalse(assert);
        }

        [TestMethod()]
        public void TestMethod2CorrectLogin()
        {
            string Password = "qwe";
            string Login = "qwe";
            bool assert = tests.ValidatedUser(Login, Password);
            Assert.IsTrue(assert);
        }

        [TestMethod()]
        
        public void TestMethod3IncorrectLogin()
        {
            Assert.AreEqual(false, tests.ValidatedUser("asda", "1231"));
        }

        [TestMethod()]
        public void TestMethod4FindTovar()
        {

                Assert.AreEqual(true, tests.Tovar("Вал"));
        }

        [TestMethod()]
        public void TestMethod5FindUndefinedTovar()
        {
            Assert.AreEqual(false, tests.Tovar("Тормоза"));
        }


    }

}
