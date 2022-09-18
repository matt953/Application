using API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private DataContext _dataContext;
        private readonly ILogger<TestController> _logger;

        public TestController(DataContext dataContext, ILogger<TestController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssetSummaryAsync()
        {
            var data = await _dataContext.Projects.AddAsync(new Entity.Models.User() { Email = "matt", FirstName = "test", LastName = "last", Role = Entity.Models.Role.Admin, Title = "TSC" });
            await _dataContext.SaveChangesAsync();

            var list = await _dataContext.Projects.ToListAsync();

            return Ok(list);
        }
    }
}
