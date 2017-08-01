using System;
using System.Collections.Generic;

namespace sparksettings
{

  internal class ConfigureSettings
  {
    internal List<ConfigureSettings> children;
    internal List<Prop> properties;
    internal string name;
    internal string description;
    internal SettingTypes settingType;

    private readonly ConfigureSettingsFluent fluent;

    internal ConfigureSettings()
    {
      fluent = new ConfigureSettingsFluent(this);
    }
    internal ConfigureSettingsFluent NewSettings
    {
      get { return fluent; }
    }

    public class ConfigureSettingsFluent
    {
      private ConfigureSettings settings;
      public ConfigureSettingsFluent(ConfigureSettings settings)
      {
        this.settings = settings;
      }

      public ConfigureSettingsFluent Name(string name)
      {
        settings.name = name;
        return this;
      }

      public ConfigureSettingsFluent Description(string description)
      {
        settings.description = description;
        return this;
      }

      public ConfigureSettingsFluent SettingType(SettingTypes type)
      {
        settings.settingType = type;
        return this;
      }

      public PropFluent AddProperty()
      {
        var newProp = new Prop(this);
        settings.properties.Add(newProp);
        return newProp.NewProperty;
      }


    }

    internal class PropFluent{
      private Prop property;
      private ConfigureSettingsFluent parent;

      internal PropFluent(Prop property, ConfigureSettingsFluent parent)
      {
        this.property = property;
        this.parent = parent;
      }

      internal PropFluent Name(string name)
      {
        property.name = name;
        return this;
      }



      internal ConfigureSettingsFluent EndProperty()
      {
        return this.parent;
      }
    }

    internal enum SettingTypes{
      Json,
    }

    internal enum PropType{
      String,
      Numeric,
      DateTime,
      Boolean,
    }

    internal class Prop
    {
      internal string name;
      internal PropType propType;
      internal string description;
      internal object defaultValue;
      internal bool isOverridable;

      private PropFluent fluent;

      internal Prop(ConfigureSettingsFluent parent)
      {
        this.fluent = new PropFluent(this, parent);
      }

      internal PropFluent NewProperty
      {
        get {return fluent;}
      }
    }
  }
}
