using System.IO;
using Utf8Json;

namespace WowParser.Main.JsonService
{
    // serialize fileinfo as string fullpath.
    public class FileInfoFormatter<T> : IJsonFormatter<FileInfo>
    {
        public void Serialize(ref JsonWriter writer, FileInfo value, IJsonFormatterResolver formatterResolver)
        {
            if (value == null) { writer.WriteNull(); return; }

            // if target type is primitive, you can also use writer.Write***.
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.FullName, formatterResolver);
        }

        public FileInfo Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull()) return null;

            // if target type is primitive, you can also use reader.Read***.
            var path = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, formatterResolver);
            return new FileInfo(path);
        }
    }

}