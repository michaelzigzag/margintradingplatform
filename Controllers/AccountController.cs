using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private static List<Account> accounts = new List<Account>();

    [HttpGet]
    public ActionResult<IEnumerable<Account>> GetAllAccounts()
    {
        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public ActionResult<Account> GetAccountById(string id)
    {
        var account = accounts.Find(a => a.AccountId == id);
        if (account == null) return NotFound();
        return Ok(account);
    }

    [HttpPost]
    public IActionResult CreateAccount([FromBody] Account account)
    {
        accounts.Add(account);
        return CreatedAtAction(nameof(GetAccountById), new { id = account.AccountId }, account);
    }

    // Endpoint to deposit funds into an account
    [HttpPost("{id}/deposit")]
    public IActionResult Deposit(string id, [FromBody] decimal amount)
    {
        var account = accounts.Find(a => a.AccountId == id);
        if (account == null) return NotFound("Account not found.");

        try
        {
            account.Deposit(amount);
            return Ok(account);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint to withdraw funds from an account
    [HttpPost("{id}/withdraw")]
    public IActionResult Withdraw(string id, [FromBody] decimal amount)
    {
        var account = accounts.Find(a => a.AccountId == id);
        if (account == null) return NotFound("Account not found.");

        try
        {
            var result = account.Withdraw(amount);
            if (!result)
            {
                return BadRequest("Insufficient funds for withdrawal.");
            }
            return Ok(account);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}