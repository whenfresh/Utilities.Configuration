namespace WhenFresh.Utilities.Configuration.Collections;

using System.Xml.Serialization;

[XmlRoot("add")]
public sealed class DirectoryItem : PathItem,
                                    IEquatable<DirectoryItem>
{
    [XmlIgnore] public DirectoryInfo Info => new(Value);

    public bool Equals(DirectoryItem other)
    {
        if (null == other)
            return false;

        return Name == other.Name && Value == other.Value;
    }
}