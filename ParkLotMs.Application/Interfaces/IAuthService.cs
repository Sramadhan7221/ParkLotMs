﻿namespace ParkLotMs.Application.Interfaces
{
    public interface IAuthService
    {
        string Login(string username, string password);
    }
}