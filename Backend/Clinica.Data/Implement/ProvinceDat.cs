using Clinica.Data.Interface;
using Clinica.Entity.Contexts;
using Clinica.Entity.DTO;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data.Implement
{
	public class ProvinceDat : IProvinceDat
	{

        private readonly ApplicationDBContext _context;

        public ProvinceDat(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ProvinceDTO>> Collection()
        {
            try
            {
                List<ProvinceDTO> collection =  await _context.Province.Select(u => new ProvinceDTO()
                {
                    Code = u.ProvinceCode,
                    RegionCode = u.RegionCode,
                    Description = u.ProvinceDescription,
                })
                    .OrderBy(u => u.Description)
                    .ToListAsync();

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ProvinceDTO>> CollectionByRegion(string codeRegion)
        {
            try
            {
                List<ProvinceDTO> collection = await _context.Province.Select(u => new ProvinceDTO()
                {
                    Code = u.ProvinceCode,
                    RegionCode = u.RegionCode,
                    Description = u.ProvinceDescription,
                })
                    .Where(r => r.RegionCode == codeRegion)
                    .OrderBy(u => u.Description)
                    .ToListAsync();

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }
}
