

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 読み込みストリーム。
*/


#define USESTREAM


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** ReadStream
	*/
	public class ReadStream : System.IO.Stream
	{
		/** data
		*/
		private byte[] data;

		/** position
		*/
		private long position;

		/** constructor
		*/
		public ReadStream(byte[] a_data)
		{
			//data
			this.data = a_data;

			//position
			this.position = 0;
		}

		/** CanRead
		*/
		public override bool CanRead{get{
			return true;
		}}

		/** CanSeek
		*/
		public override bool CanSeek{get{
			return true;
		}}

		/** CanWrite
		*/
		public override bool CanWrite{get{
				return false;
		}}

		/** Length
		*/
		public override long Length{get{
			return this.data.Length;
		}}

		/** Position
		*/
		public override long Position{get{
			return this.position;
		}set{
			this.position = value;
		}}

		/** Flush
		*/
		public override void Flush()
		{
		}

		/** Read
		*/
		public override int Read(byte[] a_buffer,int a_offset,int a_count)
		{
			int t_size;
			if(this.data != null){
				t_size = System.Math.Min(a_count,this.data.Length - a_offset);
				if(t_size < 0){
					t_size = 0;

					#if(DEF_BLUEBACK_EXCEL_ASSERT)
					DebugTool.Assert(false);
					#endif
				}
			}else{
				t_size = 0;

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false);
				#endif
			}

			if(t_size > 0){
				System.Array.Copy(this.data,this.position,a_buffer,a_offset,t_size);
				this.position += t_size;
			}

			return t_size;
		}

		/** Seek
		*/
		public override long Seek(long a_offset,System.IO.SeekOrigin a_origin)
		{
			switch(a_origin){
			case System.IO.SeekOrigin.Begin:
				{
					this.position = a_offset;
				}break;
			case System.IO.SeekOrigin.Current:
				{
					this.position += a_offset;
				}break;
			case System.IO.SeekOrigin.End:
				{
					if(this.data != null){
						this.position = this.data.Length + a_offset;
					}else{
						this.position = a_offset;

						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false);
						#endif
					}
				}break;
			}

			return this.position;
		}

		/** SetLength
		*/
		public override void SetLength(long a_value)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false,"SetLength");
			#endif
		}

		/** Write
		*/
		public override void Write(byte[] a_buffer,int a_offset,int a_count)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false,"Write");
			#endif
		}

		/** Dispose
		*/
		protected override void Dispose(bool disposing)
		{
			this.data = null;
			base.Dispose(disposing);
		}
	}
}

