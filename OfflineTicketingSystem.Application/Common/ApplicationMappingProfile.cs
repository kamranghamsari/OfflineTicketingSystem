using AutoMapper;
using OfflineTicketingSystem.Application.Features.Tickets.Models;
using OfflineTicketingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineTicketingSystem.Application.Common
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Ticket, TicketDto>();
        }
    }
}
