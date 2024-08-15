
using Clinica.Data.Implement;
using Clinica.Data.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Domain.Implement
{
    public class UbigeoDom: IUbigeoDom
	{
		private readonly IUbigeoDat _IUbigeoDat;
		public UbigeoDom(IUbigeoDat IUbigeoDat)
		{
			this._IUbigeoDat = IUbigeoDat;
		}
		public async Task<List<UbigeoDTO>> Collection()
		{
			return await _IUbigeoDat.Collection();
		}

        public async Task<List<UbigeoDTO>> CollectionByRegionByProvince(string codeRegion, string codeProvince)
        {
            return await _IUbigeoDat.CollectionByRegionByProvince(codeRegion, codeProvince);
        }

    }
}
