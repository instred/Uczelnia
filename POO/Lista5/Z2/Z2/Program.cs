using System;
using System.IO;
using System.Text;

namespace Z2 {

    class CaesarStream : Stream {
        Stream stream;
        int offset;

        public CaesarStream(Stream stream, int offset) {
            this.stream = stream;
            this.offset = offset;
        }

        public override void Write(byte[] buffer, int offset, int count) {
            var newBuffer = new byte[buffer.Length];
            for (int i = 0; i < buffer.Length; i++) {
                newBuffer[i] = (byte)((buffer[i] + this.offset) % 255);
            }
            this.stream.Write(newBuffer, offset, count);
        }

        public override int Read(byte[] buffer, int offset, int count) {
            var result = this.stream.Read(buffer, offset, count);
            for (int i = 0; i < buffer.Length; i++) {
                buffer[i] = (byte)((buffer[i] + this.offset) % 255);
            }
            return result;
        }

        public override bool CanRead
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanSeek
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanWrite
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

    }

    class Example {
        public static void Main() {
            const string example = "lorem ipsum blahblah";

            var fileToWrite = File.Create("example.txt");
            CaesarStream writer = new CaesarStream(fileToWrite, 7);
            writer.Write(Encoding.ASCII.GetBytes(example));
            fileToWrite.Close();

            var fileToRead = File.OpenRead("example.txt");
            var output = new byte[100];
            CaesarStream reader = new CaesarStream(fileToRead, -7);
            reader.Read(output);

            Console.WriteLine("before: '{0}'", example);
            var fileToWrite2 = File.OpenRead("example.txt");
            var encrypted = new byte[100];
            fileToWrite2.Read(encrypted);
            Console.WriteLine(
                "encrypted: {0}", Encoding.ASCII.GetString(encrypted)
                );
            Console.WriteLine(
                "function check after write+read: '{0}'", Encoding.ASCII.GetString(output)
                );
        }
    }
}
