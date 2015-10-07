using System;
using System.IO;
using System.Runtime.Serialization;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;

namespace CGImageBug
{
	[Serializable]
	public class Image: BaseImage<Bitmap>
	{
		public Image (Bitmap image) : base (image)
		{
		}

		public Image (string name)
		{
			var bitmap = Xamarin.Forms.Forms.Context.Resources.GetBitmap (name);
			if (bitmap == null) {
				throw new IOException ("Error reading resource " + name);
			}
			Value = bitmap;
		}

		// this constructor is automatically called during deserialization
		public Image (SerializationInfo info, StreamingContext context)
		{
			try {
				Value = Deserialize ((byte[])info.GetValue (BUF_PROPERTY, typeof(byte[]))).Value;
			} catch {
				Value = null;
			}
		}

		protected override int GetWidth ()
		{
			return Value.Width;
		}

		protected override int GetHeight ()
		{
			return Value.Height;
		}

		public override byte[] Serialize ()
		{
			if (Value == null)
				return null;
			using (MemoryStream stream = new MemoryStream ()) {
				Value.Compress (Bitmap.CompressFormat.Png, 100, stream);
				return stream.ToArray ();
			}
		}

		public static Image Deserialize (byte[] ser)
		{
			return new Image (BitmapFactory.DecodeByteArray (ser, 0, ser.Length));
		}
	}
}

