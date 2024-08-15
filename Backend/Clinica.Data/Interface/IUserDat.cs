

using Clinica.Entity.DTO;

namespace Clinica.Data.Interface
{
	public interface IUserDat
	{
		Task<List<UserDTO>> Collection();
		Task<bool> Create(UserDTO model);
		Task<bool> Update(UserDTO model);
		Task<bool> Delete(string id);
		Task<UserDTO> Find(string id);
    }
}
