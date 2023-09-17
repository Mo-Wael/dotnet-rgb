using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace dotnet_rgb.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper){
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetcharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            
            var ServiceResponse = new ServiceResponse<List<Character>>();
            characters.Add(_mapper.Map<Character>(newCharacter));
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetcharacterDTO>(c)).ToList();
            return ServiceResponse;
            // characters.Add(newCharacter);    // without service resonse
            // return characters;
        }

        public async Task<ServiceResponse<List<GetcharacterDTO>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<Character>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetcharacterDTO>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetcharacterDTO>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse.Data = _mapper.Map<GetcharacterDTO>(character);
            return ServiceResponse;
            // var character = characters.FirstOrDefault(c => c.Id == id);
            // if (character != null){
            //     return character;
            // }
            // throw new Exception("Character not found");
        }
    }
}