using System.ComponentModel;

namespace FindFile
{
    public class DataModel
    {
        public class Artifact
        {
            public string name { get; set; }
            public ArtifactType type { get; set; }
            public string path { get; set; }
            public string metaFolder { get; set; }
            public string moduleName { get; set; }
            public string isDuplicate { get; set; }
            public string dbName { get; set; }
            public string dbType { get; set; }
            public string appName { get; set; }
            public string appVersion { get; set; }
            public string executeScript { get; set; }
        }

        public enum ArtifactType
        {
            [Description("jar")]
            HOT_FIX_JAR,
            [Description("file")]
            FILE_REPLACE,
            [Description("folder")]
            FOLDER_REPLACE,
            [Description("folder")]
            META_INF_PROP,
            [Description("WEB_XML_MODIFY")]
            WEB_XML_MODIFY,
            [Description("file")]
            DB_SCRIPT,
            [Description("THIRD_PARTY_APP")]
            THIRD_PARTY_APP,
        }
    }
}
