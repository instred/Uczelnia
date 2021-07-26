using System;

namespace z1
{
    public class FileMethods
    {
        public class CopyFileCommand : ICommand
        {
            private readonly string _from, _to;

            public CopyFileCommand(string from, string to)
            {
                this._from = from;
                this._to = to;
            }

            public void Execute()
            {
                FileManage.CopyFileCommand(_from, _to);
            }
        }
        
        public class CreateFileCommand : ICommand
        {
            private readonly string _path;

            public CreateFileCommand(string path)
            {
                this._path = path;
            }

            public void Execute()
            {
                FileManage.CreateFileCommand(_path);
            }
        }
        
        public class DownloadFtpCommand : ICommand
        {
            private readonly string _address;

            public DownloadFtpCommand(string address)
            {
                this._address = address;
            }

            public void Execute()
            {
                FileManage.DownloadFtpCommand(_address);
            }
        }
        
        public class DownloadHttpCommand : ICommand
        {
            private readonly string _address;

            public DownloadHttpCommand(string address)
            {
                this._address = address;
            }

            public void Execute()
            {
                FileManage.DownloadHttpCommand(_address);
            }
        }
        
    }
}