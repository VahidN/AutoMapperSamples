using AutoMapper;
using Sample08.Models;

namespace Sample08.MappingProfiles
{
    public class StudentsProfile : Profile
    {
        protected override void Configure()
        {
            this.CreateMap<Student, StudentViewModel>();
        }
    }
}