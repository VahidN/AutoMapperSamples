using AutoMapper;
using Sample08.Models;

namespace Sample08.MappingProfiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            this.CreateMap<Student, StudentViewModel>();
        }
    }
}