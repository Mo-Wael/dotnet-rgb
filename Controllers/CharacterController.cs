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

        public ActionResult<List<Character>> Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public ActionResult<List<Character>> GetSingle(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter){
            return Ok(_characterService.AddCharacter(newCharacter));
        }

    }
}