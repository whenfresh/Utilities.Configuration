namespace WhenFresh.Utilities.Configuration;

using System.Configuration;

public class PathConfigurationSection : ConfigurationSection
{
    [ConfigurationProperty("directories", IsRequired = false, IsDefaultCollection = true)]
    public AddRemoveClearConfigurationElementCollection<DirectoryInfo> Directories => (AddRemoveClearConfigurationElementCollection<DirectoryInfo>)this["directories"];

    [ConfigurationProperty("files", IsRequired = false, IsDefaultCollection = true)]
    public AddRemoveClearConfigurationElementCollection<FileInfo> Files => (AddRemoveClearConfigurationElementCollection<FileInfo>)this["files"];

    public DirectoryInfo Directory(string name)
    {
        if (null == name)
            throw new ArgumentNullException("name");

        if (0 == name.Length)
            throw new ArgumentOutOfRangeException("name");

        return (from item in Directories
                where item.Name.Equals(name, StringComparison.Ordinal)
                select item.Value).FirstOrDefault();
    }

    public FileInfo File(string name)
    {
        if (null == name)
            throw new ArgumentNullException("name");

        if (0 == name.Length)
            throw new ArgumentOutOfRangeException("name");

        return (from item in Files
                where item.Name.Equals(name, StringComparison.Ordinal)
                select item.Value).FirstOrDefault();
    }
}