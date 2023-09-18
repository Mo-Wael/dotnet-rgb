using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rgb.Controllers
{
    // inherite from ControllBase to make it proper Controller
    [ApiController]     // API controller attribute 
    [Route("api/[controller]")]     // Route attribute, 
    public class CharacterController : ControllerBase
    {
        // private static List<Character> characters = new List<Character>{
        //     new Character(),
        //     new Character{ Id = 1, Name = "Sam"}
        // };
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characcterService)
        {
            _characterService = characcterService;
        }

        [HttpGet("GetAll")]   // Method Defining

        public async Task<ActionResult<ServiceResponse<List<GetcharacterDTO>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetcharacterDTO>>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetcharacterDTO>>>> AddCharacter(AddCharacterDTO newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetcharacterDTO>>>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ServiceResponse<GetcharacterDTO>>>> DeleteCharacter(int id){
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
            
        }
    }
}