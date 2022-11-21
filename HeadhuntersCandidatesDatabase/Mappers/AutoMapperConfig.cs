using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Mappers;

public class AutoMapperConfig
{
    public static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<CandidateRequest, Candidate>();
                cfg.CreateMap<Candidate, CandidateRequest>();

                cfg.CreateMap<CompanyRequest, Company>();
                cfg.CreateMap<Company, CompanyRequest>();

                cfg.CreateMap<SkillRequest, Skill>();
                cfg.CreateMap<Skill, SkillRequest>();

                cfg.CreateMap<PositionRequest, Position>();
                cfg.CreateMap<Position, PositionRequest>();
            });

        return config.CreateMapper();
    }
}