using FrameWork.Core.Domain.Dtos.CommonDto;
using PhoneBook.Core.Domain.Common.Dtos;
using PhoneBook.Core.Domain.Users.Dtos;

namespace PhoneBook.Core.Domain.Common.Contracts
{
    public interface ITokenService
    {
        ServiceResult<TokenResultDto> GenerateToken(UserTokenDto user);
    }
}
