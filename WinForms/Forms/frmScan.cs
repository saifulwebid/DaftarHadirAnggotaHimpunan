using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WinForms.Forms
{
    public partial class frmScan : Form
    {
        class CameraDevices
        {
            public FilterInfoCollection Devices { get; private set; }
            public VideoCaptureDevice Current { get; private set; }

            public CameraDevices()
            {
                Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            }

            public void SelectCamera(int index)
            {
                if (index >= Devices.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                Current = new VideoCaptureDevice(Devices[index].MonikerString);
            }
        }
        
        private readonly CameraDevices camDevices;
        private Bitmap currentBitmapForDecoding;
        private readonly Thread decodingThread;
        private Result currentResult;
        private readonly Pen resultRectPen;
        private string qrData;

        public string GetData
        {
            get { return qrData; }
        }

        public frmScan()
        {
            InitializeComponent();
            camDevices = new CameraDevices();

            decodingThread = new Thread(DecodeBarcode);
            decodingThread.Start();

            pictureBox1.Paint += pictureBox1_Paint;
            resultRectPen = new Pen(Color.Green, 10);
        }

        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentResult == null)
                return;

            if (currentResult.ResultPoints != null && currentResult.ResultPoints.Length > 0)
            {
                var resultPoints = currentResult.ResultPoints;
                var rect = new Rectangle((int)resultPoints[0].X, (int)resultPoints[0].Y, 1, 1);
                foreach (var point in resultPoints)
                {
                    if (point.X < rect.Left)
                        rect = new Rectangle((int)point.X, rect.Y, rect.Width + rect.X - (int)point.X, rect.Height);
                    if (point.X > rect.Right)
                        rect = new Rectangle(rect.X, rect.Y, rect.Width + (int)point.X - rect.X, rect.Height);
                    if (point.Y < rect.Top)
                        rect = new Rectangle(rect.X, (int)point.Y, rect.Width, rect.Height + rect.Y - (int)point.Y);
                    if (point.Y > rect.Bottom)
                        rect = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + (int)point.Y - rect.Y);
                }
                using (var g = pictureBox1.CreateGraphics())
                {
                    g.DrawRectangle(resultRectPen, rect);
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetWebcam();
        }

        void SetWebcam()
        {
            int i = 0;
            bool found = false;
            string source;
            
            /* Mencari hardware webcam yang menggunakan port usb */
            while (i < camDevices.Devices.Count && !found)
            {
                camDevices.SelectCamera(i);
                source = camDevices.Current.Source.ToString();
                found = source.Substring(0, source.Length).Contains("usb");
                if (found) { found = true; }
                else { i++; }
            }

            if (i >= camDevices.Devices.Count)
            {
                MessageBox.Show("Webcam Tidak Ditemukan !");
                this.Close();
            }

            else
            {
                camDevices.SelectCamera(i);
                camDevices.Current.NewFrame += Current_NewFrame;
                camDevices.Current.Start();
            }

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!e.Cancel)
            {
                decodingThread.Abort();
                if (camDevices.Current != null)
                {
                    camDevices.Current.NewFrame -= Current_NewFrame;
                    if (camDevices.Current.IsRunning)
                    {
                        camDevices.Current.SignalToStop();
                    }
                }
            }
        }

        private void Current_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (IsDisposed)
            {
                return;
            }

            try
            {
                if (currentBitmapForDecoding == null)
                {
                    currentBitmapForDecoding = (Bitmap)eventArgs.Frame.Clone();
                }
                Invoke(new Action<Bitmap>(ShowFrame), eventArgs.Frame.Clone());
            }
            catch (ObjectDisposedException)
            {
                // not sure, why....
            }
        }

        private void ShowFrame(Bitmap frame)
        {
            pictureBox1.Image = frame;
        }

        private void DecodeBarcode()
        {
            var reader = new BarcodeReader();
            while (true)
            {
                if (currentBitmapForDecoding != null)
                {
                    var result = reader.Decode(currentBitmapForDecoding);
                    if (result != null)
                    {
                        Invoke(new Action<Result>(ShowResult), result);
                    }
                    currentBitmapForDecoding.Dispose();
                    currentBitmapForDecoding = null;
                }
                Thread.Sleep(200);
            }
        }

        private void ShowResult(Result result)
        {
            qrData = result.Text;
            camDevices.Current.SignalToStop();
            this.Close();
        }
    }
}
