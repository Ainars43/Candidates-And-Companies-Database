using FluentAssertions;
using HeadhuntersCandidatesDatabase.Services.Validations;

namespace HeadhuntersCandidatesDatabase.Tests.Models.Tests;

public class PositionTests
{
    private readonly Validator _validator = new();

    [Fact]
    public void PositionName_AddNullValue_ReturnFalse()
    {
        var position = new Core.Models.Position()
        {
            Name = null
        };

        _validator.IsValid(position.Name).Should().BeFalse();
    }

    [Fact]
    public void PositionName_AddEmptyValue_ReturnFalse()
    {
        var position = new Core.Models.Position()
        {
            Name = ""
        };

        _validator.IsValid(position.Name).Should().BeFalse();
    }

    [Fact]
    public void PositionName_AddValidValue_ReturnTrue()
    {
        var position = new Core.Models.Position()
        {
            Name = "Developer"
        };

        _validator.IsValid(position.Name).Should().BeTrue();
    }
}