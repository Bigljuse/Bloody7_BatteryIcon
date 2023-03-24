using BatteryIcon.Models;
using BatteryIcon.MouseIcon.Drawer.Enums;
using BatteryIcon.Pointers;
using System;
using System.Drawing;

namespace BatteryIcon.MouseIcon.Drawer
{
    internal class BatteryDrawer
    {
        private readonly Bitmap _bitmap;

        /// <summary>
        /// Drawing battery of specific size
        /// </summary>
        /// <param name="width">Width of a Bitmap</param>
        /// <param name="height">Height of a Bitmap</param>
        public BatteryDrawer(BatterySize batterySize)
        {
            _bitmap = CreateBitmap((byte)batterySize, (byte)batterySize);
        }

        public Bitmap GetBitmap(byte BatteryCharge, Color IconColor)
        {
            byte backGroundSize = (byte)(BatterySize.Bitmap_16x16 - 1);

            DrawRectangle(new Point(0, 0), new Point(backGroundSize, backGroundSize), Color.Transparent);
            DrawBattery(IconColor);
            DrawProgressBar(BatteryCharge, GetProgressBarColor(BatteryCharge));
            //DrawBatteryChargeNumbers(bitmap, BattaryCharge, Color.White);

            if (Mouse.Statuses.IsCharging == true)
                DrawChargingWire(new Point(0, 2), IconColor);

            return _bitmap;
        }

        private Bitmap CreateBitmap(byte width, byte height)
        {
            return new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        }

        //private void DrawBatteryChargeNumbers(byte BatteryCharge, Color color)
        //{
        //    byte[] byteArrayOfNumbers = GetNumbersOfCharge(BatteryCharge);

        //    byte offsetOfNumber = 4;

        //    if (BatteryCharge == 0)
        //        offsetOfNumber = 6;

        //    if (BatteryCharge >= 100)
        //        offsetOfNumber = 1;

        //    Point numberStartPoint = new Point(offsetOfNumber, 6);

        //    foreach (var number in byteArrayOfNumbers)
        //    {
        //        Draw3x5Number(numberStartPoint, color, (BatteryNumber)number);
        //        offsetOfNumber += 4;
        //    }
        //}

        //private byte[] GetNumbersOfCharge(byte BatteryCharge)
        //{
        //    char[] charArrayOfNumbers = BatteryCharge.ToString().ToCharArray();
        //    byte[] byteArrayOfNumbers = new byte[charArrayOfNumbers.Length];

        //    for (int counter = 0; counter < charArrayOfNumbers.Length; counter++)
        //        byteArrayOfNumbers[counter] = (byte)(charArrayOfNumbers[counter] - 48);

        //    return byteArrayOfNumbers;
        //}

        //private void Draw3x5Number(Point startPoint, Color color, BatteryNumber number)
        //{
        //    MatrixModel<byte> matrix = new MatrixModel<byte>();

