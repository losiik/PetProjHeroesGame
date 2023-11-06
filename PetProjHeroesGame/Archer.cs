namespace PetProjHeroesGame
{
    internal class Archer : GameCharacter
    {
        public override int Damage => 10;

        int health = 80;
        public override int Health
        {
            get => health;
            set => health = value;
        }
    }
}
