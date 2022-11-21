using System.ComponentModel.DataAnnotations;
using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Core.Models;

public class Position : Entity
{
    public string Name { get; set; }
}