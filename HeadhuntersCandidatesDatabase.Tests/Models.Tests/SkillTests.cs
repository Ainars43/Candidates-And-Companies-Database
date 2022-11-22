using FluentAssertions;
using HeadhuntersCandidatesDatabase.Services.Validations;

namespace HeadhuntersCandidatesDatabase.Tests.Models.Tests;

public class SkillTests
{
    private readonly Validator _validator = new();

    [Fact]
    public void SkillName_AddNullValue_ReturnFalse()
    {
        var skill = new Core.Models.Skill()
        {
            Name = null
        };

        _validator.IsValid(skill.Name).Should().BeFalse();
    }

    [Fact]
    public void SkillName_AddEmptyValue_ReturnFalse()
    {
        var skill = new Core.Models.Skill()
        {
            Name = ""
        };

        _validator.IsValid(skill.Name).Should().BeFalse();
    }

    [Fact]
    public void SkillName_AddValidValue_ReturnTrue()
    {
        var skill = new Core.Models.Skill()
        {
            Name = "C#"
        };

        _validator.IsValid(skill.Name).Should().BeTrue();
    }
}