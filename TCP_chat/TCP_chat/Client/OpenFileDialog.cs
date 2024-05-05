using System;
namespace TCP_chat
{
	public class OpenFileDialog
	{
		public OpenFileDialog()
		{
		}

        public string InitialDirectory { get; internal set; }
        public string Filter { get; internal set; }
        public int FilterIndex { get; internal set; }
        public bool RestoreDirectory { get; internal set; }
        public string? FileName { get; internal set; }

        internal bool ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}

