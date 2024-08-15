using Clinica.Application.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Application.Implement
{
	public class ProvinceApp : IProvinceApp
	{
		private readonly IProvinceDom _IProvinceDom;
        public ProvinceApp(IProvinceDom IProvinceDom)
        {
            this._IProvinceDom = IProvinceDom;
        }

        public async Task<List<ProvinceDTO>> Collection()
        {
            return await _IProvinceDom.Collection();
        }

        public async Task<List<ProvinceDTO>> CollectionByRegion(string codeRegion)
        {
            return await _IProvinceDom.CollectionByRegion(codeRegion);
        }

    }
}
