using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgb
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // maps for mapping {mapping from Character to GetCharacterDTO}
            CreateMap<Character, GetcharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            // another map for updating using automapping
            CreateMap<UpdateCharacterDTO, Character>();
        }
    }
}