using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;

namespace CallQueue.Controls
{
    /// <summary>
    /// Component dùng để phát nhạc dựa vào nội dung truyền vào
    /// </summary>
    public partial class CallVoice : Component
    {
        #region Public members

        /// <summary>
        /// Nội dung phát nhạc
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Đang phát nhạc
        /// </summary>
        [Browsable(false)]
        public bool IsPlaying { get; set; }

        /// <summary>
        /// Cho phép chơi nhạc bắt đầu
        /// </summary>
        public bool AllowPlayStartSound { get; set; }

        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Danh sách tên nhạc trong component
        /// </summary>
        [Browsable(false)]
        public List<string> VoiceNames { get { return streamDictionary?.Keys.ToList(); } }

        /// <summary>
        /// Event khi bắt đầu chơi nhạc
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        /// Event khi hoàn tất chơi nhạc
        /// </summary>
        public event EventHandler Finished;

        #endregion

        #region Private members

        /// <summary>
        /// Biến lưu trạng thái cho phép chơi nhạc trước đó
        /// </summary>
        private bool lastAllowPlayStartSound;

        /// <summary>
        /// Biến lưu nội dung phát trước đó
        /// </summary>
        private string lastPlayedContent;

        /// <summary>
        /// Biến lưu danh sách các stream phát trước đó
        /// </summary>
        private List<Stream> lastPlayedStreams;

        /// <summary>
        /// Biến để lưu trữ các stream theo tên resource
        /// </summary>
        private Dictionary<string, Stream> streamDictionary;

        private Assembly assembly;

        /// <summary>
        /// Trình chơi nhạc
        /// </summary>
        private SoundPlayer player;

        ConcurrentQueue<string> PlayContentQueue = new ConcurrentQueue<string>();

        private object locker = new object();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CallVoice()
        {
            InitializeComponent();

