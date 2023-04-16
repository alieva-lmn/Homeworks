using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class SkillsBuilder
    {
        public SkillsBuilder CreateSkills()
        {
            Console.WriteLine("Some manipulations with skills");
            return new SkillsBuilder();
        }
    }
}
