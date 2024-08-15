
using Clinica.Entity.DTO;

namespace Clinica.Application.Interface
{
    public interface IUserApp
	{
		Task<List<UserDTO>> Collection();
		Task<bool> Create(UserDTO model);
		Task<bool> Update(UserDTO model);
		Task<UserDTO> Find(string id);
		Task<bool> Delete(string id);
    }
}
