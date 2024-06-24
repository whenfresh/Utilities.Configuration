﻿namespace WhenFresh.Utilities.Configuration.Collections;

using System.Xml.Serialization;
using WhenFresh.Utilities.Core.Collections.Generic;

[XmlRoot("directories")]
public sealed class DirectoryCollection : XmlSerializableCollection<DirectoryItem>
{
    public DirectoryInfo this[string name]
    {
        get
        {
            foreach (var item in this.Where(item => item.Name == name))
                return item.Info;
            throw new KeyNotFoundException(name);
        }
    }
}