        //    if (number == BatteryNumber.Zero)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 1,0,1 },
        //            { 1,0,1 },
        //            { 1,0,1 },
        //            { 1,1,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.One)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 0,0,1 },
        //            { 0,0,1 },
        //            { 0,0,1 },
        //            { 0,0,1 },
        //            { 0,0,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Two)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 1,1,1 },
        //            { 1,0,0 },
        //            { 1,1,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Three)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 1,1,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Four)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,0,1 },
        //            { 1,0,1 },
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 0,0,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Five)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 1,0,0 },
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 1,1,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Six)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 1,0,0 },
        //            { 1,1,1 },
        //            { 1,0,1 },
        //            { 1,1,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Seven)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 0,0,1 },
        //            { 0,0,1 },
        //            { 0,0,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Eight)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 1,0,1 },
        //            { 1,1,1 },
        //            { 1,0,1 },
        //            { 1,1,1 }
        //        };
        //    }

        //    if (number == BatteryNumber.Nine)
        //    {
        //        matrix.Array = new byte[5, 3]
        //        {
        //            { 1,1,1 },
        //            { 1,0,1 },
        //            { 1,1,1 },
        //            { 0,0,1 },
        //            { 1,1,1 }
        //        };
        //    }

        //    DrawPixelsByMatrix(startPoint, matrix, color);
        //}

        private void DrawBattery(Color color)
        {
            byte coefficient = (byte)(_bitmap.Width / 16);
            Point startPoint = GetButteryStartPoint();
            Point newStartPoint;
            Point endPoint = GetButteryEndPoint();
            byte length = (byte)(_bitmap.Width - 1 * coefficient);

            // Контур батарейки
            DrawRectangle(startPoint, endPoint, color, false);

            // Верхняя линия
            //DrawStraightLine(startPoint, LineDirection.Right, length, coefficient, color);

            // Нижняя линия
            //newStartPoint = new Point(startPoint.X, startPoint.Y + 8 * coefficient);
            //DrawStraightLine(newStartPoint, LineDirection.Right, length, coefficient, color);

            // Боковая левая линия
            //length = (byte)(endPoint.Y - startPoint.Y + 1);
            //DrawStraightLine(startPoint, LineDirection.Down, length, coefficient, color);

            // Боковая правая линия
            //newStartPoint = new Point(endPoint.X, startPoint.Y);
            //DrawStraightLine(newStartPoint, LineDirection.Down, length, coefficient, color);

            // Носик батарейки
            length = (byte)(3 * coefficient);
            newStartPoint = new Point(endPoint.X + 1 * coefficient, startPoint.Y + 3 * coefficient);
            DrawStraightLine(newStartPoint, LineDirection.Down, length, coefficient, color);
        }

        private Color GetProgressBarColor(byte BatteryCharge)
        {
            if (BatteryCharge >= 75)
                return Color.LimeGreen;

            if (BatteryCharge < 75 && BatteryCharge >= 50)
                return Color.Yellow;

            if (BatteryCharge < 50 && BatteryCharge >= 25)
                return Color.DarkOrange;

            if (BatteryCharge < 25 && BatteryCharge >= 0)
                return Color.IndianRed;

            return Color.White;
        }

        private void DrawProgressBar(byte BatteryCharge, Color color)
        {
            byte coefficient = (byte)(_bitmap.Width / 16);
            Point startPoint = GetButteryStartPoint();
            Point endPoint = GetButteryEndPoint();

            byte offsetX = (byte)(startPoint.X + 2 * coefficient);
            byte offsetY = (byte)(startPoint.Y + 2 * coefficient);
            Point newStartPoint = new(offsetX, offsetY);

            offsetX = (byte)(endPoint.X - 2 * coefficient + (coefficient - 1));
            offsetY = (byte)(endPoint.Y - 2 * coefficient + (coefficient - 1));
            Point newEndPoint = new(offsetX, offsetY);

            byte progressBarLength = (byte)(newEndPoint.X - newStartPoint.X + 1);
            newEndPoint.X = newStartPoint.X + (int)Math.Ceiling(progressBarLength * (double)BatteryCharge / 100) - 1;

            DrawRectangle(newStartPoint, newEndPoint, color);
        }

        private void DrawRectangle(Point startPoint, Point endPoint, Color color, bool fill = true)
        {
            Point pixelPoint;

            for (byte pixelY = (byte)startPoint.Y; pixelY <= (byte)endPoint.Y; pixelY++)
            {
                for (byte pixelX = (byte)startPoint.X; pixelX <= (byte)endPoint.X; pixelX++)
                {
                    pixelPoint = new Point(pixelX, pixelY);

                    if (IsPixelCanBeDrawen(pixelPoint) == false)
                        continue;

                    if (fill == true)
                        _bitmap.SetPixel(pixelX, pixelY, color);

                    if (fill == false)
                    {
                        if (pixelX == startPoint.X || pixelX == endPoint.X)
                            _bitmap.SetPixel(pixelX, pixelY, color);

                        if (pixelY == startPoint.Y || pixelY == endPoint.Y)
                            _bitmap.SetPixel(pixelX, pixelY, color);
                    }
                }
            }
        }

        private void DrawChargingWire(Point startPoint, Color color)
        {
            MatrixModel<byte> matrix = new();

            matrix.Array = new byte[11, 6]
            {
                { 2,1,2,1,2,2 },
                { 2,1,2,1,2,2 },
                { 1,1,1,1,1,2 },
                { 1,2,2,2,1,2 },
                { 1,2,2,2,1,2 },
                { 2,1,2,1,2,2 },
                { 2,2,1,2,2,0 },
                { 2,2,1,2,0,0 },
                { 2,2,1,2,0,0 },
                { 2,2,1,2,0,0 },
                { 2,2,1,2,0,0 }
            };

            DrawPixelsByMatrix(startPoint, matrix, color);
        }

        private void DrawStraightLine(Point startPoint, LineDirection direction, byte lenght, byte size, Color color)
        {
            Point endPoint;

            if (direction == LineDirection.Right)
            {
                int endPointX = startPoint.X + (size - 1) + lenght - 1;
                int endPointY = startPoint.Y + size - 1;

                endPoint = new Point(endPointX, endPointY);
                DrawRectangle(startPoint, endPoint, color);
                return;
            }

            if (direction == LineDirection.Down)
            {
                int endPointX = startPoint.X + size - 1;
                int endPointY = startPoint.Y + (size - 1) + lenght - 1;

                endPoint = new Point(endPointX, endPointY);
                DrawRectangle(startPoint, endPoint, color);
            }
        }

        private void DrawPixelsByMatrix(Point startPoint, MatrixModel<byte> matrix, Color color)
        {
            byte pixelX;
            byte pixelY;
            Point pixelPoint;

            for (byte y = 0; y < matrix.Height; y++)
            {
                pixelY = (byte)(startPoint.Y + y);

                for (byte x = 0; x < matrix.Width; x++)
                {
                    pixelX = (byte)(startPoint.X + x);

                    var pixelNumber = matrix.Array[y, x];
                    pixelPoint = new Point(pixelX, pixelY);

                    if (IsPixelCanBeDrawen(pixelPoint) == false)
                        continue;

                    if (pixelNumber == 0)
                        continue;

                    if (pixelNumber == 2)
                        _bitmap.SetPixel(pixelX, pixelY, Color.Transparent);
                    else
                        _bitmap.SetPixel(pixelX, pixelY, color);
                }
            }
        }

        private bool IsPixelCanBeDrawen(Point pixelPoint)
        {
            if (pixelPoint.X >= _bitmap.Width)
                return false;

            if (pixelPoint.Y >= _bitmap.Height)
                return false;

            return true;
        }

        private Point GetButteryStartPoint()
        {
            byte pixelX = 0;
            byte pixelY = (byte)(_bitmap.Height / 4);

            return new Point(pixelX, pixelY);
        }

        private Point GetButteryEndPoint()
        {
            byte coefficient = (byte)(_bitmap.Width / 16);

            byte pixelX = (byte)(_bitmap.Width - 2 * coefficient);
            byte pixelY = (byte)(_bitmap.Height - 4 * coefficient);

            return new Point(pixelX, pixelY);
        }
    }
}
