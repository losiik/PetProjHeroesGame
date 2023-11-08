namespace PetProjHeroesGame
{
    internal class Fight
    {
        Setup setup = new Setup();

        public bool Fighting(int damagedGamerId, Gamer damagerGamer, Gamer damagedGamer) 
        {
            damagedGamer.gameCharacter.GetDamage(damagerGamer.gameCharacter.Damage);

            if (damagedGamer.gameCharacter.isDead) 
            {
                setup.KillTheGamer(damagedGamerId);
            }
            return damagedGamer.gameCharacter.isDead;
        }
    }
}
