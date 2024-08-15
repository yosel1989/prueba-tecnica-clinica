
using Clinica.Data.Interface;
using Clinica.Entity.Contexts;
using Clinica.Entity.DTO;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data.Implement
{
	public class RegionDat : IRegionDat
	{

        private readonly ApplicationDBContext _context;

        public RegionDat(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<RegionDTO>> Collection()
        {
            try
            {
                List<RegionDTO> collection =  await _context.Region.Select(u => new RegionDTO()
                {
                    Code = u.RegionCode,
                    Description = u.RegionDescription,
                }).ToListAsync();

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        

    }
}
