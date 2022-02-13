using FrameWork.Core.Domain.Dtos.CommonDto;
using FrameWork.Core.Domain.Enums;
using FrameWork.Utilities.Helpers;
using Microsoft.IdentityModel.Tokens;
using PhoneBook.Core.Domain.Common.Contracts;
using PhoneBook.Core.Domain.Common.Dtos;
using PhoneBook.Core.Domain.Users.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PhoneBook.Infra.CommonServices
{
    public class JwtTokenService : ITokenService
    {
        private readonly TokenSettingDto tokenSetting;

        public JwtTokenService(TokenSettingDto tokenSetting)
        {
            this.tokenSetting = tokenSetting;
        }
        public ServiceResult<TokenResultDto> GenerateToken(UserTokenDto user)
        {
            var secretKey = StringHelper.StringToByteArray(tokenSetting.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = StringHelper.StringToByteArray(tokenSetting.SecretKey);
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = GetClaims(user);
            var issuedAt = DateTime.Now;
            var expierDate = issuedAt.AddMinutes(tokenSetting.ExpirationMinutes);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = tokenSetting.Issuer,
                Audience = tokenSetting.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = issuedAt,
                Expires = expierDate,
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            var token = tokenHandler.WriteToken(securityToken);
           
            return new ServiceResult<TokenResultDto>(EnuResultStatusCode.Success, true, result: new TokenResultDto { Token = token, ExpireDate = expierDate });
        }

        private IEnumerable<Claim> GetClaims(UserTokenDto user)
        {

            var list = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Surname,user.FullName)
            };

            return list;
        }
    }
}
