﻿namespace MovieManagement.Database.Repositories; 

public interface IUserRepository: IRepository<UserEntity?> {
    Task<UserEntity?> GetByEmail(string email); 
    Task<UserEntity?> GetByUsername(string username);
}