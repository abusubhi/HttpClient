using AutoMapper;
using Newtonsoft.Json;
using Posts.DataContract.DTOs;
using Posts.DataContract.Interfaces;
using Posts.DataContract.Models;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Json;

namespace Posts.Business.Services
{
    public class GetPosts:IGetPosts
    {
            private IMapper _mapper;
            private HttpClient _client;

            public GetPosts(IMapper mapper)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                _mapper = mapper;
            }

        //Get Post By PostId 
        public async Task<GetPostByIdDTO> GetPostById(int postId)
        {
            HttpResponseMessage response = await _client.GetAsync($"posts/{postId}");
            if (response.IsSuccessStatusCode)
            {
                var postData = await response.Content.ReadFromJsonAsync<GetPostByIdDTO>(); 
                var userId = postData.userId;

                HttpResponseMessage userResponse = await _client.GetAsync($"users/{userId}");

                if (userResponse.IsSuccessStatusCode)
                {
                    var userData = await userResponse.Content.ReadFromJsonAsync<GetAllUsersDTO>(); 
                    var userName = userData.Name;
                    var mapped = _mapper.Map<GetPostByIdDTO>(postData);
                    mapped.name = userName;

                    return mapped;
                }


                //if (response.IsSuccessStatusCode)
                //{
                //    var data = await response.Content.ReadAsStringAsync();            
                //        var mapped = _mapper.Map<GetPostByIdDTO>(data);
                //        return mapped;
                //}
               
            } throw new Exception();
        }
        


        public async Task<List<GetPostByUserIdDTO>> GetPostsByUserId(int userId)
        {
            HttpResponseMessage response = await _client.GetAsync($"posts?userId={userId}");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var userPostModels = JsonConvert.DeserializeObject<List<GetPostByUserIdDTO>>(data);
                var userPosts = _mapper.Map<List<GetPostByUserIdDTO>>(userPostModels);
                return userPosts;
            }

            throw new Exception();
        }

    }
}
