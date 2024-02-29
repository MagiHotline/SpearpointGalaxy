namespace Game1
{
    enum ActiveScene { Start, Play, Help, Leaderboard, GameOver }

    /// <summary>
    /// Classe per la gestione delle scene
    /// </summary>
    class Scene
    {
        public static ActiveScene Active = ActiveScene.Start;
    }
}
