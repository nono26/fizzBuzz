using src;
using Xunit;

namespace UnitTest;

public class FizzBuzzTests
{
    private FizzBuzz _sut;
    private List<Criteria> criterias;

    public FizzBuzzTests()
    {
        criterias = new List<Criteria>
        {
            new Criteria { Number = [3], Expected = "Fizz" },
            new Criteria { Number = [5], Expected = "Buzz" },
            new Criteria { Number = [3,5], Expected = "FizzBuzz" }
        };
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    public void NumberIsNotAMultipleOf3(int input, string expected)
    {
        //Arange
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.Get(input);
        //Assert
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    public void NumberIsAMultipleOf3(int input)
    {
        //Arange
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.Get(input);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("Fizz", result);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void NumberIsAMultipleOf5(int input)
    {
        //Arange
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.Get(input);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("Buzz", result);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    public void NumberIsAMultipleOf3And5(int input)
    {
        //Arange
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.Get(input);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("FizzBuzz", result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void NumberIsLessThan1(int input)
    {
        //Arange
        _sut = new FizzBuzz(criterias);
        //Act
        var exception = Assert.Throws<ArgumentException>(() => _sut.Get(input));
        //Assert
        Assert.NotNull(exception);
        Assert.Equal("Input must be greater than 0", exception.Message);
    }

    [Fact]
    public void GetWithMultipleCriteria1_ReturnsSucces()
    {
        //Arange
        var criterias = new List<Criteria>
        {
            new Criteria { Number = [7], Expected = "Test" }
        };
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.GetWithMultipleCriteria(14);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result);
    }

    [Fact]
    public void GetWithMultipleCriteria2_ReturnsSucces()
    {
        //Arange
        var criterias = new List<Criteria>
        {
            new Criteria { Number = [7,100], Expected = "Test" }
        };
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.GetWithMultipleCriteria(700);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result);
    }
    [Fact]
    public void GetWithMultipleCriteria3_ReturnsFailed()
    {
        //Arange
        var criterias = new List<Criteria>
        {
            new Criteria { Number = [7,100], Expected = "Test" }
        };
        _sut = new FizzBuzz(criterias);
        //Act
        var result = _sut.GetWithMultipleCriteria(699);
        //Assert
        Assert.NotNull(result);
        Assert.Equal("699", result);
    }
}