using Clinica.Application.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Application.Implement
{
	public class UbigeoApp : IUbigeoApp
	{
		private readonly IUbigeoDom _IUbigeoDom;
        public UbigeoApp(IUbigeoDom IUbigeoDom)
        {
            this._IUbigeoDom = IUbigeoDom;
        }

        public async Task<List<UbigeoDTO>> Collection()
        {
            return await _IUbigeoDom.Collection();
        }

        public async Task<List<UbigeoDTO>> CollectionByRegionByProvince(string codeRegion, string codeProvince)
        {
            return await _IUbigeoDom.CollectionByRegionByProvince(codeRegion, codeProvince);
        }

    }
}
