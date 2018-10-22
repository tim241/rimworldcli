using System;
using System.IO;
using System.Reflection;

namespace Resources
{
    public class Resource
    {
        private AssemblyName assemblyName { get; set; }

        private Assembly assembly { get; set; }
        private string fileName { get; set; }

        public Resource(string fileName, AssemblyName assemblyName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            if (assemblyName == null)
                throw new ArgumentNullException("assemblyName");

            this.fileName = fileName;
            this.assemblyName = assemblyName;
            this.assembly = Assembly.Load(assemblyName);

            if (!findFile(fileName))
                throw new Exception("Resource doesn't exist!");
        }

        public void Copy(string dest)
        {
            try
            {
                using (Stream resource = assembly.GetManifestResourceStream($"{assemblyName}.{fileName}"))
                {
                    FileStream outputFile = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.Write);
                    
                    int bufferSize = 1024 * 64;
                    int bytesRead = -1;
                    byte[] bytes = new byte[bufferSize];

                    while ((bytesRead = resource.Read(bytes, 0, bufferSize)) > 0)
                    {
                        outputFile.Write(bytes, 0, bytesRead);
                        outputFile.Flush();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("failed to copy file!");
            }
        }

        private bool findFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            foreach (string file in assembly.GetManifestResourceNames())
            {
                if (file.Replace($"{assemblyName.ToString()}.", null) == fileName)
                    return true;
            }

            return false;
        }
    }

}