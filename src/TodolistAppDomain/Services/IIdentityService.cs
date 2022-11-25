﻿using TodolistAppModels.Informations;

namespace TodolistAppDomain.Identity
{
    public interface IIdentityService
    {
        Task CreateUser(UserInformation userInformation);
        Task<string> GetToken(string username, string password);
        Task<bool> Authorize(int userId);
    }
}
