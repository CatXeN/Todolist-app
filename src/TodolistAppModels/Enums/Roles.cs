using System.ComponentModel;

namespace TodolistAppModels.Entities
{
    public enum Roles
    {
        [Description("User")]
        User,
        [Description("Admin")]
        Admin
    }
}
