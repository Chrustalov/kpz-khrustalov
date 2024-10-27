using AutoMapper;
using HospitalApi.Models;
using HospitalApi.DTOs;

namespace HospitalApi.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Doctors));
            
            CreateMap<CreateDepartmentDto, Department>().ReverseMap();
            CreateMap<CreateDoctorDto, Doctor>().ReverseMap();
            CreateMap<CreatePatientDto, Patient>().ReverseMap();
            CreateMap<CreateContactInformationDto, ContactInformation>().ReverseMap();

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.ContactInformation, opt => opt.MapFrom(src => src.ContactInformation))
                .ReverseMap();

            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.ContactInformation, opt => opt.MapFrom(src => src.ContactInformation))
                .ReverseMap();

            CreateMap<ContactInformation, ContactInformationDto>().ReverseMap();
        }
    }
}
