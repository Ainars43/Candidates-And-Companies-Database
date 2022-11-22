using FluentAssertions;
using HeadhuntersCandidatesDatabase.Services.Validations;

namespace HeadhuntersCandidatesDatabase.Tests.Models.Tests;

public class CanidateTests
{
    private readonly Validator _validator = new();

    [Fact]
    public void CandidateName_AddNullValue_ReturnFalse()
    {
        var candidate = new Core.Models.Candidate()
        {
            Name = null
        };

        _validator.IsValid(candidate.Name).Should().BeFalse();
    }

    [Fact]
    public void CandidateName_AddEmptyValue_ReturnFalse()
    {
        var candidate = new Core.Models.Candidate()
        {
            Name = ""
        };

        _validator.IsValid(candidate.Name).Should().BeFalse();
    }

    [Fact]
    public void CandidateName_AddValidValue_ReturnTrue()
    {
        var candidate = new Core.Models.Candidate()
        {
            Name = "John"
        };

        _validator.IsValid(candidate.Name).Should().BeTrue();
    }
}