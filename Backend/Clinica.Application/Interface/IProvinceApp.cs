
using Clinica.Entity.DTO;

namespace Clinica.Application.Interface
{
    public interface IProvinceApp
	{
		Task<List<ProvinceDTO>> Collection();

        Task<List<ProvinceDTO>> CollectionByRegion(string codeRegion);
    }
}
