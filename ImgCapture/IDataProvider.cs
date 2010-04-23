using System;
namespace ImgCapture
{
    public interface IDataProvider
    {
        byte[] Data { get; set; }
        event EventHandler DataChanged;
    }
}
