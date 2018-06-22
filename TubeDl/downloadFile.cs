namespace DownloadHelper
{
    public class downloadFile
    {
        #region Variables
        /// <summary>
        /// Represent url of the file on the internet.
        /// </summary>
        System.Uri uri;
        /// <summary>
        /// Make request to the uri.
        /// </summary>
        System.Net.HttpWebRequest req;
        /// <summary>
        /// Get response from 'req'.
        /// </summary>
        System.Net.HttpWebResponse res;
        /// <summary>
        /// Read bytes from 'res'.
        /// </summary>
        System.IO.Stream stream;
        /// <summary>
        /// Write bytes from 'stream' to the file on harddisk.
        /// </summary>
        System.IO.FileStream fStream;
        /// <summary>
        /// Represent the start time of download.
        /// </summary>
        System.DateTime dt;

        /// <summary>
        /// Array of bytes to store downloaded bytes from 'stream'.
        /// </summary>
        byte[] buffer = new byte[1024];
        /// <summary>
        /// Store the total numbers of bytes from the 'buffer'.
        /// </summary>
        int bufferReader = 0;

        /// <summary>
        /// Represent the total length of the requested file.
        /// </summary>
        long fLength = 0;
        /// <summary>
        /// Represent the downloaded length of the requested file.
        /// </summary>
        long dLength = 0;
        /// <summary>
        /// Represent the downloaded length of the requested file, from the point of started.
        /// </summary>
        long cLength = 0;
        /// <summary>
        /// Represent the download speed.
        /// </summary>
        double dSpeed = 0;

        /// <summary>
        /// Use to check if the class is currently downloading the file.
        /// </summary>
        bool isDownloading = false;
        /// <summary>
        /// Use to stop the downloading.
        /// </summary>
        bool cancelDownload = false;
        /// <summary>
        /// Use to startfresh and overwrite a file on harddisk if exists ( ignore resuming ).
        /// </summary>
        bool overwrite = false;

        /// <summary>
        /// A timer use to update downloading-speed every x millisecond.
        /// </summary>
        System.Timers.Timer dsTimer = new System.Timers.Timer(1000);
        /// <summary>
        /// A timer use to update downloaded-length every x millisecond.
        /// </summary>
        System.Timers.Timer dlTimer = new System.Timers.Timer(1000);

        string filePath;
        #endregion

        #region Properties
        /// <summary>
        /// Total length of the file.
        /// </summary>
        public long FileSize
        {
            get { return fLength; }
        }

        /// <summary>
        /// Downloaded-length of the file.
        /// </summary>
        public long DownloadedLength
        {
            get { return dLength; }
        }

        /// <summary>
        /// Current downloading-speed.
        /// </summary>
        public string DownloadingSpeed
        {
            // {x:n1} Mean Math.round(x,2)
            get { return View.Size.getlength.InternetSpeed(dSpeed); }
        }

        /// <summary>
        /// Get or set the interval of downloading-speed value.
        /// </summary>
        public double DSpeedUI
        {
            get { return dsTimer.Interval; }
            set { dsTimer.Interval = value; }
        }

        /// <summary>
        /// Get or set the interval of downloaded-length value.
        /// </summary>
        public double DLengthUI
        {
            get { return dlTimer.Interval; }
            set { dlTimer.Interval = value; }
        }

        /// <summary>
        /// Get or set the size of buffer.
        /// </summary>
        public int BufferSize
        {
            get
            {
                return BufferSize;
            }
            set
            {
                // buffer cannot change during downloading.
                if (!isDownloading && value > 32 && value < int.MaxValue)
                {
                    buffer = new byte[value];
                    BufferSize = value;
                }
            }
        }

        /// <summary>
        /// Get the state of current donwload-state.
        /// </summary>
        public string DownloadState
        {
            get
            {
                if (isDownloading)
                    return "Downloading";
                else if (dLength < fLength)
                    return "Paused";
                else
                    return "Completed";
            }
        }
        #endregion

        #region EventHandler
        // please remove spaces between "<> and long" ..... "string and <>".
        /// <summary>
        /// Obtain when total-length of the file changed.
        /// </summary>
        public System.EventHandler<string> eSize;
        /// <summary>
        /// Obtain when downloaded-length changed.
        /// </summary>
        public System.EventHandler<string> eDownloadedSize;
        /// <summary>
        /// Obtain when downloading-speed changed.
        /// </summary>
        public System.EventHandler<string> eSpeed;
        /// <summary>
        /// Obtain when download-state changed.
        /// </summary>
        public System.EventHandler<string> eDownloadState;
        #endregion

        #region Methods
        /// <summary>
        /// Main download method.
        /// </summary>
        private async void download()
        {
            dlTimer.Start();
            dsTimer.Start();
            // Set 'cancelDownload' to false, so that method can stop again.
            cancelDownload = false;
          
            req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            // check if downloaded-length!=0 and !overwrite so the user want to resume.
            if (dLength > 0 && !overwrite)
                req.AddRange(dLength);      // add range to the 'req' to change the point of start download.
            isDownloading = true;
            using (res = (System.Net.HttpWebResponse)await req.GetResponseAsync())
            {
                fLength = res.ContentLength + dLength; // get the total-size of the file.
                eSize.Invoke(null, View.Size.getlength.GetLengthString(FileSize));       // update the total-size.
                eDownloadedSize.Invoke(null, View.Size.getlength.GetLengthString(DownloadedLength)); // update the downloaded-length.
                dt = System.DateTime.Now;       // get the current time ( point of start downloading ).
                using (stream = res.GetResponseStream())
                {
                    await System.Threading.Tasks.Task.Run(() =>     // await task so the winform don't freezing.
                    {
                        // update the download-state.
                        eDownloadState.Invoke(null, "Downloading");
                        // while not 'cancelDownload' and file doesn't end do:
                        while (!cancelDownload && ((bufferReader = stream.Read(buffer, 0, buffer.Length)) > 0))
                        {
                            fStream.Write(buffer, 0, bufferReader); // write byte to the file on harddisk.
                            dLength += bufferReader;    // update downloaded-length value.
                            cLength += bufferReader;    // update current-downloaded-length value.
                        }
                    });
                }
            }
            dlTimer.Stop();
            dsTimer.Stop();
            isDownloading = false;
           // eSpeed.Invoke(null, "0.0 Kb/s");    // update downloading-speed to 0.0 kb/s.
            eDownloadedSize.Invoke(null,View.Size.getlength.GetLengthString( DownloadedLength)); // update downloaded-size.
            eDownloadState.Invoke(null, DownloadState);     // update download-state.
            fStream.Dispose();      // free file on harddisk by dispose 'fStream'.
        }

        /// <summary>
        /// Method use to update downloaded-length.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DlTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Call the event-handler.
            eDownloadedSize.Invoke(null, View.Size.getlength.GetLengthString(DownloadedLength));
        }

        /// <summary>
        /// Method use to update download-speed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DsTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Download Speed In Kb/s = ( Downloaded-Length In KB ) / ( Total Seconds From Point Of Start ).
            dSpeed = (cLength) / ((System.DateTime.Now - dt).TotalSeconds);
            eSpeed.Invoke(null, DownloadingSpeed); // Call the event-handler.
        }

        /// <summary>
        /// Method use to cancel download if currently downloading.
        /// </summary>
        public void CancelDownload()
        {
            cancelDownload = true;
        }

        /// <summary>
        /// Method use to resume download.
        /// </summary>
        public void ResumeDownload()
        {
            if (DownloadState == "Paused")
            {
                if (System.IO.File.Exists(filePath) && !overwrite)
                {
                    fStream = new System.IO.FileStream(filePath, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                    if (dLength == fStream.Length)
                    {
                        download();
                        return;
                    }
                }
            }
            throw new System.ArgumentException("Cannot Resume Download");
        }

        /// <summary>
        /// Constructor, called when new object build.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        public downloadFile(string url, string filePath, bool overwrite = false)
        {
            // Convert string to uri using Uri.TryCreate.
            bool validUri = System.Uri.TryCreate(url, System.UriKind.Absolute, out uri);

            if (!validUri)      // Check if not valid uri then throw new error.
                throw new System.ArgumentException("Invalid url");
            this.filePath = filePath;

            // Check if file exists and not overwrite (overwrite used to start download from 0 and overwrite the file if exists).
            if (System.IO.File.Exists(filePath) && !overwrite)
                ResumeDownload();
            else
            {
                fStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                dLength = fStream.Length;   // if file not exists fStream.Length will return 0.
                this.overwrite = overwrite; // set the argument value into boolean value.

                dlTimer.Elapsed += DlTimer_Elapsed;     // assign method to dlTimer.
                dsTimer.Elapsed += DsTimer_Elapsed;     // assign method to dsTimer.

                download();     // call download method.
            }
        }

        /// <summary>
        /// Method like destructor to dispose the class.
        /// </summary>
        public void Dispose()
        {
            dlTimer.Stop();
            dsTimer.Stop();
            if (fStream != null) fStream.Dispose();
            if (res != null) res.Dispose();
            if (stream != null) stream.Dispose();
            System.GC.SuppressFinalize(this);
        }
        #endregion

    }
}
