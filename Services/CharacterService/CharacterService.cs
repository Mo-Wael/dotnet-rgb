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
            
            var ServiceResponse = new ServiceResponse<List<GetcharacterDTO>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetcharacterDTO>(c)).ToList();
            return ServiceResponse;
            // characters.Add(newCharacter);    // without service resonse
            // return characters;
        }

        public async Task<ServiceResponse<List<GetcharacterDTO>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<GetcharacterDTO>>();
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetcharacterDTO>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetcharacterDTO>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetcharacterDTO>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse.Data = _mapper.Map<GetcharacterDTO>(character);
            return ServiceResponse;
            // var character = characters.FirstOrDefault(c => c.Id == id);
            // if (character != null){
            //     return character;
            // }
            // throw new Exception("Character not found");
        }

        public async Task<ServiceResponse<GetcharacterDTO>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            var ServiceResponse = new ServiceResponse<GetcharacterDTO>();

            try{
            var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            
            if (character == null){
                throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");
            }

            // _mapper.Map<Character>(updatedCharacter);
            // _mapper.Map(updatedCharacter, character);    // you need to create another map

            character.Name = updatedCharacter.Name;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Strength = updatedCharacter.Strength;
            character.Defense = updatedCharacter.Defense;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Class = updatedCharacter.Class;
            
            ServiceResponse.Data = _mapper.Map<GetcharacterDTO>(character);
            
            }
            catch(Exception ex){
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
        public async Task<ServiceResponse<List<GetcharacterDTO>>> DeleteCharacter(int id){
            var ServiceResponse = new ServiceResponse<List<GetcharacterDTO>>();

            try{
            var character = characters.FirstOrDefault(c => c.Id == id);
            
            if (character == null){
                throw new Exception($"Character with Id '{id}' not found.");
            }

            characters.Remove(character); 
            
            ServiceResponse.Data = characters.Select(c => _mapper.Map<GetcharacterDTO>(c)).ToList();
            
            }
            catch(Exception ex){
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
            
        }

    }
}