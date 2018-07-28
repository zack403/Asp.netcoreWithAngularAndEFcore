using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zaap.Controllers.Resources;
using Zaap.Models;
using Zaap.Persistence;

namespace Zaap.Controllers
{
    public class MakesController : Controller
    {
        private readonly ZaapDbContext context;
        private readonly IMapper mapper;
        public MakesController(ZaapDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}