using System.Diagnostics;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

//using java.io;
//using ikvm.decompiler;

namespace FindFile
{
    public partial class GenLicense : Form
    {
        public GenLicense()
        {
            InitializeComponent();
            //CompareMappings();
            cboOperatingSystem.SelectedIndex = 0;
            //ExtractFieldMappings();
            ////ExtractFieldMappings(DocumentTypes_2.2.0);
            //string filePath = "C:\\EpheSoft\\Resources\\ID Capture-Quick Screen Document Library\\DocumentTypes_3.8.txt";
            ////var docTypeOld = readHtml(filePath);
            //filePath = "C:\\EpheSoft\\Resources\\ID Capture-Quick Screen Document Library\\DocumentTypes_2.2.0.txt";
            //var docTypeNew = readHtml(filePath);
            //Console.WriteLine();
            //copy();
        }

        static void copy()
        {
            string sourceDirectory = @"c:\Users\quanhong.le\.m2\repository\org\springframework\";
            string destinationDirectory = @"c:\EpheSoft\Sources\transact-Smart-ID-Engine-SDK\transact-id-capture-utility\lib\";

            CopyJarFiles(sourceDirectory, destinationDirectory);

        }

        static void CopyJarFiles(string sourceDir, string destinationDir)
        {

            string[] jarFiles = Directory.GetFiles(sourceDir, "*.jar", SearchOption.AllDirectories);

            foreach (string jarFile in jarFiles)
            {
                try
                {
                    string destinationFile = Path.Combine(destinationDir, Path.GetFileName(jarFile));

                    File.Copy(jarFile, destinationFile, true);

                    Console.WriteLine($"Copied: {jarFile}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error copying file {jarFile}: {ex.Message}");
                }
            }
        }

        public static void CompareMappings()
        {
            string mappingOld = "C:\\Users\\quanhong.le\\source\\repos\\FindFile\\HF\\transact-idmax-mapping.xml";
            string mappingNew = "C:\\Users\\quanhong.le\\source\\repos\\FindFile\\HF\\transact-idmax-mapping-new.xml";
            XDocument doc = XDocument.Load(mappingOld);

            var documentTypeOlds = doc.Descendants("documentType")
                .Select(x => new
                {
                    transactDocumentType = (string)x.Element("transactDocumentType"),
                    idMaxDocumentType = (string)x.Element("idMaxDocumentType"),
                    description = (string)x.Element("description"),
                    documentTypeIndex = (string)x.Element("documentTypeIndex")
                }).ToList();
            XDocument docNew = XDocument.Load(mappingNew);
            var documentTypeNews = docNew.Descendants("documentType")
                .Select(x => new
                {
                    transactDocumentType = (string)x.Element("transactDocumentType"),
                    idMaxDocumentType = (string)x.Element("idMaxDocumentType"),
                    description = (string)x.Element("description"),
                    documentTypeIndex = (string)x.Element("documentTypeIndex")
                }).ToList();

            var documentTypeOld = documentTypeOlds.Select(e => e.transactDocumentType).ToList();

            var docTypeNewOnly = documentTypeNews.Where(e => !documentTypeOld.Contains(e.transactDocumentType)).ToList();


            var docTypesDif = new List<object>();


            documentTypeOlds.ForEach(d =>
            {
                var docTypeNew = documentTypeNews.FirstOrDefault(e => e.documentTypeIndex == d.documentTypeIndex);
                if (docTypeNew != null && docTypeNew.transactDocumentType != d.transactDocumentType)
                    docTypesDif.Add(docTypeNew);
            });


            Console.WriteLine("");
        }

        public class Document
        {
            public string DocumentType { get; set; }
            public List<string> StringFields { get; set; }
        }

        public class Field
        {
            public string Name { get; set; }
        }

        static List<Document> readHtml(string filePath)
        {
            string htmlContent = string.Empty;

            using (StreamReader reader = new StreamReader(filePath))
            {
                htmlContent = reader.ReadToEnd();
            }

            List<Document> documents = ParseHtmlTable(htmlContent);

            //// In thông tin của các đối tượng Document
            //foreach (var document in documents)
            //{
            //    Console.WriteLine($"DocumentType: {document.DocumentType}");
            //    Console.WriteLine("StringFields: [" + string.Join(", ", document.StringFields) + "]");
            //    Console.WriteLine();
            //}
            return documents;
        }

        static List<Document> ParseHtmlTable(string htmlContent)
        {
            List<Document> documents = new List<Document>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlContent);

            // Xác định các hàng của bảng
            var rows = doc.DocumentNode.SelectNodes("//tbody/tr");

            if (rows != null)
            {
                foreach (var row in rows)
                {
                    var cells = row.SelectNodes("td");

                    if (cells == null) continue;
                    // Lấy dữ liệu từ cột 2 (Document type) và cột 5 (String Fields)
                    string documentType = cells[1].InnerText.Trim();
                    string stringFields = cells[4].InnerText.Trim();

                    // Tách các trường từ chuỗi và chuyển thành danh sách
                    //List<string> stringFieldsList = stringFields.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();


                    //string[] result = stringFields.Split(new string[] { "\\r\\n" }, StringSplitOptions.None);
                    List<string> stringFieldsList = stringFields.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();



                    //var fields = new List<Field>();
                    //stringFieldsList.ForEach(f =>
                    //{
                    //    fields.Add(new Field { Name = f });
                    //});


                    // Tạo đối tượng Document và thêm vào danh sách
                    Document document = new Document
                    {
                        DocumentType = documentType,
                        StringFields = stringFieldsList
                    };

                    documents.Add(document);
                }
            }
            //var docTypes = documents;

