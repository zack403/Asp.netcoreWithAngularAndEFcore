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
    public class FeautureController : Controller
    {
        private readonly ZaapDbContext context;
        private readonly IMapper mapper;
        public FeautureController(ZaapDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet("/api/feautures")]
        public async Task<IEnumerable<FeautureResource>> GetFeauture()
        {
            var features = await context.Feautures.ToListAsync();
            return mapper.Map<List<Feauture>, List<FeautureResource>>(features);
        }

    }
}