using System;
using System.Collections.Generic;

namespace sparksettings
{

  public class ConfigureSettings
  {
    internal List<ConfigureSettings> children;
    internal List<Prop> properties;
    internal string name;
    internal string description;
    internal SettingTypes settingType;

    private readonly ConfigureSettingsFluent fluent;

    public ConfigureSettings()
    {
      fluent = new ConfigureSettingsFluent(this);
    }
    public ConfigureSettingsFluent NewSettings
    {
      get { return fluent; }
    }

    public class ConfigureSettingsFluent
    {
      private ConfigureSettings settings;
      internal ConfigureSettingsFluent(ConfigureSettings settings)
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

    public class PropFluent{
      private Prop property;
      private ConfigureSettingsFluent parent;

      public PropFluent(Prop property, ConfigureSettingsFluent parent)
      {
        this.property = property;
        this.parent = parent;
      }

      public PropFluent Name(string name)
      {
        property.Name = name;
        return this;
      }



      public ConfigureSettingsFluent EndProperty()
      {
        return this.parent;
      }
    }

    public enum SettingTypes{
      Json,
    }

    public enum PropType{
      String,
      Numeric,
      DateTime,
      Boolean,
    }

    public class Prop
    {
      internal string name;
      internal PropType propType;
      internal string description;
      internal object defaultValue;
      internal bool isOverridable;

      private PropFluent fluent;

      public Prop(ConfigureSettingsFluent parent)
      {
        this.fluent = new PropFluent(this, parent);
      }

      public PropFluent NewProperty
      {
        get {return fluent;}
      }
    }
  }
}
