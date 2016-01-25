using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace Backend.Logic.SoapInterceptor
{
    public class TraceExtension : SoapExtension
    {
        Stream _originalStream;
        Stream _workingStream;


        public override Stream ChainStream(Stream stream)
        {
            _originalStream = stream;
            _workingStream = new MemoryStream();
            return _workingStream;
        }


        public override object GetInitializer(Type serviceType)
        {
            return null;
        }


        public override object GetInitializer(LogicalMethodInfo methodInfo,
                               SoapExtensionAttribute attribute)
        {
            return null;
        }


        public override void Initialize(object initializer)
        {
            // do nothing...  
        }


        public override void ProcessMessage(SoapMessage message)
        {

            switch (message.Stage)
            {
                case SoapMessageStage.BeforeDeserialize:
                    message.ContentType = "text/xml";
                    // Incoming message  
                    if (_workingStream.CanSeek)
                        _workingStream.Seek(0, SeekOrigin.Begin);
                    if (_originalStream.CanSeek)
                        _originalStream.Seek(0, SeekOrigin.Begin);
                    Copy(_originalStream, _workingStream);
                    if (_workingStream.CanSeek)
                        _workingStream.Seek(0, SeekOrigin.Begin);
                    if (_originalStream.CanSeek)
                        _originalStream.Seek(0, SeekOrigin.Begin);
                    break;


                case SoapMessageStage.AfterDeserialize:
                    break;


                case SoapMessageStage.BeforeSerialize:


                    break;


                case SoapMessageStage.AfterSerialize:
                    // Outgoing message  
                    if (_workingStream.CanSeek)
                        _workingStream.Seek(0, SeekOrigin.Begin);
                    if (_originalStream.CanSeek)
                        _originalStream.Seek(0, SeekOrigin.Begin);
                    Copy(this._workingStream, this._originalStream);
                    if (_workingStream.CanSeek)
                        _workingStream.Seek(0, SeekOrigin.Begin);
                    if (_originalStream.CanSeek)
                        _originalStream.Seek(0, SeekOrigin.Begin);
                    break;
            }
        }



        private void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            string text = reader.ReadToEnd();
            if (text.Contains("MIME"))
            {
                text = text.Substring(text.IndexOf("<?xml"));
                text = text.Substring(0, text.IndexOf("--MIME"));
            }
            Console.WriteLine("==================================\n\n{0}\n\n==============================", text);
            writer.Write(text);
            writer.Flush();




        }
    }
}