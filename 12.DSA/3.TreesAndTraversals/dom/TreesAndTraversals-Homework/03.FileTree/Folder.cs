namespace _03.FileTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Folder
    {
        public Folder(string path)
        {
            this.Name = path;
            this.Populate(this.Name);
        }

        public string Name { get; private set; }

        public File[] Files { get; private set; }

        public Folder[] ChildFolders { get; private set; }

        private void Populate(string root)
        {
            var dirs = new List<Folder>();
            var files = new List<File>();
            foreach (var directory in Directory.GetDirectories(root))
            {
                try
                {
                    var path = Path.Combine(root, directory);
                    var folder = new Folder(path);
                    dirs.Add(folder);
                    var filenames = Directory.GetFiles(path);
                    if (filenames.Length > 0)
                    {
                        foreach (var filename in filenames)
                        {
                            FileInfo info = new FileInfo(Path.Combine(path, filename));
                            File f = new File(info.Name, info.Length);
                            files.Add(f);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }

                this.Files = files.ToArray();
            }
            this.ChildFolders = dirs.ToArray();
        }

        public static long GetFilesSizesSum(Folder folder)
        {
            long result = 0;
            if (folder.Files!=null)
            {
                result = folder.Files.Sum(x => x.Size);
            }
            
            foreach (var f in folder.ChildFolders)
            {
                if (folder.Files!=null)
                {
                    result += GetFilesSizesSum(f);
                }
               
            }
            return result;
        }
    }
}