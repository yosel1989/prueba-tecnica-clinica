using Clinica.Data.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Domain.Implement
{
    public class ProvinceDom: IProvinceDom
	{
		private readonly IProvinceDat _IProvinceDat;
		public ProvinceDom(IProvinceDat IProvinceDat)
		{
			this._IProvinceDat = IProvinceDat;
		}
		public async Task<List<ProvinceDTO>> Collection()
		{
			return await _IProvinceDat.Collection();
		}

        public async Task<List<ProvinceDTO>> CollectionByRegion(string codeRegion)
        {
            return await _IProvinceDat.CollectionByRegion(codeRegion);
        }

    }
}
