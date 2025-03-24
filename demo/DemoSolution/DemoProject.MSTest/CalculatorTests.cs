using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.MSTest;

[TestClass]
public sealed class CalculatorTests
{
    Calculator _sut = null!;

    [TestInitialize]
    public void Init()
    {
        // system under test
        _sut = new Calculator();
    }


    // FunctieDieJeTestResultaat()
    // WatBeginStaatVerwachteResultaat()
    // AddPositiveNumbersShouldAddEverything()

    // given-when-then
    // arrange-act-assert
    // AddWithPositiveNumbersShouldAddEverything()
    // Add_PositiveNumbers_AddEverything()
    // Add_With_Positive_Numbers_Should_Really_Do_Something_Special()


    [TestMethod]
    public void Add_PositiveNumbers_AddEverything()
    {
        // Act
        _sut.Add(4);
        _sut.Add(8);
        _sut.Add(15);

        // Assert
        Assert.AreEqual(27, _sut.Result);
    }


    [TestMethod]
    public void TestMethod1()
    {
        //Assert.AreEqual("hoi", "doei");

        //"hoi".Should().Be("doei");
    }

    [TestMethod]
    public void DontDoThisAtHomeAndPreferablyNotAtWorkEither()
    {
        // reflection: naar je code kijken / introspectie
        //var ding = new Calculator();
        //var methods = ding.GetType().GetMethods(System.Reflection.BindingFlags.NonPublic);
        //methods[1].Invoke();
    }
}
