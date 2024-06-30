namespace WhenFresh.Utilities.Collections;

using System.Xml.Serialization;
using WhenFresh.Utilities.Collections.Generic;
#if !NET20
#endif

[XmlRoot("files")]
public sealed class FileCollection : XmlSerializableCollection<FileItem>
{
    public FileInfo this[string name]
    {
        get
        {
            foreach (var item in this.Where(item => item.Name == name))
                return item.Info;
            throw new KeyNotFoundException(name);
        }
    }
}