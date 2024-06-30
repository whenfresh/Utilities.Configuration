namespace WhenFresh.Utilities.Collections;

using System.Xml.Serialization;

[XmlRoot("add")]
public sealed class FileItem : PathItem,
                               IEquatable<FileItem>
{
    [XmlIgnore] public FileInfo Info => new(Value);

    public bool Equals(FileItem other)
    {
        if (null == other)
            return false;

        return Name == other.Name && Value == other.Value;
    }
}