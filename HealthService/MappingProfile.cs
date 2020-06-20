using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<PatientForCreationDTO, Patient>();
            CreateMap<PatientForUpdateDTO, Patient>();
        }
    }
}
