
using Clinica.Entity.DTO;

namespace Clinica.Application.Interface
{
    public interface IUbigeoApp
	{
		Task<List<UbigeoDTO>> Collection();
        Task<List<UbigeoDTO>> CollectionByRegionByProvince(string codeRegion, string codeProvince);
    }
}
