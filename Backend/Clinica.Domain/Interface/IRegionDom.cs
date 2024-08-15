using Clinica.Entity.DTO;

namespace Clinica.Domain.Interface
{
	public interface IRegionDom
	{
        Task<List<RegionDTO>> Collection();
    }
}
