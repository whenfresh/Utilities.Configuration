namespace WhenFresh.Utilities.Configuration.Collections;

using System.Xml.Serialization;
using WhenFresh.Utilities.Core.Collections.Generic;
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