            //string docTypeName = "snils";
            //string docType = "."+ docTypeName + ".";
            //docTypes = documents.Where(e => e.DocumentType.Contains(docType)).ToList();

            getDocTypeNew(documents);

            return documents;
        }

        private static void getDocTypeNew(List<Document> documents)
        {
            string docTypesOld = "2p,aadhaar,ammpid,asylum,barcode,birth_certificate,border_crossing,card,cpti,crop," +
                "death_certificate,divorce_certificate,drvlic,employment_record,health_insurance,homereturn," +
                "id,inn,insurance,marriage_certificate,migration_card,mrz,name_change_certificate,oms,pancard," +
                "passport,passport_card,pilotlic,pts,re_license,residence,rp,snils,sts,tin,visa,vrc,vrd,work,work_permit,wp";

            var docTypes = docTypesOld.Split(',').ToList();
            docTypes.ForEach(d =>
            {
                string docType = "." + d + ".";
                documents = documents.Where(e => !e.DocumentType.Contains(docType)).ToList();
            });

            var docNews = documents.Select(e => e.DocumentType).ToList();
            List<string> doc0 = new List<string>();
            List<string> doc1 = new List<string>();
            List<string> doc2 = new List<string>();

            docNews.ForEach(d =>
            {
                var split = d.Split('.');
                switch (split.Length)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                        doc0.Add(d);
                        break;
                    case 3:
                    case 4:
                        doc1.Add(split[1]);
                        break;
                }
            });

