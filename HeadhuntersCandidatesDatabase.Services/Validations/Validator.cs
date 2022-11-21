using HeadhuntersCandidatesDatabase.Core.Interfaces;

namespace HeadhuntersCandidatesDatabase.Services.Validations;

public class Validator : IValidator
{
    public bool IsValid(string name)
    {
        return !string.IsNullOrEmpty(name);
    }
}