using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rgb.Dtos.Character
{
    public class AddCharacterDTO
    {
        // delete the Id prop
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RgpClass Class { get; set; } = RgpClass.Knight;
        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreated { get; set; }
    }
}