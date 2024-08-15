

using Clinica.Entity.DTO;

namespace Clinica.Data.Interface
{
	public interface IRegionDat
	{
		Task<List<RegionDTO>> Collection();
    }
}
