using Clinica.Data.Interface;
using Clinica.Entity.Contexts;
using Clinica.Entity.DTO;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data.Implement
{
	public class UbigeoDat : IUbigeoDat
	{

        private readonly ApplicationDBContext _context;

        public UbigeoDat(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<UbigeoDTO>> Collection()
        {
            try
            {
                List<UbigeoDTO> collection =  await _context.Ubigeo.Select(u => new UbigeoDTO()
                {
                    Code = u.UbigeoCode,
                    ProvinceCode = u.ProvinceCode,
                    RegionCode = u.RegionCode,
                    Description = u.UbigeoDescription,
                }).ToListAsync();

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<UbigeoDTO>> CollectionByRegionByProvince(string codeRegion, string codeProvince)
        {
            try
            {
                List<UbigeoDTO> collection = await _context.Ubigeo.Select(u => new UbigeoDTO()
                {
                    Code = u.UbigeoCode,
                    ProvinceCode = u.ProvinceCode,
                    RegionCode = u.RegionCode,
                    Description = u.UbigeoDescription,
                })
                    .Where(x => x.ProvinceCode == codeProvince && x.RegionCode == codeRegion)
                    .OrderBy(x => x.Description)
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
