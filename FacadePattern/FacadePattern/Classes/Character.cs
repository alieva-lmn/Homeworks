using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class Character
    {
        private AppearanceBuilder _appearance;
        private SkillsBuilder _skills;
        public Character(AppearanceBuilder appearance, SkillsBuilder skills)
        {
            _appearance = appearance;
            _skills = skills;
        }
    }
}
