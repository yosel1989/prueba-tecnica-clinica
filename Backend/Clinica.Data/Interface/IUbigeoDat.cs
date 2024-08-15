

using Clinica.Entity.DTO;

namespace Clinica.Data.Interface
{
	public interface IUbigeoDat
	{
		Task<List<UbigeoDTO>> Collection();
        Task<List<UbigeoDTO>> CollectionByRegionByProvince(string codeRegion, string codeProvince);
    }
}
