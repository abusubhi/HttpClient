using AutoMapper;
using Newtonsoft.Json;
using Posts.DataContract.DTOs;
using Posts.DataContract.Interfaces;
using Posts.DataContract.Models;
using System;

namespace Posts.Business.Services
{
    public class GetAllUsers:IGetAllUsers
    {
        private  IMapper _mapper;
        private HttpClient _client;
        public GetAllUsers(IMapper mapper)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _mapper = mapper;
        }


        //Get All User {id ,Name , Email }
        public async Task<List<GetAllUsersDTO>> GetUsers()
        {
            List<GetAllUsersDTO> users = new List<GetAllUsersDTO>();
            HttpResponseMessage response = await _client.GetAsync($"users");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var userApiModels = JsonConvert.DeserializeObject<List<GetAllUsersDTO>>(data);
                users = _mapper.Map<List<GetAllUsersDTO>>(userApiModels);
            }

            return users;
        }


        //Get All Information about uesrs By UserId And Retern As string 
        public async Task<TestUser> GetUserById(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://jsonplaceholder.typicode.com/users/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string userJson = await response.Content.ReadAsStringAsync();
                var userApi = JsonConvert.DeserializeObject<newUserDTO>(userJson);
                var  any = _mapper.Map<TestUser>(userApi);
                    return any;
                }
            return null;
           //throw new Exception("Exception Error fo");
        }

    }
}