            if (!DesignMode)
                InitializeSoundStream();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CallVoice(IContainer container)
        {
            InitializeComponent();

            if (!DesignMode)
                InitializeSoundStream();

            container.Add(this);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Hàm chơi nhạc 
        /// </summary>
        public void Play(Action callback = null)
        {
            if (!Enabled)
                return;

            try
            {
                lock (locker)
                {

                    IsPlaying = true;
                    Started?.Invoke(this, EventArgs.Empty);

                    if (!string.IsNullOrWhiteSpace(Content))
                    {
                        // Kiểm tra nội dung cần phát có khác với nội dung phát trước đó hay không
                        // Nếu khác thì mới tạo danh sách cách stream cần phát
                        // Mục đích để tránh phải lăp lại khởi tạo các stream cần phát 
                        if (Content != lastPlayedContent)
                        {
                            lastPlayedContent = Content;
                            lastPlayedStreams.Clear();
                            // Thực hiện viết hoa nội dung để đồng bộ với tên các file nhạc
                            string upperContent = Content.ToUpper();
                            // Thực hiện lấy các stream dựa vào nội dung và lưu lại để sử dụng
                            GetSoundStream(ref upperContent, ref lastPlayedStreams);

                            // Kiểm tra xem có cần chơi nhạc bắt đầu hay không
                            if (AllowPlayStartSound)
                            {
                                lastPlayedStreams.Insert(0, streamDictionary["NHẠC ĐỆM"]);
                                lastAllowPlayStartSound = true;
                            }
                        }

                        // Kiểm tra xem có cần chơi nhạc bắt đầu hay không
                        if (AllowPlayStartSound)
                        {
                            if (lastAllowPlayStartSound == false)
                                lastPlayedStreams.Insert(0, streamDictionary["NHẠC ĐỆM"]);
                        }
                        else
                        {
                            if (lastAllowPlayStartSound == true)
                                lastPlayedStreams.RemoveAt(0);
                        }

                        lastAllowPlayStartSound = AllowPlayStartSound;

                        // Chơi nhạc trong danh sách stream đã lưu
                        foreach (var stream in lastPlayedStreams)
                        {
                            stream.Position = 0;
                            player.Stream = stream;
                            player.PlaySync();
                        }
                        callback?.Invoke();
                        Finished?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CallVoice error: {ex.Message}");
            }
            finally { IsPlaying = false; }
        }

        /// <summary>
        /// Hàm chơi nhạc 
        /// </summary>
        public void Play(string content, Action callback = null)
        {
            if (!Enabled)
                return;

            try
            {
                lock (locker)
                {

                    IsPlaying = true;
                    Started?.Invoke(this, EventArgs.Empty);

                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        // Kiểm tra nội dung cần phát có khác với nội dung phát trước đó hay không
                        // Nếu khác thì mới tạo danh sách cách stream cần phát
                        // Mục đích để tránh phải lăp lại khởi tạo các stream cần phát 
                        if (content != lastPlayedContent)
                        {
                            lastPlayedContent = Content;
                            lastPlayedStreams.Clear();
                            // Thực hiện viết hoa nội dung để đồng bộ với tên các file nhạc
                            string upperContent = content.ToUpper();
                            // Thực hiện lấy các stream dựa vào nội dung và lưu lại để sử dụng
                            GetSoundStream(ref upperContent, ref lastPlayedStreams);

                            // Kiểm tra xem có cần chơi nhạc bắt đầu hay không
                            if (AllowPlayStartSound)
                            {
                                lastPlayedStreams.Insert(0, streamDictionary["NHẠC ĐỆM"]);
                                lastAllowPlayStartSound = true;
                            }
                        }

                        // Kiểm tra xem có cần chơi nhạc bắt đầu hay không
                        if (AllowPlayStartSound)
                        {
                            if (lastAllowPlayStartSound == false)
                                lastPlayedStreams.Insert(0, streamDictionary["NHẠC ĐỆM"]);
                        }
                        else
                        {
                            if (lastAllowPlayStartSound == true)
                                lastPlayedStreams.RemoveAt(0);
                        }

                        lastAllowPlayStartSound = AllowPlayStartSound;

                        // Chơi nhạc trong danh sách stream đã lưu
                        foreach (var stream in lastPlayedStreams)
                        {
                            stream.Position = 0;
                            player.Stream = stream;
                            player.PlaySync();
                        }
                        callback?.Invoke();
                        Finished?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CallVoice error: {ex.Message}");
            }
            finally { IsPlaying = false; }
        }

        /// <summary>
        /// Hàm chơi nhạc 
        /// </summary>
        public void PlayInQueue(Action callback = null)
        {
            if (!Enabled)
                return;

            try
            {
                lock (locker)
                {
                    if (PlayContentQueue.TryDequeue(out string content))
                    {

                        IsPlaying = true;
                        Started?.Invoke(this, EventArgs.Empty);

                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            // Kiểm tra nội dung cần phát có khác với nội dung phát trước đó hay không
                            // Nếu khác thì mới tạo danh sách cách stream cần phát
                            // Mục đích để tránh phải lăp lại khởi tạo các stream cần phát 
                            if (content != lastPlayedContent)
                            {
                                lastPlayedContent = Content;
                                lastPlayedStreams.Clear();
                                // Thực hiện viết hoa nội dung để đồng bộ với tên các file nhạc
                                string upperContent = content.ToUpper();
                                // Thực hiện lấy các stream dựa vào nội dung và lưu lại để sử dụng
                                GetSoundStream(ref upperContent, ref lastPlayedStreams);

                                // Kiểm tra xem có cần chơi nhạc bắt đầu hay không
                                if (AllowPlayStartSound)
                                {
                                    lastPlayedStreams.Insert(0, streamDictionary["NHẠC ĐỆM"]);
                                    lastAllowPlayStartSound = true;
                                }
                            }

                            // Kiểm tra xem có cần chơi nhạc bắt đầu hay không
                            if (AllowPlayStartSound)
                            {
                                if (lastAllowPlayStartSound == false)
                                    lastPlayedStreams.Insert(0, streamDictionary["NHẠC ĐỆM"]);
                            }
                            else
                            {
                                if (lastAllowPlayStartSound == true)
                                    lastPlayedStreams.RemoveAt(0);
                            }

                            lastAllowPlayStartSound = AllowPlayStartSound;

                            // Chơi nhạc trong danh sách stream đã lưu
                            foreach (var stream in lastPlayedStreams)
                            {
                                stream.Position = 0;
                                player.Stream = stream;
                                player.PlaySync();
                            }
                            callback?.Invoke();
                            Finished?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CallVoice error: {ex.Message}");
            }
            finally { IsPlaying = false; }
        }

        /// <summary>
        /// Hàm chơi nhạc async
        /// </summary>
        public async void PlayAsync(Action callback = null)
        {
            await Task.Factory.StartNew(() => Play(callback));
        }

        /// <summary>
        /// Hàm chơi nhạc async
        /// </summary>
        public async void PlayAsync(string content, Action callback = null)
        {
            PlayContentQueue.Enqueue(content);
            await Task.Factory.StartNew(() => PlayInQueue(callback));
        }

        /// <summary>
        /// Hàm dừng phát nhạc
        /// </summary>
        public void Stop()
        {
            try
            {
                player.Stop();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"CallVoice error: {ex.Message}");
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Hàm khởi tạo các thông số cần thiết
        /// </summary>
        private void InitializeSoundStream()
        {
            // Khởi tạo dictionary để lưu các stream nhạc
            if (streamDictionary == null)
            {
                streamDictionary = new Dictionary<string, Stream>();
                assembly = Assembly.GetExecutingAssembly();
                // Lấy tất cả các resouce file name và sắp sếp giảm dần theo độ dài cửa chuỗi
                var resouceNames = assembly.GetManifestResourceNames().OrderByDescending(x => x.Length);
                foreach (var resourceName in resouceNames)
                {
                    // Đảm bảo resouce là file .wav
                    if (resourceName.EndsWith(".wav"))
                    {
                        // Tách chuổi ra để lấy tên của file nhạc
                        string[] splitResourceName = resourceName.Split('.');
                        streamDictionary[splitResourceName[splitResourceName.Length - 2]] = assembly.GetManifestResourceStream(resourceName);
                    }
                }
            }

            lastPlayedStreams = new List<Stream>();
            player = new SoundPlayer();
        }

        /// <summary>
        /// Hàm để lấy các stream nhạc dựa vào nội dung đầu vào
        /// </summary>
        /// <param name="content">Nội dung cần phát</param>
        /// <param name="soundStreams">Danh sách để lưu trữ các stream</param>
        private void GetSoundStream(ref string content, ref List<Stream> soundStreams)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                content = content.Trim();
                foreach (var kvp in streamDictionary)
                {
                    if (content.StartsWith(kvp.Key))
                    {
                        content = content.Remove(0, kvp.Key.Length);
                        soundStreams.Add(kvp.Value);

                        // Thực hiện để qui đến khi nào nội dung của content đã hết hoặc ko tìm thấy trong dictionary
                        GetSoundStream(ref content, ref soundStreams);
                    }
                }
            }
        }

        #endregion
    }
}
