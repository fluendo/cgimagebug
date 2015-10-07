using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CGImageBug
{
	public static class Extensions
	{
		public static T Clone<T> (this T source)
		{
			if (Object.ReferenceEquals (source, null))
				return default(T);

			Stream s = new MemoryStream ();
			using (s) {
				BinaryFormatter formatter = new  BinaryFormatter ();
				formatter.Serialize (s, source);
				s.Seek (0, SeekOrigin.Begin);
				return (T)formatter.Deserialize (s);
			}
		}
	}
}

