using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Models.Dtos
{
    public class ExpensesDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Double Cost { get; set; }

        public string ExpenseType { get; set; }

        public bool IsComplete { get; set; }

        public DateTime DueDate { get; set; }
    }
}
