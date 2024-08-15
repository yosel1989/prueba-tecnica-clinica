using Clinica.Application.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Application.Implement
{
	public class RegionApp : IRegionApp
	{
		private readonly IRegionDom _IRegionDom;
        public RegionApp(IRegionDom IRegionDom)
        {
            this._IRegionDom = IRegionDom;
        }

        public async Task<List<RegionDTO>> Collection()
        {
            return await _IRegionDom.Collection();
        }
        
    }
}
