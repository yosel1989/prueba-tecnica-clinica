using Clinica.Entity.DTO;

namespace Clinica.Domain.Interface
{
	public interface IUbigeoDom
	{
        Task<List<UbigeoDTO>> Collection();
        Task<List<UbigeoDTO>> CollectionByRegionByProvince(string codeRegion, string codeProvince);
    }
}
