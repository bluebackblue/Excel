

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief エンジン。
*/


/** BlueBack.Excel.EDR
*/
namespace BlueBack.Excel.EDR
{
	/** Engine
	*/
	public sealed class Engine : Engine_Base
	{
		/** excel
		*/
		private System.Data.DataSet excel;

		/** activesheet;
		*/
		private System.Data.DataTable activesheet;

		/** activecell
		*/
		private System.Object activecell;

		/** constructor
		*/
		public Engine()
		{
			//excel
			this.excel = null;

			//activesheet
			this.activesheet = null;

			//activecell
			this.activecell = null;
		}

		/** [BlueBack.Excel.Engine_Base]開く。
		*/
		public bool ReadOpen(byte[] a_data)
		{
			#pragma warning disable 0168
			try{
				using(System.IO.Stream t_stream = new ReadStream(a_data)){
					using(ExcelDataReader.IExcelDataReader t_reader = ExcelDataReader.ExcelReaderFactory.CreateReader(t_stream)){
						if(t_reader != null){
							this.excel = ExcelDataReader.ExcelDataReaderExtensions.AsDataSet(t_reader);
							this.activesheet = null;
							this.activecell = null;

							return true;
						}else{
							//破損。

							#if(DEF_BLUEBACK_EXCEL_ASSERT)
							DebugTool.Assert(false);
							#endif
						}
					}
				}
			}catch(System.Exception t_exception){
				//ファイルが開けない。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			this.excel = null;
			this.activesheet = null;
			this.activecell = null;

			return false;
		}

		/** [BlueBack.Excel.Engine_Base]閉じる。
		*/
		public void Close()
		{
			//excel
			this.excel = null;
		}

		/** [BlueBack.Excel.Engine_Base]シート数。取得。
		*/
		public int GetSheetCount()
		{
			#pragma warning disable 0168
			try{
				if(this.excel != null){
					return this.excel.Tables.Count;
				}else{
					//ファイルを開いていない。

					#if(DEF_BLUEBACK_EXCEL_ASSERT)
					DebugTool.Assert(false);
					#endif
				}
			}catch(System.Exception t_exception){
				//不明。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return 0;
		}

		/** [BlueBack.Excel.Engine_Base]アクティブシート。設定。
		*/
		public void SetActiveSheet(int a_sheet_index)
		{
			#pragma warning disable 0168
			try{
				if(this.excel != null){
					this.activesheet = this.excel.Tables[a_sheet_index];
					if(this.activesheet == null){
						//不明。

						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false);
						#endif
					}
				}else{
					//ファイルを開いていない。

					#if(DEF_BLUEBACK_EXCEL_ASSERT)
					DebugTool.Assert(false);
					#endif
				}
			}catch(System.Exception t_exception){
				//範囲外。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore
		}

		/** [BlueBack.Excel.Engine_Base]アクティブセル。設定。
		*/
		public void SetActiveCell(int a_x,int a_y)
		{
			#pragma warning disable 0168
			try{
				if(this.activesheet != null){
					if((0 <= a_y)&&(a_y < this.activesheet.Rows.Count)){
						System.Data.DataRow t_line = this.activesheet.Rows[a_y];
						if((0 <= a_x)&&(a_x < t_line.ItemArray.Length)){
							this.activecell = t_line.ItemArray[a_x];
							if(this.activecell == null){
								//不明。

								#if(DEF_BLUEBACK_EXCEL_ASSERT)
								DebugTool.Assert(false);
								#endif
							}
						}else{
							//データのないセル。

							this.activecell = null;
						}
					}else{
						//データのないセル。

						this.activecell = null;
					}
				}else{
					//シートを開いていない。

					#if(DEF_BLUEBACK_EXCEL_ASSERT)
					DebugTool.Assert(false);
					#endif

					this.activecell = null;

				}
			}catch(System.Exception t_exception){
				//不明。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif

				this.activecell = null;
			}
			#pragma warning restore
		}

		/** [BlueBack.Excel.Engine_Base]文字列。取得。
		*/
		public Result<string> TryGetCellString()
		{
			#pragma warning disable 0168
			try{
				if(this.activecell != null){
					string t_result_value = this.activecell.ToString();
					if(t_result_value != null){
						return new Result<string>(){
							success = true,
							value = t_result_value,
						};
					}else{
						//不明。

						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false);
						#endif
					}
				}else{
					//データのないセル。
					return new Result<string>(){
						success = false,
						value = "",
					};
				}
			}catch(System.Exception t_exception){
				//不明。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return new Result<string>(){
				success = false,
				value = "",
			};
		}

		/** [BlueBack.Excel.Engine_Base]少数。取得。
		*/
		public Result<double> TryGetCellDouble()
		{
			#pragma warning disable 0168
			try{
				if(this.activecell != null){
					System.Type t_type = this.activecell.GetType();
					if(t_type.IsValueType == true){
						if(this.activecell.GetType() == typeof(System.Double)){
							return new Result<double>(){
								success = true,
								value = (System.Double)this.activecell,
							};
						}else{
							//未対応の型。

							#if(DEF_BLUEBACK_EXCEL_ASSERT)
							DebugTool.Assert(false);
							#endif

							return new Result<double>(){
								success = false,
								value = 0.0,
							};
						}
					}else if(t_type == typeof(string)){
						string t_result_value = this.activecell as string;
						if(t_result_value != null){
							if(double.TryParse(t_result_value,out double t_value_double) == true){
								return new Result<double>(){
									success = true,
									value = t_value_double,
								};
							}else{
								//数値にパースできない。

								#if(DEF_BLUEBACK_EXCEL_ASSERT)
								DebugTool.Assert(false);
								#endif
							}
						}else{
							//不明。

							#if(DEF_BLUEBACK_EXCEL_ASSERT)
							DebugTool.Assert(false);
							#endif
						}
					}else if(t_type == typeof(System.DBNull)){
						//データのないセル。

						return new Result<double>(){
							success = false,
							value = 0.0,
						};
					}else{
						//不明。

						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false);
						#endif
					}
				}else{
					//データのないセル。

					return new Result<double>(){
						success = false,
						value = 0.0,
					};
				}
			}catch(System.Exception t_exception){
				//不明。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return new Result<double>(){
				success = false,
				value = 0.0,
			};
		}

