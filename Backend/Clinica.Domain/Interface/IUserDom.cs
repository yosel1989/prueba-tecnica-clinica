using Clinica.Entity.DTO;

namespace Clinica.Domain.Interface
{
	public interface IUserDom
	{
        Task<List<UserDTO>> Collection();
        Task<bool> Create(UserDTO model);
        Task<bool> Update(UserDTO model);
        Task<bool> Delete(string id);
        Task<UserDTO> Find(string id);
    }
}
