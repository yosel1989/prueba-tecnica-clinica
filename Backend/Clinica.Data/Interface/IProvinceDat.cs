

using Clinica.Entity.DTO;

namespace Clinica.Data.Interface
{
	public interface IProvinceDat
	{
		Task<List<ProvinceDTO>> Collection();

        Task<List<ProvinceDTO>> CollectionByRegion(string codeRegion);
    }
}
