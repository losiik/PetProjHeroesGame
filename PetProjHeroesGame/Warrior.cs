namespace PetProjHeroesGame
{
    internal class Warrior : GameCharacter
    {
        public override int Damage => 6;

        int health = 150;
        public override int Health
        {
            get => health;
            set => health = value;
        }
    }
}
