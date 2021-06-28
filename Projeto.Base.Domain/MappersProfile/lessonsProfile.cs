using AutoMapper;
using Projeto.Base.Domain.Commands.Lessons.Create;
using Projeto.Base.Domain.Commands.Lessons.Listen;
using Projeto.Base.Domain.Commands.Lessons.Update;
using Projeto.Base.Domain.Entities;
using Projeto.Base.Domain.Queries.Lessons.GetFilterAllLessons;
using Projeto.Base.Domain.Queries.Lessons.GetLessonsById;
using Projeto.Base.Domain.Subscribers;
using System.Collections.Generic;

namespace Projeto.Base.Domain.MappersProfile
{
    public class lessonsProfile : Profile
    {
        public lessonsProfile()
        {

            CreateMap<Lesson, GetFilterAllLessonsQueryResponse>();

            CreateMap<Lesson, GetLessonsByIdQueryResponse>();
            CreateMap<List<Lesson>, GetFilterAllLessonsQueryResponse>()
             .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src))
             .ForMember(dest => dest.TotalRows, opt => opt.MapFrom(src => src.Count));

            CreateMap<CreateLessonsCommand, Lesson>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateLessonsCommand, Lesson>();

            CreateMap<ListenLessonCommand, ImportedLesson>();
        }
    }
}
