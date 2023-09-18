using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgb.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetcharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetcharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetcharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);   
        Task<ServiceResponse<GetcharacterDTO>> UpdateCharacter(UpdateCharacterDTO newCharacter);
        Task<ServiceResponse<List<GetcharacterDTO>>> DeleteCharacter(int id);
    }
}