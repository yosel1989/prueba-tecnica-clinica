
using Clinica.Entity.DTO;

namespace Clinica.Application.Interface
{
    public interface IRegionApp
	{
		Task<List<RegionDTO>> Collection();
    }
}
