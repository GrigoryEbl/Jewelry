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

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public uint Money = 0;
        public int EngineLevel = 1;
        public float EngineSpeed = 4f;
        public int MagnetLevel = 1;
        public int CapacityLevel = 1;

        public float PriceUpgradeEngine = 30;
        public float PriceUpgradeMagnet = 30;
        public float PriceUpgradeCargo = 30;

        public bool IsLowHandActive = true;
        public bool IsMiddleHandActive = false;
        public bool IsHighHandActive = false;

        public bool IsLowWheelsActive = true;
        public bool IsMiddleWheelsActive = false;
        public bool IsHighWheelsActive = false;

        public bool IsLowMagnegActive = true;
        public bool IslowMagnetModifyVariantActive = false;
        public bool IsMiddleMagnetActive = false;
        public bool IsMiddleMagnetModifyVariantActive = false;
        public bool IsHighMagnetActive = false;
        public bool IsHighMagnetModifyVariantActive = false;

        public bool IsBarrierJailActive = true;
        public bool IsBarrierForgeActive = true;
        public bool IsBarrierThroneActive = true;

        public bool[] IsMagnetModelsActive = new bool[6];
        public bool[] IsWheelsModelsActive = new bool[3];
        public bool[] IsHandModelsActive = new bool[3];

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            IsMagnetModelsActive[0] = true;
            IsWheelsModelsActive[0] = true;
            IsHandModelsActive[0] = true;
            openLevels[1] = true;
        }
    }
}
