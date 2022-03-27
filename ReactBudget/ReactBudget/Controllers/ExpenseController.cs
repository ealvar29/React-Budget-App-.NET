using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReactBudget.Models;
using ReactBudget.Models.Dtos;
using ReactBudget.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactBudget.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : Controller
    {
        private IExpenseRepository _erRepo;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseRepository erRepo, IMapper mapper)
        {
            _erRepo = erRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody] ExpensesDto expensesDto)
        {
            if (expensesDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var expenseObject = _mapper.Map<Expenses>(expensesDto);

            return Ok(expenseObject);
        }

        [HttpDelete]
        //Might be this one instead
        //[HttpDelete("{expenseId:int}", Name = "DeleteExpense")]
        public IActionResult DeleteExpense(int expenseId, [FromBody] ExpensesDto expensesDto)
        {
            var expenseObject = _erRepo.GetExpense(expenseId);
            if (!_erRepo.DeleteExpense(expenseObject))
            {
                ModelState.AddModelError("", $"Something went wrong when removing the record {expenseObject.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            var expenses = _erRepo.GetExpenses();
            var expensesDto = new List<ExpensesDto>();
            foreach (var expense in expensesDto)
            {
                expensesDto.Add(_mapper.Map<ExpensesDto>(expense));
            }
            return Ok(expenses);
        }

        [HttpGet]
        public IActionResult GetExpense(int expensesId)
        {
            var expense = _erRepo.GetExpense(expensesId);
            if (expense == null)
            {
                return NotFound();
            }
            var expenseDto = _mapper.Map<ExpensesDto>(expense);
            return Ok(expenseDto);
        }

        [HttpPatch]
        public IActionResult UpdateExpense(int expenseId, [FromBody] ExpensesDto expensesDto)
        {
            if (expensesDto == null || expenseId != expensesDto.Id)
            {
                return BadRequest(ModelState);
            }
            var expenseObject = _mapper.Map<Expenses>(expensesDto);
            if (!_erRepo.UpdateExpense(expenseObject))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {expenseObject.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
