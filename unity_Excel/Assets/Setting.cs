

/**
 * Copyright (c) blueback
 * Released under the MIT License
 * @brief 設定。
*/


/** Setting
*/
public class Setting
{
	/** AUTHOR_NAME
	*/
	public const string AUTHOR_NAME = "BlueBack";

	/** PACKAGE_NAME
	*/
	public const string PACKAGE_NAME = "Excel";

	/** PACKAGEJSON
	*/
	public const string PACKAGEJSON_UNITY = "2020.1";

	/** PACKAGEJSON
	*/
	public const string PACKAGEJSON_DISCRIPTION = "Excel操作";

	/** PACKAGEJSON
	*/
	public static readonly string[] PACKAGEJSON_KEYWORD = new string[]{
		"excel"
	};

	/** GetPackageVersion
	*/
	public static string GetPackageVersion()
	{
		return BlueBack.Excel.Version.packageversion;
	}

	/** ReadmeMd_StringCreator_Argument
	*/
	public struct ReadmeMd_StringCreator_Argument
	{
		public string version;
	}

	/** ReadmeMd_StringCreator_Type
	*/
	public delegate string[] ReadmeMd_StringCreator_Type(in ReadmeMd_StringCreator_Argument a_argument);

	/** READMEMD_STRINGCREATOR
	*/
	public static readonly ReadmeMd_StringCreator_Type[] READMEMD_STRINGCREATOR = new ReadmeMd_StringCreator_Type[]{

		/** 概要。
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"# " + AUTHOR_NAME + "." + PACKAGE_NAME,
				"Excel操作",
				"* スプレッドシートからの読み込み",
				"* バイナリからの読み込み",
				"* JsonItemへのコンバート",
			};
		},

		/** ライセンス。
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## ライセンス",
				"MIT License",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + "/blob/main/LICENSE",
			};
		},

		/** 依存。
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## 外部依存 / 使用ライセンス等",
				"* https://github.com/bluebackblue/JsonItem",
				"### サンプルのみ",
				"* https://github.com/bluebackblue/AssetLib",
			};
		},

		/** 動作確認。
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## 動作確認",
				"Unity " + UnityEngine.Application.unityVersion,
			};
		},

		/** UPM。
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
			return new string[]{
				"## UPM",
				"### 最新",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + ".git?path=unity_" + PACKAGE_NAME + "/Assets/UPM#" + a_argument.version,
				"### 開発",
				"* https://github.com/bluebackblue/" + PACKAGE_NAME + ".git?path=unity_" + PACKAGE_NAME + "/Assets/UPM",
			};
		},

		/** インストール。 
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
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

		/** 例。
		*/
		(in ReadmeMd_StringCreator_Argument a_argument) => {
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

