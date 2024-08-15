
using Clinica.Data.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Domain.Implement
{
    public class RegionDom: IRegionDom
	{
		private readonly IRegionDat _IRegionDat;
		public RegionDom(IRegionDat IRegionDat)
		{
			this._IRegionDat = IRegionDat;
		}
		public async Task<List<RegionDTO>> Collection()
		{
			return await _IRegionDat.Collection();
		}

      

    }
}