		/** [BlueBack.Excel.Engine_Base]整数。取得。
		*/
		public Result<long> TryGetCellLong()
		{
			#pragma warning disable 0168
			try{
				if(this.activecell != null){
					System.Type t_type = this.activecell.GetType();
					if(t_type.IsValueType == true){
						if(this.activecell.GetType() == typeof(System.Double)){
							return new Result<long>(){
								success = true,
								value = (long)((System.Double)this.activecell),
							};
						}else{
							//未対応の型。

							#if(DEF_BLUEBACK_EXCEL_ASSERT)
							DebugTool.Assert(false);
							#endif

							return new Result<long>(){
								success = false,
								value = 0,
							};
						}
					}else if(t_type == typeof(string)){
						string t_result_value = this.activecell as string;
						if(t_result_value != null){
							if(long.TryParse(t_result_value,out long t_value_long) == true){
								return new Result<long>(){
									success = true,
									value = t_value_long,
								};
							}else{
								//数値にパースできない。

								#if(DEF_BLUEBACK_EXCEL_ASSERT)
								DebugTool.Assert(false);
								#endif
							}
						}else{
							//不明。

							#if(DEF_BLUEBACK_EXCEL_ASSERT)
							DebugTool.Assert(false);
							#endif
						}
					}else if(t_type == typeof(System.DBNull)){
						//データのないセル。

						return new Result<long>(){
							success = false,
							value = 0,
						};
					}else{
						//不明。

						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false);
						#endif
					}
				}else{
					//データのないセル。

					return new Result<long>(){
						success = false,
						value = 0,
					};
				}
			}catch(System.Exception t_exception){
				//不明。

				#if(DEF_BLUEBACK_EXCEL_ASSERT)
				DebugTool.Assert(false,t_exception);
				#endif
			}
			#pragma warning restore

			return new Result<long>(){
				success = false,
				value = 0,
			};
		}

	}
}

