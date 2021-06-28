using AutoMapper;
using Projeto.Base.Domain.Commands.Students.Create;
using Projeto.Base.Domain.Dto;
using Projeto.Base.Domain.Entities;
using Projeto.Base.Domain.Queries.Students.GetAllStudents;
using Projeto.Base.Domain.Queries.Users.GetUsersById;
using System.Collections.Generic;

namespace Projeto.Base.Domain.MappersProfile
{
    public  class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<CreateStudentsCommand, Students>()
                  .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CreateStudentsCommand, StudentsLessonsDto>()
                 .ForMember(dest => dest.LessonId,  opt => opt.MapFrom(src => src.LessonId))
                 .ForMember(dest => dest.SchoolGrades, opt => opt.MapFrom(src => src.SchoolGrades))
                 .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Name));

            CreateMap<UpdateStudentsCommand, Students>();
            CreateMap<Students, GetUsersByIdQueryResponse>();
          
            CreateMap<Students, GetAllStudentsQueryResponse>();

            CreateMap<List<Students>, GetAllStudentsQueryResponse>()
             .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src))
               .ForMember(dest => dest.TotalRows, opt => opt.MapFrom(src => src.Count));
        }
    }
}
