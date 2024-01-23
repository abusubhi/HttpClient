using Posts.DataContract.DTOs;
using Posts.DataContract.Models;

namespace Posts.DataContract.Interfaces
{
    public interface IGetAllUsers
    {
        Task<List<GetAllUsersDTO>> GetUsers();
        Task<TestUser> GetUserById(int id);
    }
}