            //string filePath = "C:\\EpheSoft\\Sources\\transact-Smart-ID-Engine-SDK\\NewDocType.txt";
            var docs = doc0.Concat(doc1).Distinct().ToArray();
            //WriteStringArrayToFile(docs, filePath);
            var news = documents;
        }

        static void WriteStringArrayToFile(string[] stringArray, string filePath)
        {
            // Sử dụng StreamWriter để ghi vào tệp văn bản
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Duyệt qua từng phần tử trong mảng và ghi vào tệp
                foreach (string line in stringArray)
                {
                    writer.WriteLine(line);
                }
            }
        }

        public static void ExtractFieldMappings()
        {
            string xmlPath = "C:\\EpheSoft\\Sources\\transact-Smart-ID-Engine-SDK\\transact-id-capture\\src\\main\\resources\\META-INF\\transact-id-extract\\transact_idmax_mapping.xml";
            string txtPath = "C:\\EpheSoft\\Sources\\transact-Smart-ID-Engine-SDK\\transact_idmax_anydoc_mapping.txt";

            XDocument doc = XDocument.Load(xmlPath);

            using (StreamWriter writer = new StreamWriter(txtPath))
            {
                foreach (XElement fieldMapping in doc.Descendants("fieldMapping"))
                {
                    writer.WriteLine(fieldMapping.ToString());
                }
            }
        }
        public static void ExtractFieldMappings1()
        {
            string xmlPath = "C:\\EpheSoft\\products\\transact-id-capture\\src\\main\\resources\\META-INF\\transact-id-extract\\transact_idmax_mapping.xml";
            string txtPath = "C:\\EpheSoft\\products\\transact-id-capture\\src\\main\\resources\\META-INF\\transact-id-extract\\transact_idmax_mapping.txt";
            XDocument doc = XDocument.Load(xmlPath);

            var fieldMappings = doc.Descendants("fieldMapping")
                .Select(x => new
                {
                    TransactKey = (string)x.Element("transactFieldKey"),
                    TransactName = (string)x.Element("transactFieldName"),
                    IdMaxName = (string)x.Element("idMaxFieldName"),
                    Description = (string)x.Element("description")
                })
                 .ToList();

            using (StreamWriter writer = new StreamWriter(txtPath))
            {
                foreach (var mapping in fieldMappings)
                {
                    writer.WriteLine($"{mapping.TransactKey},{mapping.TransactName},{mapping.IdMaxName},{mapping.Description}");
                }
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                //var files = from file in Directory.EnumerateFiles(txtDirectory.Text, "*.zip", SearchOption.AllDirectories)
                //            select file;
                //foreach (var file in files)
                //{
                //    ZipFile.ExtractToDirectory(file, file.Substring(0,file.Length-4), true);
                //    txtResult.Text = $"extracting {file} ...";
                //}

                //txtResult.Text = "done";


                txtResult.Text = "";

                Cursor.Current = Cursors.WaitCursor;
                string[] files = Directory.GetFiles(txtDirectory.Text, "*", SearchOption.AllDirectories).Where(file => file.Contains(txtFileName.Text)).ToArray();
                foreach (var file in files)
                {
                    var result = $"{file}{Environment.NewLine}" + "--------------------------------------------------------" + Environment.NewLine;
                    txtResult.Text += result;
                }




                ////string[] files = Directory.GetFiles(txtDirectory.Text, "*.xml", SearchOption.AllDirectories);
                //Cursor.Current = Cursors.WaitCursor;
                ////var files = from file in Directory.EnumerateFiles(txtDirectory.Text, txtFileName.Text, SearchOption.AllDirectories)
                //var files = from file in Directory.EnumerateFiles(txtDirectory.Text, txtFileName.Text, SearchOption.AllDirectories)
                //            select file;
                //foreach (var file in files)
                //{
                //    var result =
                //         $"File:   {file}{Environment.NewLine}" +
                //         $"MD5:    {HashFile.MD5(file)}{Environment.NewLine}" +
                //         $"SHA1:   {HashFile.SHA1(file)}{Environment.NewLine}" +
                //         $"SHA256: {HashFile.SHA256(file)}{Environment.NewLine}";
                //    txtResult.Text += result + "--------------------------------------------------------" + Environment.NewLine;
                //}
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnChecksum_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult2.Text = "";
                //Cursor.Current = Cursors.WaitCursor;
                //var file = txtFilePath.Text;
                //var result = $"File: {file}{Environment.NewLine}" +
                //        $"MD5:{HashFile.MD5(file)}{Environment.NewLine}" +
                //        $"SHA1:{HashFile.SHA1(file)}{Environment.NewLine}" +
                //        $"SHA256:{HashFile.SHA256(file)}{Environment.NewLine}";
                //txtResult2.Text = result + "----------------------------" + Environment.NewLine;
                Cursor.Current = Cursors.WaitCursor;
                var files = from file in Directory.EnumerateFiles(txtFilePath.Text, txtFieName2.Text, SearchOption.AllDirectories)
                            select file;
                foreach (var file in files)
                {
                    var result =
                        $"File:      {file}{Environment.NewLine}" +
                        $"MD5:     {HashFile.MD5(file)}{Environment.NewLine}" +
                        $"SHA1:    {HashFile.SHA1(file)}{Environment.NewLine}" +
                        $"SHA256: {HashFile.SHA256(file)}{Environment.NewLine}";
                    txtResult2.Text += result + "--------------------------------------------------------" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                txtResult2.Text = ex.Message;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //var files = from file in Directory.EnumerateFiles(txtDirectory1.Text, "*.zip", SearchOption.AllDirectories)
                //            select file;
                //foreach (var file in files)
                //{
                //    ZipFile.ExtractToDirectory(file, file.Substring(0, file.Length - 4), true);
                //}

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnFinFolder_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtResult.Text = "";
            string[] subDirectories = Directory.GetDirectories(txtDirectory.Text, "*", SearchOption.AllDirectories);
            var searchFolder = txtFileName.Text;
            // Duyệt qua tất cả các thư mục con của thư mục gốc và tìm kiếm thư mục cần tìm
            foreach (string subDir in subDirectories)
            {
                if (Path.GetFileName(subDir).Contains(searchFolder))
                {
                    txtResult.Text += subDir + Environment.NewLine;

                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnExtractJar_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //var files = from file in Directory.EnumerateFiles(txtDirectory1.Text, "*.jar", SearchOption.AllDirectories)
                //            select file;
                ////foreach (var filePath in files)
                ////{
                ////    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(filePath))
                ////    {
                ////        foreach (Ionic.Zip.ZipEntry entry in zip)
                ////        {
                ////            if (!entry.IsDirectory)
                ////            {
                ////                entry.Extract(filePath[..^4]);
                ////            }
                ////        }
                ////    }
                ////}

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            Cursor.Current = Cursors.Default;


        }

        private void btnNameLike_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult2.Text = "";//SNAPSHOT.jar
                //txtFieName2.Text
                Cursor.Current = Cursors.WaitCursor;
                var files = from file in Directory.EnumerateFiles(txtFilePath.Text, "*SNAPSHOT.jar", SearchOption.AllDirectories)
                            select file;
                foreach (var file in files)
                {
                    var result = $"{file}{Environment.NewLine}" + "--------------------------------------------------------" + Environment.NewLine;
                    txtResult2.Text += result;
                }
            }
            catch (Exception ex)
            {
                txtResult2.Text = ex.Message;
            }
            Cursor.Current = Cursors.Default;
        }


        /*
         https://ephesoft.atlassian.net/wiki/spaces/PHOEN/pages/428441624/Development+Environment
            to compile the code use following maven commands at the root directory if entire code needs to be built or go to a specific module if only that particular module needs to be built
            To Initial ZKM plugin installation:
	            mvn org.apache.maven.plugins:maven-install-plugin:2.5.2:install-file -Dfile=build-utils\code-obfuscate\jars\zkm-plugin-1.0.3.jar -DZKM_HOME=build-utils\code-obfuscate\jars\

            For Build:
	            mvn clean install -f pom.xml -DskipTests -Dfindbugs.skip=true -Dobfuscate.skip -Dgwt.style=DETAILED
         */
        private void btnMvn_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] subfolders = Directory.GetDirectories(txtDirectory1.Text, "*", SearchOption.TopDirectoryOnly);

                //string commandLine = "mvn clean install -f pom.xml -DskipTests -Dfindbugs.skip=true -Dobfuscate.skip -Dgwt.style=DETAILED";
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "result.txt";
                //if (!File.Exists(path))
                //    File.Create(path).Close();
                //foreach (string subfolder in subfolders)
                //{
                //    var files = from file in Directory.EnumerateFiles(subfolder, "pom.xml", SearchOption.AllDirectories)
                //                select file;
                //    if (!files.Any()) continue;
                //    if (subfolder.Contains("transact.app", StringComparison.OrdinalIgnoreCase)) continue;
                //    Process process = new Process();
                //    process.StartInfo.FileName = "cmd.exe";
                //    process.StartInfo.WorkingDirectory = subfolder;// $@"C:\EpheSoft\products\Transact\transact.license.core";
                //    process.StartInfo.Arguments = $"/C {commandLine}"; // Chạy lệnh và đóng Command Prompt khi hoàn thành
                //    process.StartInfo.UseShellExecute = false;
                //    process.StartInfo.RedirectStandardOutput = true;
                //    process.StartInfo.CreateNoWindow = true;
                //    process.Start();
                //    txtResult2.Text += $"{Environment.NewLine}{subfolder}";
                //    string output = process.StandardOutput.ReadToEnd();

                //    process.WaitForExit();

                //    using (StreamWriter writer = File.AppendText(path))
                //    {
                //        writer.WriteLine($"{Environment.NewLine}" +
                //        $"========{subfolder}============{Environment.NewLine}" +
                //        $"{output}");
                //    }
                //    txtResult.Text += $"{Environment.NewLine}" +
                //        $"========{subfolder}============{Environment.NewLine}" +
                //        $"{output}";

                //}

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        private void btnMvnCommand_Click(object sender, EventArgs e)
        {
            try
            {
                //string[] subfolders = Directory.GetDirectories(txtDirectory1.Text, "*", SearchOption.TopDirectoryOnly);

                //string resultStr = "";
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "result.txt";
                //if (!File.Exists(path))
                //    File.Create(path).Close();
                //foreach (string subfolder in subfolders)
                //{
                //    var files = from file in Directory.EnumerateFiles(subfolder, "pom.xml", SearchOption.AllDirectories)
                //                select file;
                //    if (!files.Any()) continue;

                //    txtResult.Text += $"=========================={Environment.NewLine}" +
                //        $"cd {subfolder}{Environment.NewLine}" +
                //        $"mvn org.apache.maven.plugins:maven-install-plugin:2.5.2:install-file -Dfile=build-utils\\code-obfuscate\\jars\\zkm-plugin-1.0.3.jar -DZKM_HOME=build-utils\\code-obfuscate\\jars\\{Environment.NewLine}" +
                //        $"mvn clean install -f pom.xml -DskipTests -Dfindbugs.skip=true -Dobfuscate.skip -Dgwt.style=DETAILED{Environment.NewLine}";

                //}

                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnShoDependency_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //string[] subfolders = Directory.GetDirectories(txtDirectory1.Text, "*", SearchOption.TopDirectoryOnly);

                //string commandLine = "mvn dependency:tree -Dverbose";

                //foreach (string subfolder in subfolders)
                //{
                //    var files = from file in Directory.EnumerateFiles(subfolder, "pom.xml", SearchOption.AllDirectories)
                //                select file;
                //    if (!files.Any()) continue;

                //    Process process = new Process();
                //    process.StartInfo.FileName = "cmd.exe";
                //    process.StartInfo.WorkingDirectory = subfolder;// $@"C:\EpheSoft\products\Transact\transact.license.core";
                //    process.StartInfo.Arguments = $"/C {commandLine}"; // Chạy lệnh và đóng Command Prompt khi hoàn thành
                //    process.StartInfo.UseShellExecute = false;
                //    process.StartInfo.RedirectStandardOutput = true;
                //    process.StartInfo.CreateNoWindow = false;
                //    process.Start();
                //    txtResult2.Text += $"{Environment.NewLine}{subfolder}";
                //    string output = process.StandardOutput.ReadToEnd();

                //    process.WaitForExit();

                //    txtResult.Text += $"{Environment.NewLine}" +
                //        $"========{subfolder}============{Environment.NewLine}" +
                //        $"{output}";
                //}
                //Cursor.Current = Cursors.Default;
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnDependencyOne_Click(object sender, EventArgs e)
        {
            try
            {
                //Cursor.Current = Cursors.WaitCursor;
                //string folder = txtDirectory1.Text;

                //string commandLine = "mvn dependency:tree -Dverbose";

                //var files = from file in Directory.EnumerateFiles(folder, "pom.xml", SearchOption.AllDirectories)
                //            select file;
                //if (!files.Any()) return;

                //Process process = new Process();
                //process.StartInfo.FileName = "cmd.exe";
                //process.StartInfo.WorkingDirectory = folder;// $@"C:\EpheSoft\products\Transact\transact.license.core";
                //process.StartInfo.Arguments = $"/C {commandLine}"; // Chạy lệnh và đóng Command Prompt khi hoàn thành
                //process.StartInfo.UseShellExecute = false;
                //process.StartInfo.RedirectStandardOutput = true;
                //process.StartInfo.CreateNoWindow = false;
                //process.Start();
                //txtResult2.Text += $"{Environment.NewLine}{folder}";
                //string output = process.StandardOutput.ReadToEnd();

                //process.WaitForExit();

                //txtResult.Text += $"{Environment.NewLine}" +
                //    $"========{folder}============{Environment.NewLine}" +
                //    $"{output}";
                //Cursor.Current = Cursors.Default;
                //MessageBox.Show("Done");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnNameContain_Click(object sender, EventArgs e)
        {
            try
            {
                //txtResult2.Text = "";

                Cursor.Current = Cursors.WaitCursor;
                string[] files = Directory.GetFiles(txtFilePath.Text, "*", SearchOption.AllDirectories).Where(file => file.Contains(txtFieName2.Text)).ToArray();
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long fileSize = fileInfo.Length;
                    double fileSizeInKb = fileSize / 1024.0;
                    double fileSizeInMb = fileSizeInKb / 1024.0;

                    var result = $"{file}{Environment.NewLine} {fileSizeInMb} Mb{Environment.NewLine}" + "--------------------------------------------------------" + Environment.NewLine;

                    txtResult2.Text += result;
                }

                //Cursor.Current = Cursors.WaitCursor;
                //var files = from file in Directory.EnumerateFiles(txtFilePath.Text, txtFieName2.Text, SearchOption.AllDirectories)
                //            select file;
                //foreach (var file in files)
                //{
                //    var result =
                //        $"File:      {file}{Environment.NewLine}" +
                //        $"MD5:     {HashFile.MD5(file)}{Environment.NewLine}" +
                //        $"SHA1:    {HashFile.SHA1(file)}{Environment.NewLine}" +
                //        $"SHA256: {HashFile.SHA256(file)}{Environment.NewLine}";
                //    txtResult2.Text += result + "--------------------------------------------------------" + Environment.NewLine;
                //}
            }
            catch (Exception ex)
            {
                txtResult2.Text = ex.Message;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnWebService_Click(object sender, EventArgs e)
        {
            // Set the location to show the ContextMenuStrip control
            Point location = new Point(btnWebService.Left, btnWebService.Bottom);
            contextMenuStrip1.Show(this, location);
        }

        private void getBatchClassListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //String url = "http://localhost:8080/dcma/rest/getBatchClassList";
            //GetMethod mGet = new GetMethod(url);
            //int statusCode;
            //try
            //{
            //    statusCode = client.executeMethod(mGet);
            //    if (statusCode == 200)
            //    {
            //        System.out.println("Web service executed successfully.");
            //        String responseBody = mGet.getResponseBodyAsString();
            //        System.out.println(statusCode + " *** " + responseBody);
            //    }
            //    else if (statusCode == 403)
            //    {
            //        System.out.println("Invalid username/password.");
            //    }
            //    else
            //    {
            //        System.out.println(mGet.getResponseBodyAsString());
            //    }
            //}
            //catch (HttpException e)
            //{
            //    e.printStackTrace();
            //}
            //catch (IOException e)
            //{
            //    e.printStackTrace();
            //}
            //finally
            //{
            //    if (mGet != null)
            //    {
            //        mGet.releaseConnection();
            //    }
            //}
        }

        string FormatMacAddress(string address)
        {
            address = address.Replace(":", "");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < address.Length; i += 2)
            {
                sb.Append(address.Substring(i, 2));

                if (i < address.Length - 2) // insert - except last block
                {
                    sb.Append("-");
                }
            }

            return sb.ToString();
        }

        private void btnActiveLicense_Click(object sender, EventArgs e)
        {
            ////txtMacAddress.Text = "";
            //var adds = new List<string>();
            //foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    if (nic.OperationalStatus == OperationalStatus.Up)
            //    {
            //        var phyAdd = nic.GetPhysicalAddress().ToString();
            //        if (!string.IsNullOrEmpty(phyAdd))
            //            adds.Add(FormatMacAddress(nic.GetPhysicalAddress().ToString()));
            //    }
            //}
            //txtResult.Text = string.Join("|", adds);

            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var antPath = Path.Combine(executableDir, "Resources\\apache-ant-1.10.14");
            var licenseUtilPath = Path.Combine(executableDir, "Resources\\license-util");
            var LicenseReleasePath = Path.Combine(executableDir, "Resources\\LicenseRelease\\LicenseRelease");


            //ZipFile.ExtractToDirectory(txtDirectory1.Text, "C:\\LicenseRelease", true);

            //Edit License.info.Properties-> Enter Mac Address and other info
            string filePath = $@"{LicenseReleasePath}\ephesoft-license-generator\META-INF\ephesoft-license-generator\license.info.properties";
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(LicenseInfoProperties());
            }
            //Command to execute in CMD
            string command = $"ant -f  {LicenseReleasePath}\\ephesoft-license-generator\\run.xml";



            CommandToExecute(antPath, command);

            string sourceFilePath = $"{antPath}\\ephesoft.lic";
            string destinationFilePath = $"{licenseUtilPath}\\ephesoft.lic";

            // Copy the file
            File.Copy(sourceFilePath, destinationFilePath, true);

            command = "install-license.bat";
            CommandToExecute($"{licenseUtilPath}", command);
        }

        private void CommandToExecute(string directory, string command)
        {
            // Create a new process
            Process process = new Process();

            // Set the start info for the process
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.WorkingDirectory = directory;
            startInfo.Arguments = "/c " + command;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            process.StartInfo = startInfo;

            // Start the process
            process.Start();

            // Read the output
            string output = process.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            process.WaitForExit();

            // Display the output
            txtResult.Text += output;
        }

        private string LicenseInfoProperties()
        {
            var info = "	ephesoft.license.date.issued=August 18 2022" + Environment.NewLine;

            info += "	ephesoft.license.date.not_before=October 30 2010" + Environment.NewLine;
            info += $"	ephesoft.license.date.not_after={txtLicenseExpiryDate.Text}" + Environment.NewLine;

            info += $"	ephesoft.license.ocr_cpu_count={txtOcr_cpu_count.Text}" + Environment.NewLine;
            info += $"	ephesoft.license.server.mac_address={txtMacAddress.Text}" + Environment.NewLine;

            info += "	ephesoft.license.server.port=21099" + Environment.NewLine;
            info += "	ephesoft.license.server.webServiceSwitch=ON" + Environment.NewLine;

            info += "	ephesoft.license.server.licenseExpiryMsgDays=30" + Environment.NewLine;
            info += "	ephesoft.license.server.verifyPlatinumSupport=OFF" + Environment.NewLine;

            info += "	ephesoft.license.server.highPerformanceSwitch=ON" + Environment.NewLine;
            info += "	#Reporting license type Value : 0 for Standard,1 for Advanced, 2 for Advanced With Custom Reporting" + Environment.NewLine;

            info += "	ephesoft.license.server.advancedReportingSwitch=0" + Environment.NewLine;
            info += $"	ephesoft.license.server.annualImageCount={txtServerAnnuaImageCount.Text}" + Environment.NewLine;

            info += "	ephesoft.license.server.annualOverageImageCount=9999" + Environment.NewLine;
            info += "	ephesoft.license.server.webServiceHitsPerDay=0" + Environment.NewLine;

            info += "	#Web Service license type Value : 0 for ImageCount, 1 for HitsPerDay." + Environment.NewLine;
            info += "	ephesoft.license.server.webServiceLicenseType=0" + Environment.NewLine;

            var system = 0;
            switch (cboOperatingSystem.SelectedIndex)
            {
                case 0:
                    system = 0;
                    break;
                case 1:
                    system = 1;
                    break;
                case 2:
                    system = 2;
                    break;
            }
            String ideSwitch = "";
            switch (cboIdeSwitch.SelectedIndex)
            {
                case 0:
                    ideSwitch = "ON";
                    break;
                case 1:
                    ideSwitch = "OFF";
                    break;
            }

            info += "	#Operating System Type. 0 for Windows, 1 For Linux, 2 for Both Windows+Linux" + Environment.NewLine;
            info += $"	ephesoft.license.server.operatingSystem={system}" + Environment.NewLine;

            info += "	#Ephesoft License Type. 0 for Subscription, 1 for Perpetual." + Environment.NewLine;
            info += "	ephesoft.license.server.licenseType=0" + Environment.NewLine;

            info += "	#Ephesoft License Version" + Environment.NewLine;
            info += $"	ephesoft.license.server.licenseVersion={txtLicenseVersion.Text}" + Environment.NewLine;

            info += "	#Supported OCR Languages.Comma separated list. 0 for default, 1 for Arabic, 2 for Asian." + Environment.NewLine;
            info += "	ephesoft.license.server.ocrLanguages=0,1,2" + Environment.NewLine;

            info += "	#Comma separated list of Premium BatchClasses." + Environment.NewLine;
            info += "	ephesoft.license.server.premiumBatchClasses=" + Environment.NewLine;

            info += "	# whether IDE is enabled (ON) or not (OFF). Name 'switch' is chosen to be consistent with other properties e.g. webServiceSwitch" + Environment.NewLine;
            info += $"	ephesoft.license.ide.switch={ideSwitch}" + Environment.NewLine;

            info += "	# IDE feature expiry date, can be less than or equal to ephesoft.license.date.not_after" + Environment.NewLine;
            info += $"	ephesoft.license.ide.date.not_after={txtIDExpiryDate.Text}" + Environment.NewLine;

            info += "	# IDE annual image count, can be independent of ephesoft.license.server.annualImageCount" + Environment.NewLine;
            info += $"	ephesoft.license.ide.annualImageCount={txtIDEAnnuaImageCount.Text}" + Environment.NewLine;

            info += "	# Whether ICR Plus is enabled (ON) or not (OFF). Name 'switch' is chosen to be consistent with other properties e.g. webServiceSwitch" + Environment.NewLine;
            info += "	ephesoft.license.icrplus.switch=ON" + Environment.NewLine;

            info += "	# ICR Plus feature expiry date, can be less than or equal to ephesoft.license.date.not_after" + Environment.NewLine;
            info += "	ephesoft.license.icrplus.date.not_after=December 30 2030" + Environment.NewLine;

            info += "	# ICR Plus annual image count, can be independent of ephesoft.license.server.annualImageCount" + Environment.NewLine;
            info += $"	ephesoft.license.icrplus.annualImageCount={txtICRPlusAnnualImageCount.Text}" + Environment.NewLine;

            info += "	# License Server installation environment type. 1 for Production, 2 for Test" + Environment.NewLine;
            info += "	ephesoft.license.server.env.type=1" + Environment.NewLine;

            info += "	# License model type. 1 for Core, 2 for Consumption" + Environment.NewLine;
            info += "	ephesoft.license.model.type=1" + Environment.NewLine;

            info += "	# License customer account name." + Environment.NewLine;
            info += "	ephesoft.license.account.name=QaanLeeHoong Ephesoft" + Environment.NewLine;

            info += "	# Unique license Id per license" + Environment.NewLine;
            info += "	ephesoft.license.account.licenseId=38504dee-f173-4ca3-a958-34434b5244e1" + Environment.NewLine;

            info += "	# License scope.0 for Internal, 1 for External" + Environment.NewLine;
            info += "	ephesoft.license.scope=0" + Environment.NewLine;


            return info;
        }

        private void btnInstallerUpgradeEphesoft_Click(object sender, EventArgs e)
        {
            var directory = "C:\\jdks\\jdk-11.0.19+7\\bin";
            var command = "javac -s bin -cp C:/EpheSoft/products/Ephesoft.git/transact-installer/InstallerRequirements/Linux/LinuxUpgrade/UpgradeEphesoft-4.0/src/com/ephesoft/*.java";
            //compile java to class
            CommandToExecute(directory, command);

            string sourceDirectory = @"C:/EpheSoft/products/Ephesoft.git/transact-installer/InstallerRequirements/Linux/LinuxUpgrade/UpgradeEphesoft-4.0/src/com/ephesoft";
            string targetDirectory = @"C:\com\ephesoft";
            string searchPattern = "*.class";

            string[] files = Directory.GetFiles(sourceDirectory, searchPattern);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(targetDirectory, fileName);
                File.Move(file, destinationPath, true);
            }

            File.Copy("C:\\EpheSoft\\products\\Ephesoft.git\\transact-installer\\InstallerRequirements\\Linux\\LinuxUpgrade\\UpgradeEphesoft-4.0\\src\\com\\ephesoft\\resource\\beanElimination.properties",
                "C:\\com\\ephesoft\\resource\\beanElimination.properties", true);


            directory = "C:\\jdks\\jdk-11.0.19+7\\bin";
            command = "jar cf UpgradeEphesoft.jar C:\\com";
            CommandToExecute(directory, command);

            File.Move(directory + "\\UpgradeEphesoft.jar",
                "C:\\EpheSoft\\products\\Ephesoft.git\\transact-installer\\InstallerRequirements\\Linux\\Ephesoft\\Dependencies\\UpgradeEphesoft.jar", true);

        }

        static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && !nic.Description.ToLower().Contains("virtual"))
                {
                    return nic.GetPhysicalAddress();
                }
            }

            throw new Exception("No active network interface found.");
        }

        private void btnDecompiler_Click(object sender, EventArgs e)
        {
            //// Specify the path to the JAR file
            //string jarFilePath = "path/to/your.jar";

            //// Specify the name of the class to decompile
            //string className = "com.example.MyClass";

            //// Load the JAR file using IKVM.NET
            //java.util.jar.JarFile jarFile = new java.util.jar.JarFile(jarFilePath);

            //try
            //{
            //    // Get the class entry from the JAR file
            //    java.util.jar.JarEntry entry = jarFile.getJarEntry(className.Replace('.', '/') + ".class");

            //    // Create a new instance of the decompiler
            //    Decompiler decompiler = new Decompiler();

            //    // Set the output directory for the decompiled Java file
            //    decompiler.Directory = new java.io.File("output/directory");

            //    // Decompile the class and save it to a Java file
            //    decompiler.Decompile(entry, jarFile);

            //    Console.WriteLine("Decompilation completed successfully.");
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine("Error occurred during decompilation: " + ex.Message);
            //}
            //finally
            //{
            //    // Close the JAR file
            //    jarFile.close();
            //}
        }

        string _hotfixName = "";
        string _hotfixVersion = "";
        string _hotfixEnviroment = "";
        private void btnGenHF_Click(object sender, EventArgs e)
        {
            HotFixBuild hfForm = new();
            hfForm.ShowDialog();


            return;
            _hotfixVersion = txtVersion.Text;
            _hotfixEnviroment = txtEnv.Text;
            _hotfixName = $"Hotfix-{_hotfixVersion}-{_hotfixEnviroment}";

            var rootDir = Path.Combine(txtHFPath.Text, _hotfixName);
            var rootVersionDir = Path.Combine(rootDir, _hotfixVersion);

            Directory.CreateDirectory(rootDir);
            Directory.CreateDirectory(rootVersionDir);

            var pdtToolDir = Path.Combine(rootVersionDir, "PDT-TOOL");
            var deliverablesDir = Path.Combine(rootVersionDir, "deliverables");

            // root version
            Directory.CreateDirectory(deliverablesDir);
            Directory.CreateDirectory(pdtToolDir);
            //File.Create(Path.Combine(rootVersionDir, "readme.txt"));
            UpdateReadme(rootVersionDir, true);
            // PDT-TOOL
            Directory.CreateDirectory(Path.Combine(pdtToolDir, "deliverables"));
            CopyHFFile(pdtToolDir);
            File.WriteAllText(Path.Combine(pdtToolDir, "ephesoft-generic-installer-1.0-SNAPSHOT.jar"), "Content of ephesoft-generic-installer-1.0-SNAPSHOT.jar");

            //deliverables build hot fix file zip structue
            var deliHotfixDir = Path.Combine(deliverablesDir, _hotfixName);
            Directory.CreateDirectory(deliHotfixDir);

            var deliVerDir = Path.Combine(deliHotfixDir, $"{_hotfixVersion}");
            Directory.CreateDirectory(deliVerDir);

            Directory.CreateDirectory(Path.Combine(deliVerDir, "backup"));
            //File.Create(Path.Combine(deliVerDir, "readme.txt"));
            UpdateReadme(deliVerDir, false);
            File.WriteAllText(Path.Combine(deliVerDir, "dcma-xxx.jar"), "Content of ephesoft-generic-installer-1.0-SNAPSHOT.jar");

        }


        private void UpdateReadme(string destination, bool isRoot)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");

            var readmeFile = "";
            if (isRoot)
                readmeFile = Path.Combine(hfDir, "readmeRoot.txt");
            else
                readmeFile = Path.Combine(hfDir, "readmeDeli.txt");

            string text = File.ReadAllText(Path.Combine(hfDir, readmeFile));

            text = text.Replace("{hotfix-name}", _hotfixName);
            string? extension;
            if (_hotfixEnviroment.Equals("Windows", StringComparison.OrdinalIgnoreCase))
                extension = ".bat";
            else
                extension = ".sh";
            text = text.Replace("{env-extension}", extension);

            text = text.Replace("{version}", _hotfixVersion);

            var hotfixJar = txtResult.Text.Replace("\n", "$").Split("$");
            var jarName = "";
            foreach (var jar in hotfixJar)
            {
                jarName += $"    - {jar}{Environment.NewLine}";
            }

            text = text.Replace("{hot-fix.jar}", jarName);

            //using (StreamWriter writer = new StreamWriter(readmeFile))
            //{
            //    writer.Write(text);
            //}

            string destPath = Path.Combine(destination, $"readme.txt");

            File.WriteAllText(destPath, text);


            //File.Copy(readmeFile, destPath, true);
        }

        private void CopyHFFile(string destination)
        {
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var hfDir = Path.Combine(executableDir, "HF");
            var scriptDir = Path.Combine(hfDir, "Script");

            string? extension;
            if (_hotfixEnviroment.Equals("Windows", StringComparison.OrdinalIgnoreCase))
                extension = ".bat";
            else
                extension = ".sh";

            string sourcePath = Path.Combine(scriptDir, $"generic_installer{extension}");
            string destPath = Path.Combine(destination, $"generic_installer{extension}");
            File.Copy(sourcePath, destPath, true);

            sourcePath = Path.Combine(scriptDir, $"generic_uninstaller{extension}");
            destPath = Path.Combine(destination, $"generic_uninstaller{extension}");
            File.Copy(sourcePath, destPath, true);
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEnv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHFPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGenLic_Click(object sender, EventArgs e)
        {
            //ZipFile.ExtractToDirectory(txtDirectory1.Text, "C:\\LicenseRelease", true);
            var executablePath = Assembly.GetExecutingAssembly().Location;
            var executableDir = Path.GetDirectoryName(executablePath);
            var antPath = Path.Combine(executableDir, "Resources\\apache-ant-1.10.14");
            var licenseUtilPath = Path.Combine(executableDir, "Resources\\license-util");
            var LicenseReleasePath = Path.Combine(executableDir, "Resources\\LicenseRelease\\LicenseRelease");
            //Edit License.info.Properties-> Enter Mac Address and other info
            string filePath = $@"{LicenseReleasePath}\ephesoft-license-generator\META-INF\ephesoft-license-generator\license.info.properties";
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.Write(LicenseInfoProperties());
            }
            //Command to execute in CMD
            string command = $"{antPath}\\bin\\ant -f  {LicenseReleasePath}\\ephesoft-license-generator\\run.xml";
            CommandToExecute(antPath, command);


            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = $"\"{antPath}\""
            };

            Process.Start(startInfo);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string sourceDirectory = @"c:\EpheSoft\Sources\Transact\transact.app\";

            string destinationDirectory = @"c:\EpheSoft\TransactClient\gxt-debug\";

            string fileExtension = "-0.0.15-SNAPSHOT-sources.jar";

            string[] files = Directory.GetFiles(sourceDirectory, "*" + fileExtension, SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string destinationPath = Path.Combine(destinationDirectory, fileName);

                File.Copy(filePath, destinationPath, true);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Thread searchThread = new Thread(() => FindPomFilesWithKeyword(txtSearchFolder.Text, txtSearchKey.Text));
            searchThread.Start();

            //MessageBox.Show("Done","Found",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindPomFilesWithKeyword(string sourceDirectory, string keyword)
        {

            // Tìm tất cả các tệp pom.xml trong thư mục nguồn
            string[] pomFiles = Directory.GetFiles(sourceDirectory, "pom.xml", SearchOption.AllDirectories);

            foreach (string pomFile in pomFiles)
            {
                // Đọc nội dung tệp pom.xml
                string fileContent = File.ReadAllText(pomFile, Encoding.UTF8);

                // Kiểm tra nếu nội dung chứa từ khóa
                if (fileContent.Contains(keyword))
                {
                    //Console.WriteLine($"Tệp {pomFile} chứa từ khóa '{keyword}'");
                    var result = $"{pomFile}{Environment.NewLine}";

                    //txtResult2.Text += result;
                    // Kiểm tra nếu đang chạy trong luồng UI
                    if (txtResult2.InvokeRequired)
                    {
                        // Nếu không, gọi Invoke để chạy mã trong luồng UI
                        txtResult2.Invoke(new Action(() =>
                        {
                            txtResult2.AppendText(result);
                        }));
                    }
                    else
                    {
                        // Nếu đang chạy trong luồng UI, cập nhật TextBox trực tiếp
                        txtResult2.AppendText(result);
                    }
                }
            }

            // Đệ quy vào các thư mục con
            string[] subDirectories = Directory.GetDirectories(sourceDirectory);
            foreach (string subDirectory in subDirectories)
            {
                FindPomFilesWithKeyword(subDirectory, keyword);
            }

            // MessageBox.Show("Done");
        }

        private void GenLicense_Load(object sender, EventArgs e)
        {
            List<string> macAddress = new List<string>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Check if the network interface is operational
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddress.Add(GetMacAddress(nic));
                }
            }
            txtMacAddress.Text = string.Join("|", macAddress);
        }
        static string GetMacAddress(NetworkInterface nic)
        {
            // Get the physical address (MAC)
            PhysicalAddress address = nic.GetPhysicalAddress();
            byte[] bytes = address.GetAddressBytes();
            string macAddress = BitConverter.ToString(bytes);
            return macAddress;
        }
    }
}