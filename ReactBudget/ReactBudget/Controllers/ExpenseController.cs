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
        public IActionResult CreateExpense([FromBody] ExpenseDto expensesDto)
        {
            if (expensesDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var expenseObject = _mapper.Map<Expense>(expensesDto);

            return Ok(expenseObject);
        }

        [HttpDelete]
        //Might be this one instead
        //[HttpDelete("{expenseId:int}", Name = "DeleteExpense")]
        public IActionResult DeleteExpense(int expenseId, [FromBody] ExpenseDto expensesDto)
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
        [ProducesResponseType(200, Type = typeof(List<ExpenseDto>))]
        public IActionResult GetExpenses()
        {
            var expenses = _erRepo.GetExpenses();
            var expensesDto = new List<ExpenseDto>();
            foreach (var expense in expensesDto)
            {
                expensesDto.Add(_mapper.Map<ExpenseDto>(expense));
            }
            return Ok(expenses);
        }

        /*[HttpGet]
        public IActionResult GetExpense(int expensesId)
        {
            var expense = _erRepo.GetExpense(expensesId);
            if (expense == null)
            {
                return NotFound();
            }
            var expenseDto = _mapper.Map<ExpensesDto>(expense);
            return Ok(expenseDto);
        }*/

        [HttpPatch]
        public IActionResult UpdateExpense(int expenseId, [FromBody] ExpenseDto expensesDto)
        {
            if (expensesDto == null || expenseId != expensesDto.Id)
            {
                return BadRequest(ModelState);
            }
            var expenseObject = _mapper.Map<Expense>(expensesDto);
            if (!_erRepo.UpdateExpense(expenseObject))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {expenseObject.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
