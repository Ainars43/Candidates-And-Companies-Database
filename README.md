# HeadhuntersCandidatesDatabase
# Description

Project contains an API with CRUD using Code First.

# Usage

## This API contains these endpoints

### Candidates Controller

*Create candidate : `POST /api/candidates`

*Get candidate by Id : `GET /api/candidates/{id}`

*Update candidate : `PUT /api/candidates/{id}`

*Delete candidate : `DELETE /api/candidates/{id}`

*Get all candidates : `GET /api/candidates/getallcandidates`

*Update candidate skills : `POST /api/candidates/addskill`

*Delete candidate skills : `DELETE /api/candidates/deleteskill`

*Get candidates by skill : `GET /api/candidates/getcandidatesbyskill`

### Companies Controller

*Create company : `POST /api/companies`

*Get company by Id : `GET /api/companies/{id}`

*Update company : `PUT /api/companies/{id}`

*Delete company : `DELETE /api/companies/{id}`

*Get all companies : `GET /api/companies/getallcompanies`

*Update company positions : `POST /api/companies/addposition`

*Delete company positions : `DELETE /api/companies/deleteposition`

*Get company positions : `GET /api/companies/getcompanypositions`

*Get companies by position : `GET /api/companies/getbyposition`

*Get companies by skill : `GET /api/companies/getcompaniesbyskill`

### Positions Skills Controller

*Create position skill : `POST /api/positionsskills`

*Get position skill : `GET /api/positionsskills/{position}`

*Delete position skill : `DELETE /api/positionsskills/{position}`

### Positions Controller

*Create position : `POST /api/positions`

*Get position : `GET /api/positions/{id}`

*Delete position : `DELETE /api/positions/{id}`

### Skills Controller

*Create skill : `POST /api/skills`

*Get skill : `GET /api/skills/{id}`

*Delete skill : `DELETE /api/skills/{id}`

# Technologies Used

* .NET 7.0
* ASP.NET Core Web API;
* Entity Framework (core, sql, tools, design);
* AutoMapper;
* xUnit (FluentAssert).
