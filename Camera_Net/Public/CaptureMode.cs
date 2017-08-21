#region License

/*
Camera_NET - Camera wrapper for directshow for .NET
Copyright (C) 2013
https://github.com/free5lot/Camera_Net

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 3.0 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU LesserGeneral Public 
License along with this library. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

namespace Camera_NET
{
    using DirectShowLib;
    #region Using directives
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Resolution class for <see cref="Camera"/>.
    /// </summary>
    /// 
    /// <author> free5lot (free5lot@yandex.ru) </author>
    /// <version> 2013.10.16 </version>
    public class CaptureMode : IEquatable<CaptureMode>
    {
        /// <summary>
        /// Width of frame of video output.
        /// </summary>
        public int Width { set; get; }

        /// <summary>
        /// Height of frame of video output.
        /// </summary>
        public int Height { set; get; }

        /// <summary>
        /// Framerate of the video output.
        /// </summary>
        public float Framerate { set; get; }

        /// <summary>
        /// Media sub type of the video output.
        /// </summary>
        public Guid MediaSubType { set; get; }

        /// <summary>
        /// Constructor for <see cref="CaptureMode"/> class.
        /// </summary>
        /// <param name="width">Width of frame of video output.</param>
        /// <param name="height">Height of frame of video output.</param>
        /// <param name="framerate">Framerate of the video output.</param>
        /// <param name="mediaSubType">Media sub type of the video output</param>
        public CaptureMode(int width, int height, float framerate, Guid mediaSubType)
        {
            Width = width;
            Height = height;
            Framerate = framerate;
            MediaSubType = mediaSubType;
        }
        
        /// <summary>
        /// To String conversion
        /// </summary>
        /// <returns>String the object was converted to</returns>
        public override string ToString()
        {
            // String representation.
            var encodingName = "Unknown";

            if (DirectShowLib.MediaSubType.EncodingToName.ContainsKey(MediaSubType))
            {
                encodingName = DirectShowLib.MediaSubType.EncodingToName[MediaSubType];
            }

            return Width.ToString() + "x" + Height.ToString() + " @" + Framerate.ToString("0") + " fps, in " + encodingName;
        }

        /// <summary>
        /// Makes a clone of Capture Mode.
        /// </summary>
        /// <remarks>Clone is not connected with original object via refs.</remarks>
        /// <returns>Clone of object</returns>
        public CaptureMode Clone()
        {
            CaptureMode copy = new CaptureMode(Width, Height, Framerate, MediaSubType);
            return copy;
        }

        public bool Equals(CaptureMode other)
        {
            if (other == null)
                return false;

            if (this.Height != other.Height ||
                this.Width  != other.Width)
                return false;

            if (this.Framerate != other.Framerate)
            {
                return false;
            }

            if (this.MediaSubType != other.MediaSubType)
            {
                return false;
            }

            return true;
        }
    }


}
