using AutoMapper;
using ReactBudget.Models;
using ReactBudget.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Mapper
{
    public class ReactBudgetMappings : Profile
    {
        public ReactBudgetMappings()
        {
            CreateMap<Expense, ExpenseDto>().ReverseMap();
        }
    }
}
