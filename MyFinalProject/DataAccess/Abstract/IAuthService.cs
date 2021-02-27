using Core.Entities.Concrate;
using Core.Security.JWT;
using Core.Utilities.Results;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
