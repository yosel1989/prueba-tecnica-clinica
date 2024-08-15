using Clinica.Entity.DTO;

namespace Clinica.Domain.Interface
{
	public interface IProvinceDom
	{
        Task<List<ProvinceDTO>> Collection();
        Task<List<ProvinceDTO>> CollectionByRegion(string codeRegion);
    }
}
