using System;
using sparksettings.settingsbuilder;

namespace sparksettings
{
    public static class SettingsBuilder
    {
        public static SingleSettingsBuilder DefineSettings(){
            return new SingleSettings().Builder;
        }
    }
}