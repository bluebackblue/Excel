

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief エンジン。
*/


/** BlueBack.Excel.EDR
*/
namespace BlueBack.Excel.EDR
{
	/** Engine
	*/
	public class Engine : Engine_Base
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

			a_assets_path_with_extention : 「Assets」からの相対パス。拡張子付き。

		*/
		public bool ReadOpen(string a_assets_path_with_extention)
		{
			#pragma warning disable 0168
			try{
				using(System.IO.FileStream t_stream = System.IO.File.Open(UnityEngine.Application.dataPath + '\\' + a_assets_path_with_extention,System.IO.FileMode.Open,System.IO.FileAccess.Read,System.IO.FileShare.ReadWrite)){
					if(t_stream != null){
						using(ExcelDataReader.IExcelDataReader t_reader = ExcelDataReader.ExcelReaderFactory.CreateOpenXmlReader(t_stream)){
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
					}else{
						//不明。

						#if(DEF_BLUEBACK_EXCEL_ASSERT)
						DebugTool.Assert(false);
						#endif
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

			return 0;
		}

		/** [BlueBack.Excel.Engine_Base]アクティブシート。設定。
		*/
		public void SetActiveSheet(int a_sheet_index)
		{
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
		}

		/** [BlueBack.Excel.Engine_Base]アクティブセル。設定。
		*/
		public void SetActiveCell(int a_x,int a_y)
		{
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
		}

		/** [BlueBack.Excel.Engine_Base]文字列。取得。
		*/
		public Result<string> TryGetCellString()
		{
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

			return new Result<string>(){
				success = false,
				value = "",
			};
		}

		/** [BlueBack.Excel.Engine_Base]少数。取得。
		*/
		public Result<double> TryGetCellDouble()
		{
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

			return new Result<double>(){
				success = false,
				value = 0.0,
			};
		}

		/** [BlueBack.Excel.Engine_Base]整数。取得。
		*/
		public Result<long> TryGetCellLong()
		{
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

			return new Result<long>(){
				success = false,
				value = 0,
			};
		}

	}
}

