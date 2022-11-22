using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Services.Validations;

namespace HeadhuntersCandidatesDatabase.Tests.Models.Tests;

public class CompanyTests
{
    private readonly Validator _validator = new();

    [Fact]
    public void CompanyName_AddNullValue_ReturnFalse()
    {
        var company = new Core.Models.Company()
        {
            Name = null
        };

        _validator.IsValid(company.Name).Should().BeFalse();
    }

    [Fact]
    public void CompanyName_AddEmptyValue_ReturnFalse()
    {
        var company = new Core.Models.Company()
        {
            Name = ""
        };

        _validator.IsValid(company.Name).Should().BeFalse();
    }

    [Fact]
    public void CompanyName_AddValidValue_ReturnTrue()
    {
        var company = new Core.Models.Company()
        {
            Name = "Google"
        };

        _validator.IsValid(company.Name).Should().BeTrue();
    }
}