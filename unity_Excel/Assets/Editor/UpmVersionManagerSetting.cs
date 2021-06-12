

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 設定。
*/


/** Editor
*/
#if(UNITY_EDITOR)
namespace Editor
{
	/** UpmVersionManagerSetting
	*/
	[UnityEditor.InitializeOnLoad]
	public static class UpmVersionManagerSetting
	{
		/** UpmVersionManagerSetting
		*/
		static UpmVersionManagerSetting()
		{
			//Object_RootUssUxml
			BlueBack.UpmVersionManager.Editor.Object_RootUssUxml.CreateFile(false);

			BlueBack.UpmVersionManager.Editor.Object_Setting.CreateInstance();
			BlueBack.UpmVersionManager.Editor.Object_Setting.Param t_param = new BlueBack.UpmVersionManager.Editor.Object_Setting.Param();
			{
				//author_name
				t_param.author_name = "BlueBack";

				//author_url
				t_param.author_url = "https://github.com/bluebackblue";

				//■package_name
				t_param.package_name = "Excel";

				//■getpackageversion
				t_param.getpackageversion = BlueBack.Excel.Version.GetPackageVersion;

				//packagejson_unity
				t_param.packagejson_unity = "2020.1";

				//■packagejson_discription
				t_param.packagejson_discription = "Excel操作";

				//■packagejson_keyword
				t_param.packagejson_keyword = new string[]{
					"asset"
				};

				//■changelog
				t_param.changelog = new string[]{
					"# Changelog",
					"",

					/*
					"## [0.0.0] - 0000-00-00",
					"### Changes",
					"- Init",
					"",
					*/

					"## [0.0.1] - 2021-04-05",
					"### Changes",
					"- Init",
					"",
				};

				//■readme_md
				t_param.object_root_readme_md = new BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Type[]{

					//概要。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"# " + a_argument.param.author_name + "." + a_argument.param.package_name,
							"Excel操作",
							"* スプレッドシートからの読み込み",
							"* バイナリからの読み込み",
							"* JsonItemへのコンバート",
						};
					},

					//ライセンス。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## ライセンス",
							"MIT License",
							"* " + a_argument.param.author_url + "/" + a_argument.param.package_name + "/blob/main/LICENSE",
						};
					},

					//依存。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## 外部依存 / 使用ライセンス等",
							"* " + a_argument.param.author_url + "/" + "JsonItem",
							"### サンプルのみ",
							"* " + a_argument.param.author_url + "/" + "AssetLib",
						};
					},

					//動作確認。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## 動作確認",
							"Unity " + UnityEngine.Application.unityVersion,
						};
					},

					//UPM。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## UPM",
							"### 最新",
							"* " + a_argument.param.author_url + "/" + a_argument.param.package_name + ".git?path=unity_" + a_argument.param.package_name + "/Assets/UPM#" + a_argument.version,
							"### 開発",
							"* " + a_argument.param.author_url + "/" + a_argument.param.package_name + ".git?path=unity_" + a_argument.param.package_name + "/Assets/UPM",
						};
					},

					//インストール。 
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## Unityへの追加方法",
							"* Unity起動",
							"* メニュー選択：「Window->Package Manager」",
							"* ボタン選択：「左上の＋ボタン」",
							"* リスト選択：「Add package from git URL...」",
							"* 上記UPMのURLを追加「 https://github.com/～～/UPM#バージョン 」",
							"### 注",
							"Gitクライアントがインストールされている必要がある。",
							"* https://docs.unity3d.com/ja/current/Manual/upm-git.html",
							"* https://git-scm.com/",
						};
					},

					//例。
					(in BlueBack.UpmVersionManager.Editor.Object_Setting.Creator_Argument a_argument) => {
						return new string[]{
							"## 例",

							"* ```[root]```の右セルはシート名。",
							"* ```[param_type]```の右セルは型を列挙。```string``` ```int``` ```float```が指定可能。```-```始まりはコメント扱いで無視。",
							"* ```[param_name]```の右セルは名前を列挙。```[param_type]```と対",
							"* ```*```のある行がコンバート対象。",
							"* 終端には```[end]```が必要。",
							"* 左上に```[end]```があるシートはスキップ",

							"![Sample01](/sample00.png)",

							"```",
							"{",
							"	\"sheetname\" : [",
							"		{",
							"			\"namae\" : \"satou\",",
							"			\"nedan\" : 10,",
							"			\"val\" : 1.3",
							"		},",
							"		{",
							"			\"namae\" : \"sio\",",
							"			\"nedan\" : 20,",
							"			\"val\" : 1.4",
							"		},",
							"		{",
							"			\"namae\" : \"shoyu\",",
							"			\"nedan\" : 30,",
							"			\"val\" : 1.5",
							"		}",
							"	]",
							"}",
							"```",

						};
					},

				};
			}

			BlueBack.UpmVersionManager.Editor.Object_Setting.GetInstance().Set(t_param);
		}
	}
}
#endif

