﻿namespace MovieManagement.Functions.Dtos; 

public class RegisterUserDto {
    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}