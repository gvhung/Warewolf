using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using Dev2.Common;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace Dev2.Activities.DropBox2016.UploadActivity
{
    public interface IDropBoxUpload : IDropboxSingleExecutor<IDropboxResult>
    {
    }

    public class DropBoxUpload : IDropBoxUpload
    {
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private WriteMode _writeMode;
        private readonly string _dropboxPath;
        private readonly string _fromPath;

        public DropBoxUpload(WriteMode writeMode, string dropboxPath, string fromPath)
        {
            if (string.IsNullOrEmpty(fromPath) || string.IsNullOrEmpty(dropboxPath))
                throw new ArgumentException("The file paths should all be specified");
            _writeMode = writeMode;
            _dropboxPath = dropboxPath;
            _fromPath = fromPath;
            Validate();
            InitializeCertPinning();
        }

        public bool IsValid { get; set; }

        #region Implementation of IDropboxSingleExecutor
        [ExcludeFromCodeCoverage]
        public IDropboxResult ExecuteTask(DropboxClient client)
        {
            try
            {
                using (var stream = new MemoryStream(File.ReadAllBytes(_fromPath)))
                {
                    FileMetadata uploadAsync = client.Files.UploadAsync("/" + _dropboxPath, _writeMode, true, null, false, stream).Result;
                    return new DropboxSuccessResult(uploadAsync);
                }
            }
            catch (Exception exception)
            {
                Dev2Logger.Error(exception.Message);
                return exception.InnerException != null ? new DropboxFailureResult(exception.InnerException) : new DropboxFailureResult(exception);
            }
        }

        #endregion

        public void Validate()
        {
            if (_writeMode != null && !string.IsNullOrEmpty(_dropboxPath) && !string.IsNullOrEmpty(_fromPath))
                IsValid = true;
        }
        [ExcludeFromCodeCoverage]
        private void InitializeCertPinning()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                var root = chain.ChainElements[chain.ChainElements.Count - 1];
                var publicKey = root.Certificate.GetPublicKeyString();

                return DropboxCertHelper.IsKnownRootCertPublicKey(publicKey);
            };
        }
    }
}