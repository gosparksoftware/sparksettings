namespace sparksettings.settingsbuilder
{
    public class SingleSettingsBuilder
    {
        private SingleSettings settings;

        private SingleSettingsBuilder(){}

        internal SingleSettingsBuilder(SingleSettings settings)
        {
            this.settings = settings;
        }

        public ISparkSetting Done()
        {
            return new emitter.MockSetting();
        }
    }
}