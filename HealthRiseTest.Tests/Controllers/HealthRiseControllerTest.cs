using HealthRiseTest.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRiseTest.Tests.Controllers
{
    [TestClass]
    public class HealthRiseControllerTest
    {
        #region UpperCase
        [TestMethod]
        public void ContainsUpperCase()
        {
            // Arrange
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsUpperCase", "MYPASSWORD");
            // Assert
            Assert.IsTrue(result);

            result = (bool)classToTest.Invoke("containsUpperCase", "MYsuperPASSWORD");
            Assert.IsTrue(result);

            result = (bool)classToTest.Invoke("containsUpperCase", "Msuper357");
            Assert.IsTrue(result);

            result = (bool)classToTest.Invoke("containsUpperCase", "sup34^4I");
            Assert.IsTrue(result);

            result = (bool)classToTest.Invoke("containsUpperCase", "sup34^4Ö");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NotContainsUpperCase()
        {
            // Arrange
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsUpperCase", "abcdef");
            // Assert
            Assert.IsFalse(result);
            result = (bool)classToTest.Invoke("containsUpperCase", "456abcdef123");
            Assert.IsFalse(result);
            result = (bool)classToTest.Invoke("containsUpperCase", "456abcdef123%&^");
            Assert.IsFalse(result);

        }
        #endregion
        #region SpecialCharacters
        [TestMethod]
        public void ContainsSpecialCharacters()
        {
            // Arrange
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsSpecialCharacters", "asoij$%^$");
            // Assert
            Assert.IsTrue(result);

            result = (bool)classToTest.Invoke("containsSpecialCharacters", "$%^$_");
            Assert.IsTrue(result);

            result = (bool)classToTest.Invoke("containsSpecialCharacters", "_asoij");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsNoSpecialCharacters()
        {
            // Arrange
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsSpecialCharacters", "asoij129Ö8374POIJ");
            // Assert
            Assert.IsFalse(result);
        }
        #endregion
        #region LowerCase
        [TestMethod]
        public void ContainsLowerCase()
        {
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsLowerCase", "asoij$%^$");
            Assert.IsTrue(result);

            Assert.IsTrue((bool)classToTest.Invoke("containsLowerCase", "ASOPIJSoij"));
            Assert.IsTrue((bool)classToTest.Invoke("containsLowerCase", "ASOPIJSö"));
            Assert.IsTrue((bool)classToTest.Invoke("containsLowerCase", "ASOPIJSoijASDF"));
        }

        [TestMethod]
        public void NotContainsLowerCase()
        {
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsLowerCase", "ASOIJF%^$");
            Assert.IsFalse(result);
        }
        #endregion
        #region Numbers
        [TestMethod]
        public void containsNumbers()
        {
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsLowerCase", "asoij123$%^$");
            Assert.IsTrue(result);

            Assert.IsTrue((bool)classToTest.Invoke("containsLowerCase", "123ASOPIJSoij"));
            Assert.IsTrue((bool)classToTest.Invoke("containsLowerCase", "ASOPIJSö645"));
            Assert.IsTrue((bool)classToTest.Invoke("containsLowerCase", "ASOPIJS6oijASDF"));
        }
        [TestMethod]
        public void NotContainsNumbers()
        {
            HealthRiseController controller = new HealthRiseController();
            PrivateObject classToTest = new PrivateObject(controller);

            // Act
            bool result = (bool)classToTest.Invoke("containsLowerCase", "ASOIasfJF%^$");
            Assert.IsTrue(result);
        }
        #endregion
    }
}
