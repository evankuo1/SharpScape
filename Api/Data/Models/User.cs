using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using SharpScape.Shared.Dto;

namespace SharpScape.Api.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    [Editable(false)]
    [DisplayFormat(DataFormatString = "{0:D}")]
    public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();

    public User() { }

    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}

public static class UserDtoExtensions
{
    public static UserInfoDto FromUser(this UserInfoDto dto, User user)
    {
        dto.Id = user.Id;
        dto.Username = user.Username;
        dto.Email = user.Email;
        dto.Created = user.Created;
        return dto;
    }
}