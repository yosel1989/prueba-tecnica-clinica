using Clinica.Application.Interface;
using Clinica.Domain.Interface;
using Clinica.Entity.DTO;

namespace Clinica.Application.Implement
{
	public class UserApp : IUserApp
	{
		private readonly IUserDom _IUserDom;
        public UserApp(IUserDom IUserDom)
        {
            this._IUserDom = IUserDom;
        }

        public async Task<List<UserDTO>> Collection()
        {
            return await _IUserDom.Collection();
        }
        public async Task<bool> Create(UserDTO model)
        {
            return await _IUserDom.Create(model);
        }
        public async Task<bool> Update(UserDTO model)
        {
            return await _IUserDom.Update(model);
        }

        public async Task<bool> Delete(string id)
        {
            return await _IUserDom.Delete(id);
        }

        public async Task<UserDTO> Find(string id)
        {
            return await _IUserDom.Find(id);
        }

    }
}
