using System;
using Xunit;

namespace tests
{
    public class SettingsBuilderTests
    {
        [Fact]
        public void DefineSettings_Should_Return_A_SingleSettingsBuilder_Type()
        {
            Assert.IsType(typeof(sparksettings.settingsbuilder.SingleSettingsBuilder), sparksettings.SettingsBuilder.DefineSettings());
        }

        [Fact]
        public void Done_Should_Return_An_Implementation_Of_ISparkSetting()
        {
          Assert.IsAssignableFrom<sparksettings.ISparkSetting>(sparksettings.SettingsBuilder.DefineSettings().Done());
        }
    }
}
