using System;

namespace CallQueue.Core
{
    public enum JustifyMode
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    public enum WidthSize
    {
        OneTimes = 0,
        TwoTimes = 16,
        ThreeTimes = 32,
        FourTimes = 48,
        FiveTime = 64,
        SixTimes = 80,
        SevenTimes = 96,
        EightTimes = 128,
    }

    public enum HeightSize
    {
        OneTimes = 0,
        TwoTimes = 1,
        ThreeTimes = 2,
        FourTimes = 3,
        FiveTime = 4,
        SixTimes = 5,
        SevenTimes = 6,
        EightTimes = 7,
    }

    public enum PrintMode
    {
        FontA_12x24 = 0,
        FontB_9x24 = 1,
        Bolder = 8,
        DoubleHeight = 16,
        DoubleWidth = 32,
        Underline = 128,
    }

    [Serializable]
    public class Line
    {
        public string Text { get; set; }
        public HeightSize HeightSize { get; set; }
        public WidthSize WidthSize { get; set; }
        public JustifyMode Justify { get; set; }
        public PrintMode PrintMode { get; set; }
        public Line()
        {

        }
    }
}
