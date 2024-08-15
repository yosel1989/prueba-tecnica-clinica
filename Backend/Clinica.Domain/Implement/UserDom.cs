
using Clinica.Data.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Domain.Implement
{
    public class UserDom: IUserDom
	{
		private readonly IUserDat _IUserDat;
		public UserDom(IUserDat IUserDat)
		{
			this._IUserDat = IUserDat;
		}
		public async Task<List<UserDTO>> Collection()
		{
			return await _IUserDat.Collection();
		}
		public async Task<bool> Create(UserDTO model)
        {
            return await _IUserDat.Create(model);
        }
        public async Task<bool> Update(UserDTO model)
        {
            return await _IUserDat.Update(model);
        }
        public async Task<UserDTO> Find(string id)
        {
            return await _IUserDat.Find(id);
        }

        public async Task<bool> Delete(string id)
        {
            return await _IUserDat.Delete(id);
        }

    }
}
