namespace WhenFresh.Utilities.Configuration;

using System.Configuration;

public sealed class AddRemoveClearConfigurationElementCollection<T> : ConfigurationElementCollection,
                                                                      ICollection<NameValueConfigurationElement<T>>
{
    public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.AddRemoveClearMap;

    public new bool IsReadOnly => IsReadOnly();

    public void Add(NameValueConfigurationElement<T> item)
    {
        BaseAdd(item);
    }

    public void Clear()
    {
        BaseClear();
    }

    public bool Contains(NameValueConfigurationElement<T> item)
    {
#if NET20
            foreach (var element in this)
            {
                if (ReferenceEquals(element, item))
                {
                    return true;
                }
            }

            return false;
#else
        return this.Any(element => ReferenceEquals(element, item));
#endif
    }

    public void CopyTo(NameValueConfigurationElement<T>[] array,
                       int arrayIndex)
    {
        // ReSharper disable CoVariantArrayConversion
        base.CopyTo(array, arrayIndex);

        // ReSharper restore CoVariantArrayConversion
    }

    public bool Remove(NameValueConfigurationElement<T> item)
    {
        for (var i = 0; i < Count; i++)
        {
            if (!ReferenceEquals(BaseGet(i), item))
                continue;

            BaseRemoveAt(i);
            return true;
        }

        return false;
    }

    public new IEnumerator<NameValueConfigurationElement<T>> GetEnumerator()
    {
        var list = new List<NameValueConfigurationElement<T>>();
        var enumerator = base.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current as NameValueConfigurationElement<T>;
            list.Add(item);
        }

        return list.GetEnumerator();
    }

    public void Add(string name,
                    T value)
    {
        BaseAdd(new NameValueConfigurationElement<T>(name, value));
    }

    protected override ConfigurationElement CreateNewElement()
    {
        return new NameValueConfigurationElement<T>();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
        if (null == element)
            throw new ArgumentNullException("element");

        var extension = element as NameValueConfigurationElement<T>;
        if (null == extension)
            throw new ArgumentOutOfRangeException("element");

        return extension.Name;
    }
}