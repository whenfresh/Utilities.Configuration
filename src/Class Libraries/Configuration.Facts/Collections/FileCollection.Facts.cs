namespace WhenFresh.Utilities.Collections;

using WhenFresh.Utilities.Collections.Generic;
using WhenFresh.Utilities.IO;

public sealed class FileCollectionFacts
{
    [Fact]
    public void a_definition()
    {
        Assert.True(new TypeExpectations<FileCollection>()
                    .DerivesFrom<XmlSerializableCollection<FileItem>>()
                    .IsConcreteClass()
                    .IsSealed()
                    .HasDefaultConstructor()
                    .XmlRoot("files")
                    .Result);
    }

    [Fact]
    public void ctor()
    {
        Assert.NotNull(new FileCollection());
    }

    [Fact]
    public void opIndexer_string()
    {
        using (var temp = new TempFile())
        {
            const string name = "example";
            var expected = temp.Info.FullName;

            var obj = new FileCollection
                          {
                              new()
                                  {
                                      Name = name,
                                      Value = temp.Info.FullName
                                  }
                          };

            var actual = obj[name].FullName;

            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void opIndexer_string_whenKeyNotFoundException()
    {
        Assert.Throws<KeyNotFoundException>(() => new FileCollection()["example"]);
    }
}