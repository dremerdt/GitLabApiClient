﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitLabApiClient.Http;
using GitLabApiClient.Models.Users;

namespace GitLabApiClient
{
    public class UsersClient
    {
        private readonly GitLabHttpFacade _httpFacade;

        internal UsersClient(GitLabHttpFacade httpFacade) => 
            _httpFacade = httpFacade;

        public async Task<IList<User>> GetAsync() => 
            await _httpFacade.GetPagedList<User>("/users");

        public async Task<User> GetAsync(string name) =>
            (await _httpFacade.Get<List<User>>($"/users?username={name}")).FirstOrDefault();

        public async Task<User> CreateAsync(CreateOrUpdateUserRequest request) => 
            await _httpFacade.Post<User>("/users", request);

        public async Task<User> UpdateAsync(int id, CreateOrUpdateUserRequest request) => 
            await _httpFacade.Put<User>($"/users/{id}", request);

        public async Task<Session> GetCurrentSessionAsync() =>
            await _httpFacade.Get<Session>("/user");

        public async Task DeleteAsync(int userId) => 
            await _httpFacade.Delete($"/users/{userId}");
    }
}