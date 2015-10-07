using System;
using System.Runtime.Serialization;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CGImageBug
{
	[Serializable]
	public class Image: BaseImage<CGImage>
	{
		public Image ()
		{
		}

		public Image (CGImage image) : base (image)
		{
		}

		public Image (string name)
		{
			CGDataProvider dataProvider = new CGDataProvider (name);
			Value = CGImage.FromPNG (dataProvider, null, false, CGColorRenderingIntent.Default);
		}

		// this constructor is automatically called during deserialization
		public Image (SerializationInfo info, StreamingContext context)
		{
			try {
				Value = DeserializeToCGImage ((byte[])info.GetValue (BUF_PROPERTY, typeof(byte[])));
			} catch {
				Value = null;
			}
		}

		protected override int GetWidth ()
		{
			return (int)Value.Width;
		}

		protected override int GetHeight ()
		{
			return (int)Value.Height;
		}

		public override byte[] Serialize ()
		{
			if (Value == null)
				return null;
			UIImage uiImage = UIImage.FromImage (Value);
			if (uiImage == null) {
				throw new Exception ();
			}
			NSData nsData = uiImage.AsPNG ();
			if (nsData == null) {
				throw new Exception ();
			}
			return nsData.ToArray ();
		}

		public static Image Deserialize (byte[] ser)
		{
			return new Image (DeserializeToCGImage (ser));
		}

		static CGImage DeserializeToCGImage (byte[] ser)
		{
			CGDataProvider dataProvider = new CGDataProvider (ser, 0, ser.Length);
			CGImage img = CGImage.FromPNG (dataProvider, null, false, CGColorRenderingIntent.Default); 
			if (img == null) {
				throw new FormatException ();
			}
			return img;
		}

	}
}
