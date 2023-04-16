using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Classes
{
    public class CharacterFacade
    {
        private AppearanceBuilder _appearance;
        private SkillsBuilder _skills;
        public CharacterFacade()
        {
            _appearance = new AppearanceBuilder();
            _skills = new SkillsBuilder();
        }

        public Character CreateCharacter()
        {
            _appearance = _appearance.CreateAppearance();
            _skills = _skills.CreateSkills();
            Console.WriteLine("Character-building is done through Facade class.");
            return new Character(_appearance, _skills);
        }
    }
}
