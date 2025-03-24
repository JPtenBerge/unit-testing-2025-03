using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.MSTest;

[TestClass]
public class AutocompleterTests
{
    Autocompleter<Car> _sut = null!;
    NepNavigateService _nepNavigateService = null!;
    List<Car> _data = null!;

    [TestInitialize]
    public void Init()
    {
        _data = new List<Car>
        {
            new() { Make = "Tesla", Model = "Model Y" },
            new() { Make = "Peugeot", Model = "208" },
            new() { Make = "Kia", Model = "Miro" },
            new() { Make = "Opel", Model = "Astra" },
            new() { Make = "Opel", Model = "Corsa" },
            new() { Make = "Renault", Model = "Clio" },
            new() { Make = "Volkswagen", Model = "Golf" },
            new() { Make = "Renault", Model = "Twingo" },
            new() { Make = "Fiat", Model = "Punto" },
            new() { Make = "Toyota", Model = "Yaris" },
        };
        _nepNavigateService = new();
        _sut = new Autocompleter<Car>(_nepNavigateService);
        _sut.Data = _data;
    }


    [TestMethod]
    public void Autocomplete_HappyFlowQueryAndData_SuggestsMatchingCars()
    {
        // Arrange
        _sut.Query = "s";

        // Act
        _sut.Autocomplete();

        // Assert
        Assert.AreEqual(5, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void Autocomplete_CapitalizedQuery_SuggestCaseInsensitively()
    {
        // Arrange
        _sut.Query = "S";

        // Act
        _sut.Autocomplete();

        // Assert
        Assert.AreEqual(5, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void Autocomplete_QueryThatMatchesMultipleProperties_AddsSuggestionsUniquely()
    {
        // Arrange
        _sut.Query = "i";

        // Act
        _sut.Autocomplete();

        // Assert
        Assert.AreEqual(5, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void Autocomplete_EmptyQuery_AllSuggestions()
    {
        // Arrange
        _sut.Query = "";

        // Act
        _sut.Autocomplete();

        // Assert
        Assert.AreEqual(_data.Count, _sut.Suggestions.Count);
    }

    [TestMethod]
    //[ExpectedException(typeof(NullReferenceException))]
    public void Autocomplete_NoData_Throws()
    {
        // Arrange
        _sut.Query = "e";
        _sut.Data = null!;

        // Act
        //_sut.Autocomplete();
        //var act = () => _sut.Autocomplete();

        // Assert
        Assert.ThrowsException<InvalidOperationException>(() => _sut.Autocomplete());
    }

    [TestMethod]
    public void Next_WithSuggestions_UsesNavigateService()
    {
        // Arrange
        _sut.Query = "e";
        _sut.Autocomplete(); // black box

        //_sut.Suggestions = new List<Car>(); // white box
        //_sut.HighlightedIndex = 3;

        // Act
        _sut.Next();

        // Assert
        Assert.IsTrue(_nepNavigateService.HasNextBeenCalled);
    }
}
