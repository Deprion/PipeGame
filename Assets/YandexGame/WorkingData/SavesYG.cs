
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public bool isMusicOn;
        public int hiScore, points, textureStyle;
        public bool[] textureUnlocked;

        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            hiScore = 0;
            points = 0;
            textureStyle = 0;
            textureUnlocked = new bool[4];
            textureUnlocked[0] = true;
            for (int i = 1; i < textureUnlocked.Length; i++)
            {
                textureUnlocked[i] = false;
            }
            isMusicOn = true;
        }
    }
}
