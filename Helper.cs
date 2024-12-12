using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml;
using static FindFile.DataModel;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace FindFile
{
    public static class Helper
    {
        public static string GetDescription(this Enum value)
        {
            try
            {
                DescriptionAttribute attribute = value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;
                return attribute == null ? value.ToString() : attribute.Description;
            }
            catch
            {
                return "";
            }
        }
        public static string ToJson(this object obj)
        {
            if (obj == null) return "";
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static List<Artifact> GetArtifacts(this string genericInstallerXml)
        {
            var genericInstaller = Path.Combine(genericInstallerXml, "genericInstaller.xml");
            XDocument doc = XDocument.Load(genericInstaller);

            var artifacts = doc.Descendants("artifact")
                      .Select(x => new Artifact
                      {
                          name = x.Element("name")?.Value,
                          type = (ArtifactType)Enum.Parse(typeof(ArtifactType), x.Element("type")?.Value),
                          moduleName = x.Element("moduleName")?.Value,
                          path = x.Element("path")?.Value,
                          dbType = x.Element("dbType")?.Value,
                          executeScript = x.Element("executeScript")?.Value,
                          appName = x.Element("appName")?.Value,
                          appVersion = x.Element("appVersion")?.Value,
                          dbName = x.Element("dbName")?.Value,
                          isDuplicate = x.Element("isDuplicate")?.Value,
                          metaFolder = x.Element("metaFolder")?.Value,
                      }).ToList();

            return artifacts;
        }

        public static string ReplaceKeyToEmpty(this string text, string key)
        {
            int startIndex = text.IndexOf(key);

            if (startIndex != -1)
            {
                int endIndex = text.IndexOf("\n", startIndex);
                if (endIndex != -1)
                {
                    text = text.Remove(startIndex, endIndex - startIndex + 1);
                }
            }
            return text;
        }
    }
}
