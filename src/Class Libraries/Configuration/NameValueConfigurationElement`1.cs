namespace WhenFresh.Utilities.Configuration;

using System.Configuration;
using System.Diagnostics;
using WhenFresh.Utilities.Configuration.Diagnostics;

public sealed class NameValueConfigurationElement<T> : ConfigurationElement
{
    public NameValueConfigurationElement()
    {
        Trace.WriteIf(Tracing.Is.TraceVerbose, string.Empty);

        Properties.Add(ConfigurationProperty<T>.Item("value"));
    }

    public NameValueConfigurationElement(string name,
                                         T value)
        : this()
    {
        Trace.WriteIf(Tracing.Is.TraceVerbose, string.Empty);

        Name = name;
        Value = value;
    }

    [ConfigurationProperty("name", IsRequired = false)]
    public string Name
    {
        get => (string)this["name"];

        set => this["name"] = value;
    }

    public T Value
    {
        get => (T)this["value"];

        set => this["value"] = value;
    }
}