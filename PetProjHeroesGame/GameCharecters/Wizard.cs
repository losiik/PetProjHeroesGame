namespace PetProjHeroesGame
{
    internal class Wizard : GameCharacter
    {
        public override int Damage => 8;

        int health = 100;
        public override int Health
        {
            get => health;
            set => health = value;
        }
    }
}
