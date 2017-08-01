using System;

namespace sparksettings.settingsbuilder
{
  internal class SingleSettings
  {
    private readonly SingleSettingsBuilder builder;

    internal SingleSettings()
    {
      builder = new SingleSettingsBuilder(this);
    }

    internal SingleSettingsBuilder Builder
    {
      get { return this.builder; }
    }
  }
}