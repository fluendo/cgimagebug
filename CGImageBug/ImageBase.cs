//
//  Copyright (C) 2015 fluendo
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
using System.Runtime.Serialization;

namespace CGImageBug
{
	[Serializable]
	public abstract class BaseImage<T>: ISerializable, IDisposable where T: IDisposable
	{

		protected const string BUF_PROPERTY = "pngbuf";

		public BaseImage ()
		{
		}

		public BaseImage (T image)
		{
			Value = image;
		}

		public T Value {
			get;
			protected set;
		}

		public int Width {
			get {
				return GetWidth ();
			}
		}

		public int Height {
			get {
				return GetHeight ();
			}
		}

		public void Dispose ()
		{
			Value.Dispose ();
		}

		// this method is automatically called during serialization
		public void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			try {
				info.AddValue (BUF_PROPERTY, Serialize ());
			} catch {
				info.AddValue (BUF_PROPERTY, null);
			}
		}

		public abstract byte[] Serialize ();

		protected abstract int GetWidth ();

		protected abstract int GetHeight ();
	}
}
