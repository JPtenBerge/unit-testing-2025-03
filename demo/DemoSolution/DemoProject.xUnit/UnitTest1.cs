using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;

namespace DemoProject.xUnit;

public class UnitTest1
{
    Autocompleter<Car> _sut = null!;
    //NepNavigateService _nepNavigateService = null!;

    INavigateService _navigateServiceMock = null!;

    List<Car> _data = null!;

    public UnitTest1()
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
        //_nepNavigateService = new();
        _navigateServiceMock = A.Fake<INavigateService>();

        A.CallTo(() => _navigateServiceMock.Next(A<List<Car>>._, A<int?>._)).Returns(48);

        _sut = new Autocompleter<Car>(_navigateServiceMock);
        _sut.Data = _data;
    }


    [Fact]
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
        A.CallTo(() => _navigateServiceMock.Next(A<List<Car>>._, A<int?>._)).MustHaveHappened();
        Assert.Equal(48, _sut.HighlightedIndex);
    }
}
