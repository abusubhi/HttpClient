using Posts.DataContract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posts.DataContract.Interfaces
{
    public interface IGetPosts
    {
        Task<GetPostByIdDTO> GetPostById(int postId);
        Task<List<GetPostByUserIdDTO>> GetPostsByUserId(int userId);
    }
}
