namespace HeadhuntersCandidatesDatabase.Services.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException() : base("This skill is already added!") { }
}