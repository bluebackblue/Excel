

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief 読み込みストリーム。
*/


/** BlueBack.Excel
*/
namespace BlueBack.Excel
{
	/** ReadStream
	*/
	public sealed class ReadStream : System.IO.Stream
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

		/** Position
		*/
		public override long Position{get{
			return this.position;
		}set{
			this.position = value;
		}}

		/** Length
		*/
		public override long Length{get{
			return this.data.Length;
		}}

		/** CanWrite
		*/
		public override bool CanWrite{get{
				return false;
		}}

		/** CanTimeout
		*/
		/*
		public override bool CanTimeout{get{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return false;
		}}
		*/

		/** CanSeek
		*/
		public override bool CanSeek{get{
			return true;
		}}

		/** CanRead
		*/
		public override bool CanRead{get{
			return true;
		}}

		/** ReadTimeout
		*/
		/*
		public override int ReadTimeout{get{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return 0;
		}set{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
		}}
		*/

		/** WriteTimeout
		*/
		/*
		public override int WriteTimeout{get{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return 0;
		}set{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
		}}
		*/

		/** BeginRead
		*/
		/*
		public override System.IAsyncResult BeginRead(byte[] a_buffer,int a_offset,int a_count,System.AsyncCallback a_callback,object a_state)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return null;
		}
		*/

		/** BeginWrite
		*/
		/*
		public override System.IAsyncResult BeginWrite(byte[] a_buffer,int a_offset,int a_count,System.AsyncCallback a_callback,object a_state)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return null;
		}
		*/

		/** Close
		*/
		/*
		public override void Close()
		{
		}
		*/

		/** CopyToAsync
		*/
		/*
		public override System.Threading.Tasks.Task CopyToAsync(System.IO.Stream a_destination,int a_buffer_size,System.Threading.CancellationToken a_cancellation_token)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return null;
		}
		*/

		/** EndRead
		*/
		/*
		public override int EndRead(System.IAsyncResult a_async_result)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return 0;
		}
		*/

		/** EndWrite
		*/
		/*
		public override void EndWrite(System.IAsyncResult a_async_result)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
		}
		*/

		/** Flush
		*/
		public override void Flush()
		{
		}

		/** FlushAsync
		*/
		/*
		public override System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken a_cancellation_token)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return null;
		}
		*/

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

		/** ReadAsync
		*/
		/*
		public override System.Threading.Tasks.Task<int> ReadAsync(byte[] a_buffer,int a_offset,int a_count,System.Threading.CancellationToken a_cancellation_token)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return null;
		}
		*/

		/** ReadByte
		*/
		public override int ReadByte()
		{
			try{
				int t_data = this.data[this.position];
				this.position++;
				return t_data;
			}catch(System.Exception){
				return -1;
			}
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
			DebugTool.Assert(false);
			#endif
		}

		/** Write
		*/
		public override void Write(byte[] a_buffer,int a_offset,int a_count)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
		}

		/** WriteAsync
		*/
		/*
		public override System.Threading.Tasks.Task WriteAsync(byte[] a_buffer,int a_offset,int a_count,System.Threading.CancellationToken a_cancellation_token)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
			return null;
		}
		*/

		/** WriteByte
		*/
		/*
		public override void WriteByte(byte a_value)
		{
			#if(DEF_BLUEBACK_EXCEL_ASSERT)
			DebugTool.Assert(false);
			#endif
		}
		*/

		/** Dispose
		*/
		protected override void Dispose(bool a_disposing)
		{
			this.data = null;
			base.Dispose(a_disposing);
		}
	}
}

