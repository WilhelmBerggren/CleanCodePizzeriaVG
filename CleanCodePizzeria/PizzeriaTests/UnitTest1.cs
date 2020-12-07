using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodePizzeria;

namespace PizzeriaTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllPizzaEntriesTest()
        {
            var p = new Program();

            var actual = p.GetPizzaMenuEntries();
            var expected = new[] { 
                "Margerita - Ost, tomatsås - 85kr", 
                "Hawaii, Ost, tomatsås, skinka, ananas - 95kr", 
                "Kebabpizza - Ost, tomatsås, kebab, champinjoner, lök, feferoni, isbergssallad, tomat, kebabsås - 105kr",
                "Quatro Stagioni - Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka - 115kr"
            };

            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void GetAllBeverageEntriesTest()
        {
            var p = new Program();

            var actual = p.GetPizzaMenuEntries();
            var expected = new[] {
                "Coca Cola - 20kr",
                "Fanta - 20kr",
                "Sprite - 25kr",
                "Quatro Stagioni - Ost, tomatsås, skinka, räkor, musslor, champinjoner, kronärtskocka - 115kr"
            };

            Assert.AreEqual(expected, actual);
        }
    }
}
